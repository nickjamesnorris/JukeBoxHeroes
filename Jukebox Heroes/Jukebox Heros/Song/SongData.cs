using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;


namespace Jukebox_Heros.Song
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

        }

        public override string ToString()
        {
            return title;
        }
        



    }

    
}
