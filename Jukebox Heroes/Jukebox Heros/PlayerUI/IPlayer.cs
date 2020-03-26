using System;
using System.Windows;

namespace Jukebox_Heroes.PlayerUI
{
    interface IPlayer
    {
        void tick(object sender, EventArgs e);
        void Play_Click(object sender, RoutedEventArgs e);
        void Pause_Click(object sender, RoutedEventArgs e);
        void Stop_Click(object sender, RoutedEventArgs e);
        void Stop();
        void Next_Click(object sender, RoutedEventArgs e);
        void Previous_Click(object sender, RoutedEventArgs e);
        void GetSong();
        void OnMediaEnded(object sender, EventArgs e);
        void slider_DragStarted();
        void slider_DragCompleted();
        void slider_ValueChanged();
}
}
