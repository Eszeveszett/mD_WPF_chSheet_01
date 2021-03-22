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
    /// Interaction logic for BTN_01_Page.xaml
    /// </summary>
    public partial class BTN_01_Page : Page
    {
        List<string> advantages = new List<string>();

        public BTN_01_Page()
        {
            InitializeComponent();
        }

        private void BTN_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void BTN_advantages_Click(object sender, RoutedEventArgs e)
        {
            StreamReader adasr = new StreamReader("../../documents/Ipsum.txt");
            while (!adasr.EndOfStream)
            {
                string sor = adasr.ReadLine();

                advantages.Add(sor);
            }
            adasr.Close();
            LBO_advantages.ItemsSource = advantages;
        }
    }
}
