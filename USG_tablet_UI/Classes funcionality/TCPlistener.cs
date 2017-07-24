using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace USG_tablet_UI
{
    class TCPlistener
    {
        private int port;
        Byte[] bytes = new Byte[256];
        String data = null;
        StreamReader reader;

        public TCPlistener(int p)
        {
            this.port = p;
        }

        public void connect()
        {
            IPAddress[] ipTab = Array.FindAll(
                Dns.GetHostEntry(string.Empty).AddressList,
                a => a.AddressFamily == AddressFamily.InterNetwork);
            IPAddress ipAdd = ipTab[0];
            GlobalSettings.serverSocket = new TcpListener(ipAdd, this.port);
            GlobalSettings.clientSocket = default(TcpClient);
            GlobalSettings.serverSocket.Start();
            GlobalSettings.clientSocket = GlobalSettings.serverSocket.AcceptTcpClient();
            NetworkStream stream = GlobalSettings.clientSocket.GetStream();
            this.reader = new StreamReader(stream);
        }

        public string getData()         // metoda blokujaca, musi byc uruchamiana w nowym watku
        {
             string currData = this.reader.ReadLine();
             return currData;
        }
    }
}
