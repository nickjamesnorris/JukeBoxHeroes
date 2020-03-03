using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;


namespace Jukebox_Heros.SongData
{
    class SongData
    {
        private Uri linkToSong;
        private string title, album, artist;
        private uint year;
        private string[] genres;
        private TimeSpan duration;

        public SongData(string filePath)
        {
            this.linkToSong = new Uri(filePath);
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

        }
 
          

        public Uri getUri()
        {
            return linkToSong;
        }

        public string getTitle()
        {
            return title;
        }

        public string getArtist()
        {
            return artist;
        }

        public string getAlbum()
        {
            return album;
        }

        public uint getYear()
        {
            return year;
        }

        public string[] getGenres()
        {
            return genres;
        }

        public TimeSpan getDuration()
        {
            return duration;
        }



        



    }

    
}
