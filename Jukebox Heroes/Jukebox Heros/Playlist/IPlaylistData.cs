using Jukebox_Heroes.Song;
using System.Collections.Generic;

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
        List<SongData> getAllSongs();
    }
}
