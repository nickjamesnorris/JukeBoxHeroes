using Jukebox_Heros.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Jukebox_Heros.Playlist
{
    
    class PlaylistData
    {
        ListBox songsListBox;
        List<SongData> songData = new List<SongData>();
        int currentSongIndex = 0;

        public PlaylistData(ListBox b)
        {
            this.songsListBox = b;
        }

        public void addSong(SongData song)
        {
            this.songData.Add(song);
            songsListBox.Items.Add(song);
        }
        public SongData getNextSong()
        {
            currentSongIndex = songsListBox.SelectedIndex;
            return songData.ElementAt(++currentSongIndex);
            //if (currentSongIndex)
            //{
            //    currentSongIndex = listBox.SelectedIndex;
            //}
            //currentSongIndex++;
            //if (currentSongIndex < listBox.Items.Count)
            //{
            //    player.Play(listBox.Items[currentSongIndex]);
            //}
            //else
            //{
            //    // last song in listbox has been played
            //}
            
        }

        public SongData getPreviousSong()
        {
            if(currentSongIndex != 0)
            {
                return songData.ElementAt(--currentSongIndex);
            }
            else
            {
                return songData.ElementAt(songData.Count - 1);
            }
        }

        public SongData getCurrentSong()
        {
            return songData.ElementAt(currentSongIndex);
        }

        public void removeSong()
        {
            songData.RemoveAt(songsListBox.SelectedIndex);
            songsListBox.Items.RemoveAt(songsListBox.SelectedIndex);
        }
    }
}
