﻿using System;
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
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.IO;
using System.Threading;

namespace USG_tablet_UI
{
    class VideoHandler
    {
        System.Windows.Controls.Image image;
        Socket server;
        Thread backgroundThread;

        public VideoHandler(System.Windows.Controls.Image im)
        {
            this.image = im;
        }

        public void connect(String ipAddr)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ipAddr), 9050);

            server = new Socket(AddressFamily.InterNetwork,
                                         SocketType.Stream, ProtocolType.Tcp);
            GlobalSettings.videoServiceDisconnectFlag = false;
            try
            {
                server.Connect(ipep);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Unable to connect to server.");
                Console.WriteLine(ex.ToString());
            }
            backgroundThread = new Thread(delegate()
            {
                connect(server);
            });
            backgroundThread.IsBackground = true;
            backgroundThread.Start();
        }

        public void disconnect()
        {
            GlobalSettings.videoServiceDisconnectFlag = true;
        }

        private void connect(Socket server)
        {
            byte[] data = new byte[1024];

            while (GlobalSettings.videoServiceDisconnectFlag == false)
            {
                data = ReceiveVarData(server);
                MemoryStream ms = new MemoryStream(data);
                try
                {

                    Application.Current.Dispatcher.Invoke((Action)(() =>
                    {
                        try
                        {
                            BitmapImage bmi = new BitmapImage();
                            bmi.BeginInit();
                            bmi.StreamSource = ms;
                            bmi.EndInit();
                            this.image.Source = bmi;
                        }
                        catch (Exception ex)
                        {

                        }
                        
                    }));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("something broke: " + e.ToString());
                }

            }

            try
            {
                server.Shutdown(SocketShutdown.Both);
                server.Disconnect(true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something broke: " + e.ToString());
            }


        }


        private static byte[] ReceiveVarData(Socket s)
        {
            int total = 0;
            int recv;
            byte[] datasize = new byte[4];

            recv = s.Receive(datasize, 0, 4, 0);
            int size = BitConverter.ToInt32(datasize, 0);
            int dataleft = size;
            byte[] data = new byte[size];


            while (total < size)
            {
                recv = s.Receive(data, total, dataleft, 0);
                if (recv == 0)
                {
                    break;
                }
                total += recv;
                dataleft -= recv;
            }
            return data;
        }

    }
}
