using Jukebox_Heros.Playlist;
using Jukebox_Heros.Song;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Jukebox_Heros.SongLibrary
{
    class SongUpload
    {
        PlaylistData songList;


        public SongUpload(PlaylistData songList) {
            this.songList = songList;
        }

        public SongUpload()
        {
        }

        public void UploadSong(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog1 = new OpenFileDialog {
                InitialDirectory = @"C:\",
                Title = "Browse Music Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "mp3",
                Filter = "mp3 files (*.mp3)|*.mp3",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == true) {
                SongData song = new SongData(openFileDialog1.FileName);
                songList.addSong(song);
            }
        }


        public void Remove_Song_Click(object sender, RoutedEventArgs e)
        {
            songList.removeSong();
        }

    }
}
