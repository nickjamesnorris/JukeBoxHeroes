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
                               Uri filePathUri = new Uri(list[i].filePath);
                               string filePathUriString = "http://" + GetIPAddress().ToString() + ":8080/" + filePathUri.AbsolutePath;
                               Console.WriteLine("filePathUriString is " + filePathUriString);

                               Uri newUri = new Uri(filePathUriString);
                               Console.WriteLine("newUri is " + newUri);
                               SongData newSong = new SongData(list[i].filePath);
                               newSong.songUri = newUri;

                               joiner.playlist.addSong(newSong);
                            }

                            joiner.Hosting_Label.Content = "You are listening to " + GetIPAddress().ToString() + ":" + portNum + "'s playlist";
                            joiner.Hosting_Label.Visibility = Visibility.Visible;
                            joiner.Create_Playlist_Label.Visibility = Visibility.Hidden;
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
