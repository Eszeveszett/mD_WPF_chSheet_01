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

using mD_WPF_chSheet_01.pages;
using mD_WPF_chSheet_01.pages.selectorPage;

namespace mD_WPF_chSheet_01.windows
{
    /// <summary>
    /// Interaction logic for quickStartWindow.xaml
    /// </summary>
    public partial class quickStartWindow : Window
    {
        public quickStartWindow()
        {
            InitializeComponent();
        }

        private void BTN_newCharacter_Click(object sender, RoutedEventArgs e)
        {
            clearSelectorWindow csw = new clearSelectorWindow();
            this.Close();
            csw.ShowDialog();
        }

        private void BTN_readyCharacter_Click(object sender, RoutedEventArgs e)
        {
            drawnCharacterSelectorWindow dcsw = new drawnCharacterSelectorWindow();
            dcsw.ShowDialog();
        }

        private void BTN_back_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mw = new MainWindow();
            this.Close();
            //mw.Show();
        }
    }
}
