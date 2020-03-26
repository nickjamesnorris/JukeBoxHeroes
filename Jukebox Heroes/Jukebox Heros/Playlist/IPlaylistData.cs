﻿using Jukebox_Heroes.Song;

namespace Jukebox_Heroes
{
    interface IPlaylistData
    {
        void syncListAndListbox();
        void addSongFromLibrary();
        void addSong(SongData song);
        void removeSong();
        void nextSong();
        void previousSong();
        SongData getCurrentSong();

    }
}