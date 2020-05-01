using Jukebox_Heroes.Playlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Jukebox_Heroes.Server
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ServerWindow : Window
    {
        public int portNum;
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public IPlaylistData playlist;
        public ISongLibraryData songLibrary;
        public ListBox play;
        public Label hosting;
        public string hostName;

        public ServerWindow(IPlaylistData playlist, Label hosting, ISongLibraryData songLibrary)
        {
            InitializeComponent();
            this.portNum = 1000;
            hostName = Dns.GetHostName();
            Server_IP_txtbox.Text = Dns.GetHostByName(hostName).AddressList[0].ToString();
            Server_IP_txtbox.IsEnabled = false;
            this.playlist = playlist;
            this.songLibrary = songLibrary;
            this.hosting = hosting;
        }

        private void Button_Host_Click(object sender, RoutedEventArgs e)
        {
            
           if (String.IsNullOrEmpty(Port_Number_txtbox.Text))
            {
                setPortNum(8888);
            }
            else
            {
                setPortNum(int.Parse(Port_Number_txtbox.Text));
            }

            hosting.Content = "Hosting on " + Server_IP_txtbox.Text + ":" + portNum;
            hosting.Visibility = Visibility.Visible;

            Server_Start();

            
            MediaServer mediaServer = new MediaServer("http://+:8080/", songLibrary);
            mediaServer.Run();
            Close();
        }

        private async void Server_Start()
        {
            Port_Number_txtbox.Text = this.portNum.ToString();
            Port_Number_txtbox.IsEnabled = false;
            Listener listen = new Listener(this.playlist);

            await Task.Run(() =>
            {
                listen.ExecuteServer(portNum);
            });

        }
        private void setPortNum(int num)
        {
            this.portNum = num;
        }
        
    }
}

