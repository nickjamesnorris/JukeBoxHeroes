using Jukebox_Heros.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jukebox_Heros.SongLibrary
{
    class SongLibraryData
    {
        List<SongData> songList = new List<SongData>();

        public SongLibraryData() {

        }

        public void addSong(SongData song)
        {
            songList.Add(song);
        }

        public void removeSong(int songID)
        {
            songList.Remove(songList.Find(song => song.getSongID() == songID));
        }

    }
}
