using Jukebox_Heros.SongLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jukebox_Heros
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow() {
            InitializeComponent();

            SongUpload songUpload = new SongUpload(Song_List_Box);
            Upload_Song_Button.Click += songUpload.UploadSong;
            Remove_Song_Button.Click += songUpload.Remove_Song_Click;

        }
        
    }
}
