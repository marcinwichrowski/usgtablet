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
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace USG_tablet_UI
{
    /// <summary>
    /// Logika interakcji dla klasy Urzadzenia.xaml
    /// </summary>
    public partial class Urzadzenia : Page
    {

        public Urzadzenia()
        {
            InitializeComponent();
            GlobalSettings.currentPage = "Urzadzenia";
            GlobalSettings.vh = new VideoHandler(imgVideo);
            GlobalSettings.vh.connect(GlobalSettings.uScanIP);          
            GlobalSettings.conn = new TCPconnection(GlobalSettings.uScanIP, 13000);
            //GlobalSettings.paramListener = new TCPlistener(12000);
            //GlobalSettings.paramListener.connect();
            GlobalSettings.reader = new StreamReader(GlobalSettings.clientSocket.GetStream());
            /*if (GlobalSettings.gainRefreshTimer == null)
            {            
                GlobalSettings.gainRefreshTimer = new DispatcherTimer();
                GlobalSettings.gainRefreshTimer.Tick += new EventHandler(refreshGain);
                GlobalSettings.gainRefreshTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);

            }*/
            //GlobalSettings.gainRefreshTimer.Start(); 
            refreshDepth();
            Thread.Sleep(200);
            refreshTx();
            Thread.Sleep(200);
            refreshGain();
            Thread.Sleep(200);
        }

        private void btnFreeze_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("frze");
        }

        private void btnGainUp_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("gaup");
            refreshGain();
        }

        private void btnGainDown_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("gadn");
            refreshGain();
        }

        /*private void refreshGain(object sender, EventArgs e)
        {
            if (GlobalSettings.gainRequestCompleted == true)
            {
                GlobalSettings.gainRequestCompleted = false;
                GlobalSettings.conn.send("ggai");
                new Thread(() =>
                {
                    try
                    {
                        Thread.CurrentThread.IsBackground = true;
                        string content = GlobalSettings.reader.ReadLine();
                        this.lblGain.Dispatcher.Invoke((Action)delegate { lblGain.Content = content; });
                        GlobalSettings.gainRequestCompleted = true;
                    }
                    catch (Exception ex) { GlobalSettings.gainRequestCompleted = true; };
                }).Start();
            }
        }*/

        private void refreshGain()
        {
            if (GlobalSettings.gainRequestCompleted == true)
            {
                GlobalSettings.gainRequestCompleted = false;
                GlobalSettings.conn.send("ggai");
                new Thread(() =>
                {
                    try
                    {
                        Thread.CurrentThread.IsBackground = true;
                        string content = GlobalSettings.reader.ReadLine();
                        this.lblGain.Dispatcher.Invoke((Action)delegate { lblGain.Content = content; });
                        GlobalSettings.gainRequestCompleted = true;
                    }
                    catch (Exception ex) { GlobalSettings.gainRequestCompleted = true; };
                }).Start();
            }
        }

        private void refreshDepth()
        {
            if (GlobalSettings.depthRequestCompleted == true)
            {
                GlobalSettings.depthRequestCompleted = false;
                GlobalSettings.conn.send("gimr");
                new Thread(() =>
                {
                    try
                    {
                        Thread.CurrentThread.IsBackground = true;
                        string content = GlobalSettings.reader.ReadLine();
                        this.lblDepth.Dispatcher.Invoke((Action)delegate { lblDepth.Content = content; });
                        GlobalSettings.depthRequestCompleted = true;
                    }
                    catch (Exception ex) { GlobalSettings.depthRequestCompleted = true; };
                }).Start();
            }
        }

        private void refreshTx()
        {
            if (GlobalSettings.txRequestCompleted == true)
            {
                GlobalSettings.txRequestCompleted = false;
                GlobalSettings.conn.send("ggtx");
                new Thread(() =>
                {
                    try
                    {
                        Thread.CurrentThread.IsBackground = true;
                        string content = GlobalSettings.reader.ReadLine();
                        this.lblTx.Dispatcher.Invoke((Action)delegate { lblTx.Content = content; });
                        GlobalSettings.txRequestCompleted = true;
                    }
                    catch (Exception ex) { GlobalSettings.txRequestCompleted = true; };
                }).Start();
            }
        }

        private void btnDepthUp_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("arup");
            refreshDepth();
            
        }

        private void btnDepthDown_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("ardn");
            refreshDepth();
        }

        private void btnSaveImage_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("save");
        }

        private void btnEndExam_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.disconnectSocketStream();
            if (GlobalSettings.measureWin != null)
            {
                GlobalSettings.measureWin.Close();
            }

            if (GlobalSettings.presetWin != null)
            {
                GlobalSettings.presetWin.Close();
            }
            this.NavigationService.Navigate(new Uri("Pages\\StartPage.xaml", UriKind.Relative));
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalSettings.sideMenuVisible == false)
            {
                SettingsGeneralWindowWithTGC win = new SettingsGeneralWindowWithTGC();
                win.Show();
            }
            else
            {
                //GlobalSettings.settingsGeneralTGCWind.Close();
                //GlobalSettings.sideMenuVisible = false;
            }

        }

        private void btnMeasure_Click(object sender, RoutedEventArgs e)
        {
            MeasureWindow measureWin = new MeasureWindow();
            measureWin.Owner = Window.GetWindow(this);
            measureWin.Show();
        }
    }
}
