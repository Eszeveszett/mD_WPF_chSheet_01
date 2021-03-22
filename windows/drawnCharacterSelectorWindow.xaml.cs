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
using mD_WPF_chSheet_01.windows;

namespace mD_WPF_chSheet_01.windows
{
    /// <summary>
    /// Interaction logic for drawnCharacterSelectorWindow.xaml
    /// </summary>
    public partial class drawnCharacterSelectorWindow : Window
    {
        drawnCharacterPage dcp = new drawnCharacterPage();
        public drawnCharacterSelectorWindow()
        {
            InitializeComponent();
            FRM_Dcsw.Content = dcp;
        }

        private void BTN_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void BTN_Select_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
