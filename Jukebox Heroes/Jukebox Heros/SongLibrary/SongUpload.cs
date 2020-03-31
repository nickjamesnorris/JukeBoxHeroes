using Jukebox_Heroes.Song;
using Microsoft.Win32;
using System.Windows;


namespace Jukebox_Heroes.SongLibrary
{
    public class SongUpload : ISongUpload
    {
        ISongLibraryData songLibrary;


        public SongUpload(ISongLibraryData songLibrary) {
            this.songLibrary = songLibrary;
        }

        public void UploadSong() {
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
                ShowReadOnly = true,
                Multiselect = true
            };

            if (openFileDialog1.ShowDialog() == true)
            {
                //SongData song = new SongData(openFileDialog1.FileName);
                foreach (string file in openFileDialog1.FileNames)
                {
                    SongData song = new SongData(file);
                    songLibrary.addSong(song);
                }
            }
        }

    }
}
