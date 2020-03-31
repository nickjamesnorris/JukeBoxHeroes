using Jukebox_Heroes.Song;

namespace Jukebox_Heroes
{
    public interface IPlaylistData
    {
        void syncListAndListbox();
        void addSong(SongData song);
        void removeSong();
        void nextSong();
        void previousSong();
        SongData getCurrentSong();

    }
}
