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

namespace mD_WPF_chSheet_01.pages
{
    /// <summary>
    /// Interaction logic for defaultPage.xaml
    /// </summary>
    public partial class defaultPage : Page
    {
        public defaultPage()
        {
            InitializeComponent();
        }

        private void BTN_AttributionOne_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
