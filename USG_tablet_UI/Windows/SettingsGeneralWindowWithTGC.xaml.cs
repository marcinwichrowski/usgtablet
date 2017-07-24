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
    /// Interaction logic for SettingsGeneralWindowWithTGC.xaml
    /// </summary>
    public partial class SettingsGeneralWindowWithTGC : Window
    {
        public SettingsGeneralWindowWithTGC()
        {
            InitializeComponent();
            GlobalSettings.sideMenuVisible = true;
            this.Left = 0;
            this.Top = 0;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.sideMenuVisible = false;
            this.Close();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            try
            {
                GlobalSettings.sideMenuVisible = false;
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnTGC1up_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg1u");
        }

        private void btnTGC1down_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg1d");
        }

        private void btnTGC2down_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg2d");
        }

        private void btnTGC2up_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg2u");
        }

        private void btnTGC3down_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg3d");
        }

        private void btnTGC3up_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg3u");
        }

        private void btnTGC4down_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg4d");
        }

        private void btnTGC4up_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg4u");
        }

        private void btnTGC5down_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg5d");
        }

        private void btnTGC5up_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg5u");
        }

        private void btnTGC6down_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg6d");
        }

        private void btnTGC6up_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg6u");
        }

        private void btnTGC7down_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg7d");
        }

        private void btnTGC7up_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg7u");
        }

        private void btnTGC8down_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg8d");
        }

        private void btnTGC8up_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tg8u");
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"c:\uscan.pdf");
        }

        private void btnPresets_Click(object sender, RoutedEventArgs e)
        {
            PresetWindow presetsWin = new PresetWindow();
            presetsWin.Owner = GlobalSettings.mainWindow;
            this.Close();
            presetsWin.Show();
        }

        private void btnSignalPalette_Click(object sender, RoutedEventArgs e)
        {
            signalPaletteWindow sigPalWin = new signalPaletteWindow();
            sigPalWin.Owner = GlobalSettings.mainWindow;
            sigPalWin.Show();
        }

    }
}
