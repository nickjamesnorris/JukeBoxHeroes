using Jukebox_Heros.SongLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Jukebox_Heros.PlayerUI
{
    class Player
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private ListBox songList;

        public Player(ListBox songList)
        {
            this.songList = songList;
            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Tick += timer_Tick;
            //timer.Start();
        }

        //void timer_Tick(object sender, EventArgs e)
        //{
        //    if (mediaPlayer.Source != null)
        //        lblStatus.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
        //    else
        //        lblStatus.Content = "No file selected...";
        //}

        public Player(MediaPlayer mediaPlayer)
        {
            this.mediaPlayer = mediaPlayer;
        }

        public void Play_Click(object sender, RoutedEventArgs e)
        {
            GetSong();
           //Nick I Love you. You are too good to me. Have a sweet spring break
            mediaPlayer.Play();
        }

        public void Pause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        public void Stop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        public void GetSong()
        {
            mediaPlayer.Open((Uri)songList.SelectedItem.getUri());
        }
    }
}