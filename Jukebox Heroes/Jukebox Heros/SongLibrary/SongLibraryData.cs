using Jukebox_Heros.Song;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Controls;

namespace Jukebox_Heros.SongLibrary
{
    public class SongLibraryData
    {
        private const string libraryFilePath = "..//..//data//library.json";
        private List<SongData> _songList = new List<SongData>();
        public List<SongData> songList {
            get { return _songList; }
        }
        private ListBox libraryListBox;

        public SongLibraryData(ListBox libraryListBox) {
            this.libraryListBox = libraryListBox;
        }

        public void syncListAndListbox() {
            libraryListBox.Items.Clear();
            foreach (SongData song in _songList) {
                libraryListBox.Items.Add(song);
            }

        }

        public void addSong(SongData song)
        {
            _songList.Add(song);
            syncListAndListbox();
        }

        public void removeSong(int songID)
        {
            SongData song = _songList.Find(item => item.songID == songID);
            _songList.Remove(song);
            syncListAndListbox();
        }

        public void removeSelectedSong() {
            removeSong(((SongData)libraryListBox.SelectedItem).songID);
        }

        public void saveLibrary() {
            if (!File.Exists(libraryFilePath)) {
                System.IO.Directory.CreateDirectory("..//..//data");
                
            }
            FileStream file = File.Create(libraryFilePath);
            file.Close();
            File.WriteAllText(libraryFilePath, JsonConvert.SerializeObject(this));
            _songList.ForEach((item) => Console.WriteLine(item.title));
            
        }

        public void loadLibrary() {
            if (!File.Exists(libraryFilePath))
            {
                return;
            }
            SongLibraryData library = JsonConvert.DeserializeObject<SongLibraryData>(File.ReadAllText(libraryFilePath));
            if(library == null)
            {
                return;
            }
            _songList = library.songList;

            syncListAndListbox();
        }

        public SongData getSelectedSong() {
            return (SongData) libraryListBox.SelectedItem;
        }

    }
}
