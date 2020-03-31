using Jukebox_Heroes.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Jukebox_Heroes.SongLibrary
{
    public partial class SongLibraryWindow : Window
    {
        ISongLibraryData songLibrary;
        ISongUpload songUpload;

        public SongLibraryWindow(ISongLibraryData songLibrary) {
            InitializeComponent();

            this.songLibrary = songLibrary;
            this.songUpload = new SongUpload(songLibrary);

            Song_Library_List_Box.ItemsSource = this.songLibrary.getSongList();
        }

        private void Song_Library_Upload_Click(object sender, RoutedEventArgs e) {
            songUpload.UploadSong();
            Song_Library_List_Box.ItemsSource = this.songLibrary.getSongList();
        }
    }
}
