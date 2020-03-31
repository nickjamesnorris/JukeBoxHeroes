using Jukebox_Heroes.Song;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;

namespace Jukebox_Heroes.SongLibrary
{
    public class SongLibraryData : ISongLibraryData
    {
        private const string libraryFilePath = ".//data//library.json";
        public ObservableCollection<SongData> songList {
            get; set;
        }
        
        public SongLibraryData() {
            songList = new ObservableCollection<SongData>();
        }

        public void addSong(SongData song)
        {
            songList.Add(song);
        }

        public void removeSong(int songID)
        {
            songList.Remove(getSong(songID));
        }

        public void saveLibrary() {
            if (!File.Exists(libraryFilePath)) {
                System.IO.Directory.CreateDirectory(".//data");
                
            }
            FileStream file = File.Create(libraryFilePath);
            file.Close();
            File.WriteAllText(libraryFilePath, JsonConvert.SerializeObject(this));
        }

        public void loadLibrary() {
            if (!File.Exists(libraryFilePath))
            {
                MessageBox.Show("Need to first have a saved library in order to load one.");
                return;
            }
            SongLibraryData library = JsonConvert.DeserializeObject<SongLibraryData>(File.ReadAllText(libraryFilePath));
            if(library == null)
            {
                MessageBox.Show("library.json could not be opened.");
                return;
            }
            songList = library.songList;

        }

        public SongData getSong(int songID) {
            foreach (SongData song in songList) {
                if (song.songID == songID) return song;
            }
            return null;
        }

        public ObservableCollection<SongData> getSongList() {
            return songList;
        }

    }
}
