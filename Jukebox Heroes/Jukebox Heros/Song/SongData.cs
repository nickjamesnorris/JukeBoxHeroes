using System;
using System.Drawing;
using System.IO;
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
            if (file.Tag.Pictures != null)
            {
                MemoryStream ms = new MemoryStream(file.Tag.Pictures[0].Data.Data);
                this.albumArt = Image.FromStream(ms);
            }
            else
            {
                this.albumArt = Image.FromFile("..//assets//AlbumArtPlaceholder.png");
            }
        }

        public override string ToString()
        {
            return title;
        }
    } 
}
