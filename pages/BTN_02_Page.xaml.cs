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

using System.IO;

namespace mD_WPF_chSheet_01.pages
{
    /// <summary>
    /// Interaction logic for BTN_02_Page.xaml
    /// </summary>
    public partial class BTN_02_Page : Page
    {
        public BTN_02_Page()
        {
            InitializeComponent();
        }
        private void BTN_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void BTN_one_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("../../documents/Ipsum.txt");
            while (!sr.EndOfStream)
            {
                string szo = sr.ReadLine();
                TBO_leftUpperBox.Text = szo;
            }
        }

        private void BTN_two_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("../../documents/Lorem.txt");
            while (!sr.EndOfStream)
            {
                string szo = sr.ReadLine();
                TBO_rightUpperBox.Text = szo;
            }
        }
    }
}
