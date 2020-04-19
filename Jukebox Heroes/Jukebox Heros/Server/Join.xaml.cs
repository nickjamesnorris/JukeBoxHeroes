using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Jukebox_Heroes.PlayerUI;
using Jukebox_Heroes.Server;

namespace Jukebox_Heroes.Server
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Join : Window
    {

        public Join()
        {
            InitializeComponent();
        }

        private void Join_Button_Click(object sender, RoutedEventArgs e)
        {
            int portNum = 0;
            if (String.IsNullOrEmpty(Port_Number.Text))
            {
                portNum = 8888;
            }
            else
            {
                portNum = int.Parse(Port_Number.Text);
            }

            Client client = new Client();
            client.StartClient(portNum);
            Close();
        }

        public void joinServer(int p)
        {


        }
    }
}
