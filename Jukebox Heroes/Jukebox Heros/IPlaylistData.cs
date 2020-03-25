using Jukebox_Heroes.Song;
using Jukebox_Heroes.SongLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
