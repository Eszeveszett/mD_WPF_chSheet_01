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
using System.IO;

using mD_WPF_chSheet_01.pages;
using mD_WPF_chSheet_01.windows;

namespace mD_WPF_chSheet_01
{
    /// <summary>
    /// Interaction logic for testWindow.xaml
    /// </summary>
    public partial class testWindow : Window
    {
        public testWindow()
        {
            InitializeComponent();
        }
        

        private void BTN_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTN_0_Click(object sender, RoutedEventArgs e)
        {
            FRM_incoming.Content = new BTN_00_Page();
        }

        private void BTN_1_Click(object sender, RoutedEventArgs e)
        {
            FRM_incoming.Content = new BTN_01_Page();
        }
    }
}
