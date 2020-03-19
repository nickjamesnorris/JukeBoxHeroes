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
        private const string libraryFilePath = "./data/library.json";
        List<SongData> songList = new List<SongData>();

        public SongLibraryData() {

        }

        public void saveLibrary() {
            File.WriteAllText(libraryFilePath, JsonConvert.SerializeObject(songList));
        }

        public void loadLibrary() {
            songList = JsonConvert.DeserializeObject<List<SongData>>(File.ReadAllText(libraryFilePath));
        }

    }
}
