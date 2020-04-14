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
            
            List<string> songFilePathList = new List<string>();

            foreach(SongData song in songList) {
                songFilePathList.Add(song.filePath);
            }

            FileStream file = File.Create(libraryFilePath);
            file.Close();
            File.WriteAllText(libraryFilePath, JsonConvert.SerializeObject(songFilePathList));
        }

        public void loadLibrary() {
            if (!File.Exists(libraryFilePath))
            {
                MessageBox.Show("Need to first have a saved library in order to load one.");
                return;
            }
            List<string> library = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(libraryFilePath));
            if(library == null)
            {
                MessageBox.Show("library.json could not be opened.");
                return;
            }

            songList.Clear();

            foreach (string filePath in library) {
                songList.Add(new SongData(filePath));
            }

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
