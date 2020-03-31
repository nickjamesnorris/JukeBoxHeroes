using System.Windows;

namespace Jukebox_Heroes.Song
{
    public interface ISongUpload
    {
        void UploadSong(object sender, RoutedEventArgs e);
        void Remove_Song_Click(object sender, RoutedEventArgs e);

    }
}
