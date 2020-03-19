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

        public MainWindow() {
            InitializeComponent();

            playlist = new PlaylistData(Song_List_Box);
            SongUpload songUpload = new SongUpload(playlist);
            Upload_Song_Button.Click += songUpload.UploadSong;
            Remove_Song_Button.Click += songUpload.Remove_Song_Click;

            player = new Player(Song_List_Box, Media_Element, Song_Slider, Song_Time_Text);
            Play_Button.Click += player.Play_Click;
            Pause_Button.Click += player.Pause_Click;
            Stop_Button.Click += player.Stop_Click;

        }

        private void Song_Slider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e) {
            player.slider_DragStarted();
        }

        private void Song_Slider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e) {
            player.slider_DragCompleted();
        }

        private void Song_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            player.slider_ValueChanged();
        }
    }
}
