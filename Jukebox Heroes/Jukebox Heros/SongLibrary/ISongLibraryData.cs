using Jukebox_Heroes.Song;
using System.Collections.Generic;

namespace Jukebox_Heroes
{
    public interface ISongLibraryData
    {
        void addSong(SongData song);
        void removeSong(int songID);
        void saveLibrary();
        void loadLibrary();
        SongData getSong(int songID);
        List<SongData> getSongList();
    }
}

