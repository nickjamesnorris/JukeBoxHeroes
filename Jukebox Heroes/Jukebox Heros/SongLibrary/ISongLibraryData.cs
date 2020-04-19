using Jukebox_Heroes.Song;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Jukebox_Heroes
{
    public interface ISongLibraryData
    {
        void addSong(SongData song);
        void removeSong(string filePath);
        void saveLibrary();
        void loadLibrary();
        SongData getSong(string filePath);
        ObservableCollection<SongData> getSongList();
    }
}

