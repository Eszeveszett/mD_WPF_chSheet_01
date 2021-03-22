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

using mD_WPF_chSheet_01.NetworkingCommunication.Client;
using mD_WPF_chSheet_01.NetworkingCommunication.Server;

namespace mD_WPF_chSheet_01.NetworkingCommunication
{
    /// <summary>
    /// Interaction logic for ConnectionSelectorWindow.xaml
    /// </summary>
    public partial class ConnectionSelectorWindow : Window
    {
        public ConnectionSelectorWindow()
        {
            InitializeComponent();
        }

        private void BTN_Server_Click(object sender, RoutedEventArgs e)
        {
            ServerWindow sw = new ServerWindow();
            sw.Show();
            this.Close();
        }

        private void BTN_Client_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow cw = new ClientWindow();
            cw.Show();
            this.Close();
        }

        private void BTN_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
