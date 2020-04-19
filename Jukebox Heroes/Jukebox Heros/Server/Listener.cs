using Jukebox_Heroes.Song;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;

namespace Jukebox_Heroes.Server
{
    public class Listener
    {
        IPlaylistData playlist;
        ISongLibraryData songLibrary;
        public Listener(IPlaylistData playlist, ISongLibraryData songLibrary)
        {
            this.playlist = playlist;
            this.songLibrary = songLibrary;
        }

        public void ExecuteServer(int portNum)
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, portNum);

            Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);
                Console.WriteLine("Server is Listening....");
                Socket ClientSocket = default;


                while (true)
                {
                    
                    ClientSocket = listener.Accept();
                    Console.WriteLine("Client connected");

                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        MainWindow joiner = new MainWindow();
                        
                            List<SongData> list = playlist.getAllSongs();

                        for (int i = 0; i < list.Count; i++)
                        {
                            Uri newUri = new Uri("http://" + GetIPAddress().ToString() + ":8080/" + list[i].filePath);

                            SongData newSong = new SongData(list[i].filePath);
                            newSong.songUri = newUri;

                            Console.WriteLine(newUri);
                            joiner.playlist.addSong(newSong);
                                
                        }

                            joiner.Join_Button.Visibility = Visibility.Hidden;
                            joiner.Host_Button.Visibility = Visibility.Hidden;
                            joiner.Add_Song_To_Playlist_Button.Visibility = Visibility.Hidden;
                            joiner.Remove_Song_From_Playlist_Button.Visibility = Visibility.Hidden;
                            joiner.Show();
                        });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public IPAddress GetIPAddress() {
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList) {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                    return IP;
                }
            }

            return null;
        }

    }
}
