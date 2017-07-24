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
    /// Interaction logic for signalPaletteWindow.xaml
    /// </summary>
    public partial class signalPaletteWindow : Window
    {
        public signalPaletteWindow()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSine1_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("t125");
        }

        private void btnSine4_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("t425");
        }

        private void btnSine6_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("t625");
        }

        private void btnSine16_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("t162");
        }

        private void btnBarker20_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tb20");
        }

        private void btnBarker35_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("tb35");
        }

        private void btnChirp_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("chir");
        }

        private void btn15f_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("8b15");
        }

        private void btn175f_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("8b17");
        }

        private void btn20f_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("8b20");
        }

        private void btn30f_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("8b30");
        }

        private void btn8bitLinear_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.conn.send("8blg");
        }
    }
}
