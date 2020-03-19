using Jukebox_Heros.Song;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Jukebox_Heros.SongLibrary
{
    class SongLibraryData
    {
        private const string libraryFilePath = "..//..//data//library.json";
        private List<SongData> _songList = new List<SongData>();
        public List<SongData> songList {
            get { return _songList; }
        }

        public SongLibraryData() {

        }

        public void addSong(SongData song)
        {
            songList.Add(song);
        }

        public void removeSong(int songID)
        {
            songList.Remove(songList.Find(song => song.songID == songID));
        }
        public void saveLibrary() {
            if (!File.Exists(libraryFilePath)) {
                File.Create(libraryFilePath);
            }

            File.WriteAllText(libraryFilePath, JsonConvert.SerializeObject(this));
            _songList.ForEach((item) => Console.WriteLine(item.title));
            Console.WriteLine(JsonConvert.SerializeObject(this));
        }

        public void loadLibrary() {
           // songList = JsonConvert.DeserializeObject<List<SongLibraryData>>(File.ReadAllText(libraryFilePath));
        }

    }
}
