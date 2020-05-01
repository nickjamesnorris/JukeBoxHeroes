using Jukebox_Heroes.PlayerUI;
using Jukebox_Heroes.Playlist;
using Jukebox_Heroes.Song;
using Jukebox_Heroes.SongLibrary;
using Jukebox_Heroes.Server;
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
using System.Net.Sockets;
using System.Net;
using System.Security.Principal;
using System.ComponentModel;

namespace Jukebox_Heroes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IPlayer player;
        public IPlaylistData playlist;
        ISongLibraryData songLibrary;
        Window songLibraryWindow;
        Window serverWindow;
        Window joinWindow;


        public MainWindow() {
            InitializeComponent();

            songLibrary = new SongLibraryData();

            playlist = new PlaylistData(Song_List_Box, songLibrary);

            player = new Player(Media_Element, Song_Slider, Song_Time_Text, playlist, Album_Art, Song_Info);
            Play_Button.Click += player.Play_Click;
            Pause_Button.Click += player.Pause_Click;
            Stop_Button.Click += player.Stop_Click;
            Next_Button.Click += player.Next_Click;
            Previous_Button.Click += player.Previous_Click;
        }

        // Change the volume of the media.
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            Media_Element.Volume = (double)volumeSlider.Value;
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

        private void Add_Song_To_Playlist_Button_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Start by Clicking the Upload Song Button and Uploading Music From Your Local Drive");
            songLibraryWindow = new SongLibraryWindow(songLibrary, playlist);
            songLibraryWindow.Show();
        }

        private void Remove_Song_From_Playlist_Button_Click(object sender, RoutedEventArgs e) {
            playlist.removeSong();
        }

        private void Host_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)) {
                MessageBox.Show("Need to run program as an administrator to host a server.");
                return;
            } 

            serverWindow = new ServerWindow(playlist, Hosting_Label, songLibrary);
            serverWindow.Show();
        }

        private void Join_Button_Click(object sender, RoutedEventArgs e)
        {
            joinWindow = new Join();
            joinWindow.Show();
        }
    }
}

