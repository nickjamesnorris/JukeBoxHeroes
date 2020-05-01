using System;
using System.Net;
using System.Net.Sockets;

namespace Jukebox_Heroes.Server
{
    public class Client
    {
        public Client()
        {

        }

        public void StartClient(int port)
        {  
            try
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
  
                Socket client = new Socket(ipAddress.AddressFamily,SocketType.Stream, ProtocolType.Tcp);
  
                client.Connect(remoteEP); 
                Console.WriteLine("Client is Connected on port " + port);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
