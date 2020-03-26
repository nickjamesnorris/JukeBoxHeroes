using System.Windows;

namespace Jukebox_Heroes.Song
{
    interface ISongUpload
    {
        void UploadSong(object sender, RoutedEventArgs e);
        void Remove_Song_Click(object sender, RoutedEventArgs e);

    }
}
