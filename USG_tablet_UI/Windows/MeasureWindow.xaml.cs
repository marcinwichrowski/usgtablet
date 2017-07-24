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
using System.Windows.Shapes;

namespace USG_tablet_UI
{
    /// <summary>
    /// Interaction logic for MeasureWindow.xaml
    /// </summary>
    public partial class MeasureWindow : Window
    {
        public MeasureWindow()
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
            GlobalSettings.conn.send("tabm");
            GlobalSettings.measureWin = this;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            GlobalSettings.measureWin = null;
            GlobalSettings.conn.send("tabb");
            GlobalSettings.conn.send("hide");
        }

        private void btnMarkerA_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("mrka");
            if (imgMarkerA.Visibility == System.Windows.Visibility.Visible)
            {
                imgMarkerA.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (imgMarkerA.Visibility == System.Windows.Visibility.Hidden)
            {
                imgMarkerA.Visibility = System.Windows.Visibility.Visible;
                imgMarkerB.Visibility = System.Windows.Visibility.Hidden;
                imgMarkerC.Visibility = System.Windows.Visibility.Hidden;
                imgMarkerD.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void btnMarkerB_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("mrkb");
            if (imgMarkerB.Visibility == System.Windows.Visibility.Visible)
            {
                imgMarkerB.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (imgMarkerB.Visibility == System.Windows.Visibility.Hidden)
            {
                imgMarkerA.Visibility = System.Windows.Visibility.Hidden;
                imgMarkerB.Visibility = System.Windows.Visibility.Visible;
                imgMarkerC.Visibility = System.Windows.Visibility.Hidden;
                imgMarkerD.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void btnMarkerC_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("mrkc");
            if (imgMarkerC.Visibility == System.Windows.Visibility.Visible)
            {
                imgMarkerC.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (imgMarkerC.Visibility == System.Windows.Visibility.Hidden)
            {
                imgMarkerA.Visibility = System.Windows.Visibility.Hidden;
                imgMarkerB.Visibility = System.Windows.Visibility.Hidden;
                imgMarkerC.Visibility = System.Windows.Visibility.Visible;
                imgMarkerD.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void btnMarkerD_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("mrkd");
            if (imgMarkerD.Visibility == System.Windows.Visibility.Visible)
            {
                imgMarkerD.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (imgMarkerD.Visibility == System.Windows.Visibility.Hidden)
            {
                imgMarkerA.Visibility = System.Windows.Visibility.Hidden;
                imgMarkerB.Visibility = System.Windows.Visibility.Hidden;
                imgMarkerC.Visibility = System.Windows.Visibility.Hidden;
                imgMarkerD.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            this.Focus();
        }

        private void btnMarkerUp_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("mkup");
        }

        private void btnMarkerDown_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("mkdn");
        }

        private void btnMarkerLeft_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("mkle");
        }

        private void btnMarkerRight_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("mkri");
        }

        private void btnMarkerClear_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("mrcl");
        }

    }
}
