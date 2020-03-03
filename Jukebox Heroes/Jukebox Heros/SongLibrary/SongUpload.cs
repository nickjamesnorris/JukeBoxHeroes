using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Jukebox_Heros.SongLibrary
{
    class SongUpload
    {
        ListBox songList;


        public SongUpload(ListBox songList) {
            this.songList = songList;
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
                SongData.SongData song = new SongData.SongData(openFileDialog1.FileName);
                songList.Items.Add(openFileDialog1.SafeFileName);
            }
        }


        public void Remove_Song_Click(object sender, RoutedEventArgs e)
        {
            while (songList.SelectedItems.Count > 0)
            {
                songList.Items.Remove(songList.SelectedItems[0]);
            }
        }

    }
}
