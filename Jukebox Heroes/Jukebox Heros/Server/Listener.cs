using Jukebox_Heroes.Song;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Windows;
using System.Windows.Controls;

namespace Jukebox_Heroes.Server
{
    public class Listener
    {
        IPlaylistData playlist;
        public Listener(IPlaylistData playlist)
        {
            this.playlist = playlist;
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

                int counter = 0;

                while (true)
                {
                    counter++;
                    
                    ClientSocket = listener.Accept();
                    Console.WriteLine(counter + " Clients connected");

                    if (counter >= 2)
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            MainWindow joiner = new MainWindow();

                            List<SongData> list = playlist.getAllSongs();

                            for (int i = 0; i < list.Count; i++)
                            {
                                //Replace spaces in list[i].filePath with %20
                                Uri filePathUri = new Uri(list[i].filePath);
                                string filePathUriString = "http://localhost:8080/" + filePathUri.AbsolutePath;
                                Console.WriteLine("filePathUriString is " + filePathUriString);

                                Uri newUri = new Uri(filePathUriString);
                                Console.WriteLine("newUri is " + newUri);
                                SongData newSong = new SongData(list[i].filePath);
                                newSong.songUri = newUri;

                                joiner.playlist.addSong(newSong);
                            }

                            joiner.Join_Button.Visibility = Visibility.Hidden;
                            joiner.Host_Button.Visibility = Visibility.Hidden;
                            joiner.Add_Song_To_Playlist_Button.Visibility = Visibility.Hidden;
                            joiner.Remove_Song_From_Playlist_Button.Visibility = Visibility.Hidden;
                            joiner.Song_List_Box.Width = 188;
                            joiner.Show();
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
