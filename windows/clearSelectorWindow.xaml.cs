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

using mD_WPF_chSheet_01.userControl;
using mD_WPF_chSheet_01.pages;
using mD_WPF_chSheet_01.windows;

namespace mD_WPF_chSheet_01.windows
{
    /// <summary>
    /// Interaction logic for clearSelectorWindow.xaml
    /// </summary>
    public partial class clearSelectorWindow : Window
    {
        public clearSelectorWindow()
        {
            InitializeComponent();
        }

        private void BTN_Exit_Click(object sender, RoutedEventArgs e)
        {
            quickStartWindow qsw = new quickStartWindow();
            this.Close();
            qsw.Show();
        }

        private void BTN_0_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BTN_finaly_Click(object sender, RoutedEventArgs e)
        {
            characterStatisticWindow csw = new characterStatisticWindow();
            this.Close();
            csw.Show();
        }

        private void BTN_One_Click(object sender, RoutedEventArgs e)
        {
            FRM_incoming.Content = new BTN_01_Page();
        }
    }
}
