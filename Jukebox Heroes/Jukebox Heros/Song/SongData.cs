using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using TagLib;

namespace Jukebox_Heroes.Song
{
    public class SongData {
        private static int nextSongID = 0;

        public Uri songUri { get; }
        public string title { get; }
        public string album { get; }
        public string artist { get; }
        public string filePath { get; }
        public uint year { get; }
        public string[] genres { get; }
        public TimeSpan duration { get; }
        public int songID { get; }
        public Image albumArt { get; }

        public SongData(string filePath)
        {
            this.filePath = filePath;
            this.songUri = new Uri(filePath);
            TagLib.File file = TagLib.File.Create(filePath);

            this.title = file.Tag.Title;
            this.artist = file.Tag.FirstAlbumArtist;
            this.album = file.Tag.Album;
            this.year = file.Tag.Year;
            this.genres = file.Tag.Genres;
            this.duration = file.Properties.Duration;

            if (this.title == null)
            {
                this.title = filePath;
            }

            this.songID = nextSongID++;

            if (file.Tag.Pictures.Length > 0)
            {
                MemoryStream ms = new MemoryStream(file.Tag.Pictures[0].Data.Data);
                this.albumArt = Image.FromStream(ms);
            }
            else
            {
                try
                {
                    this.albumArt = Image.FromFile("..\\data\\AlbumArtPlaceholder.png");
                }
                catch
                {
                    Console.WriteLine("File not found");
                }
            }
        }

        public System.Windows.Controls.Image ConvertAlbumArtToWPFImage()
        {
            System.Windows.Controls.Image WPFImage = new System.Windows.Controls.Image();

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(this.albumArt);
            IntPtr hBitmap = bmp.GetHbitmap();
            System.Windows.Media.ImageSource WPFBitmap = 
                System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, 
                IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            WPFImage.Source = WPFBitmap;
            WPFImage.Width = 500;
            WPFImage.Height = 600;
            WPFImage.Stretch = System.Windows.Media.Stretch.Fill;
            return WPFImage;
        }

        public override string ToString()
        {
            return title;
        }
    } 
}
