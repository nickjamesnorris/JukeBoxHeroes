using Jukebox_Heros.PlayerUI;
using Jukebox_Heros.Playlist;
using Jukebox_Heros.SongLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Jukebox_Heros
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player player;
        PlaylistData playlist;
        SongLibraryData songLibrary;

        public MainWindow() {
            InitializeComponent();

            songLibrary = new SongLibraryData(Song_Library_List_Box);

            playlist = new PlaylistData(Song_List_Box, songLibrary);
            SongUpload songUpload = new SongUpload(songLibrary);
            Library_Remove_Song_Button.Click += songUpload.Remove_Song_Click;
            Library_Upload_Song_Button.Click += songUpload.UploadSong;

            player = new Player(Media_Element, Song_Slider, Song_Time_Text, playlist);
            Play_Button.Click += player.Play_Click;
            Pause_Button.Click += player.Pause_Click;
            Stop_Button.Click += player.Stop_Click;
            Next_Button.Click += player.Next_Click;
            Previous_Button.Click += player.Previous_Click;

        }

        private void Song_Slider_DragStarted(object sender, DragStartedEventArgs e) {
            player.slider_DragStarted();
        }

        private void Song_Slider_DragCompleted(object sender, DragCompletedEventArgs e) {
            player.slider_DragCompleted();
        }

        private void Song_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            player.slider_ValueChanged();
        }

        private void Song_Library_Save_Button_Click(object sender, RoutedEventArgs e) {
            songLibrary.saveLibrary();
        }

        private void Add_Song_To_Playlist_Button_Click(object sender, RoutedEventArgs e) {
            playlist.addSongFromLibrary();
        }

        private void Remove_Song_From_Playlist_Button_Click(object sender, RoutedEventArgs e) {
            playlist.removeSong();
        }

        private void Song_Library_Load_Button_Click(object sender, RoutedEventArgs e) {
            songLibrary.loadLibrary();
        }
    }
}
