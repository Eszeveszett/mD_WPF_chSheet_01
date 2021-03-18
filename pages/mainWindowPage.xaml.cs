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

using System.ComponentModel;

using mD_WPF_chSheet_01.pages;
using mD_WPF_chSheet_01.windows;

namespace mD_WPF_chSheet_01.pages
{
    /// <summary>
    /// Interaction logic for mainWindowPage.xaml
    /// </summary>
    public partial class mainWindowPage : Page
    {
        MainWindow fooldal = new MainWindow();
        public mainWindowPage()
        {
            InitializeComponent();
        }

        private void BTN_newGame_Click(object sender, RoutedEventArgs e)
        {
            quickStartWindow qsw = new quickStartWindow();
            qsw.ShowDialog();
        }

        private void BTN_quitGame_Click(object sender, RoutedEventArgs e)
        {
            //MessageBoxResult quitGame = MessageBox.Show("Bioztosan kilép?", "Mineral Dust End?", MessageBoxButton.YesNo);
            //switch (quitGame)
            //{
            //    case MessageBoxResult.Yes:
            //        Close();
            //        break;
            //    case MessageBoxResult.No:
            //        break;
            //}
            Application.Current.MainWindow.Close();
        }
    }
}
