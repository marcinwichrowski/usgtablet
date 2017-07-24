using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace USG_tablet_UI
{
    static class GlobalSettings
    {

        //public static List<string> rodzajeBadan = new List<String>() { "USG", "Tomografia", "RTG" };
        public static Pacjent lastPacjentSelected = null;
        public static Badanie lastBadanieSelected = null;
        public static string beaconDistance = "not found";
        public static BeaconWindow beaconWindow = null;
        public static MainWindow mainWindow = null;
        public static string currentPage = null;
        public static string uScanIP = "192.168.1.100"; //"192.168.1.100";
        public static VideoHandler vh = null;
        public static TCPconnection conn = null;
        public static DispatcherTimer gainRefreshTimer = null;
        public static Boolean gainRequestCompleted = true;
        public static Boolean depthRequestCompleted = true;
        public static Boolean txRequestCompleted = true;
        public static Boolean videoServiceDisconnectFlag = true;
        public static TcpListener serverSocket = null;
        public static TcpClient clientSocket = null;
        public static TCPlistener paramListener = null;
        public static StreamReader reader;
        public static Boolean sideMenuVisible = false;
        public static MeasureWindow measureWin = null;
        public static PresetWindow presetWin = null;


        public static void disconnectSocketStream() {
            //GlobalSettings.gainRefreshTimer.Stop();
            GlobalSettings.vh.disconnect();
            GlobalSettings.conn.disconnect();
            GlobalSettings.gainRequestCompleted = true;
        }
    }
}
