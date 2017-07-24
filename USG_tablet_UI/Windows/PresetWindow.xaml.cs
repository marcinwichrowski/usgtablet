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
    /// Interaction logic for PresetWindow.xaml
    /// </summary>
    public partial class PresetWindow : Window
    {
        public PresetWindow()
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
            GlobalSettings.presetWin = this;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            GlobalSettings.presetWin = null;
        }
    }
}
