using Jukebox_Heroes.Song;
using Jukebox_Heroes.SongLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;


namespace Jukebox_Heroes.Playlist 
{

    public class PlaylistData : IPlaylistData
    {
        ListBox songsListBox;
        List<SongData> songData = new List<SongData>();
        SongLibraryData library;
        int currentSongIndex = 0;

        public PlaylistData(ListBox songsListBox, SongLibraryData library)
        {
            this.songsListBox = songsListBox;
            this.library = library;
        }

        public void syncListAndListbox() {
            songsListBox.Items.Clear();
            foreach (SongData song in songData) {
                songsListBox.Items.Add(song);
            }

            if (currentSongIndex >= songData.Count) currentSongIndex = songData.Count - 1;

        }

        public void addSongFromLibrary() {
            addSong(library.getSelectedSong());
        }

        public void addSong(SongData song)
        {
            this.songData.Add(song);
            syncListAndListbox();
        }

        public void removeSong() {
            songData.RemoveAt(songsListBox.SelectedIndex);
            if (songsListBox.SelectedIndex <= currentSongIndex) currentSongIndex--;
            syncListAndListbox();
        }

        public void nextSong()
        {
            if(currentSongIndex == songData.Count - 1) 
            {
                currentSongIndex = 0;
            } else 
            {
                currentSongIndex++;
            }
            
        }

        public void previousSong()
        {
            if(currentSongIndex != 0)
            {
                currentSongIndex--;
            }
            else
            {
                currentSongIndex = songData.Count - 1;
            }
        }

        public SongData getCurrentSong()
        {
            if (songData.Count == 0) return null;
            return songData.ElementAt(currentSongIndex);
        }

    }
}
