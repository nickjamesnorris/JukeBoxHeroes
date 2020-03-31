using Jukebox_Heroes.Song;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Windows;

namespace Jukebox_Heroes.SongLibrary
{
    public class SongLibraryData : ISongLibraryData
    {
        private const string libraryFilePath = ".//data//library.json";
        private List<SongData> _songList = new List<SongData>();
        public List<SongData> songList {
            get { return _songList; }
        }
        
        public SongLibraryData() {
        }

        public void addSong(SongData song)
        {
            _songList.Add(song);
        }

        public void removeSong(int songID)
        {
            SongData song = _songList.Find(item => item.songID == songID);
            _songList.Remove(song);
        }

        public void saveLibrary() {
            if (!File.Exists(libraryFilePath)) {
                System.IO.Directory.CreateDirectory(".//data");
                
            }
            FileStream file = File.Create(libraryFilePath);
            file.Close();
            File.WriteAllText(libraryFilePath, JsonConvert.SerializeObject(this));
            _songList.ForEach((item) => Console.WriteLine(item.title));
            
        }

        public void loadLibrary() {
            if (!File.Exists(libraryFilePath))
            {
                MessageBox.Show("Need to first have a saved library in order to load one.");
                return;
            }
            SongLibraryData library = JsonConvert.DeserializeObject<SongLibraryData>(File.ReadAllText(libraryFilePath));
            if(library == null)
            {
                MessageBox.Show("library.json could not be opened.");
                return;
            }
            _songList = library.songList;

        }

        public SongData getSong(int songID) {
            return _songList.Find(item => item.songID == songID); ;
        }

        public List<SongData> getSongList() {
            return songList;
        }

    }
}
