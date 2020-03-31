using Jukebox_Heroes.Song;

namespace Jukebox_Heroes
{
    public interface ISongLibraryData
    {
        void syncListAndListbox();
        void addSong(SongData song);
        void removeSong(int songID);
        void removeSelectedSong();
        void saveLibrary();
        void loadLibrary();
        SongData getSelectedSong();
    }
}

