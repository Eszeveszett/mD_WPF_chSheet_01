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

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace mD_WPF_chSheet_01.NetworkingCommunication.Client
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        //  127.0.0.1
        //  193.225.219.30
        //  192.168.1.100
        string nev;
        string IpAddress = "192.168.1.100";
        int port = 8000;
        int id;

        public Socket clientSocket;
        public Thread serverListener;

        public ClientWindow()
        {
            InitializeComponent();
            BTN_Kuldes.IsEnabled = false;
        }


        private void BTN_Kapcsolodas_Click(object sender, RoutedEventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IpAddress), port);
            try
            {
                clientSocket.Connect(ep);
                LBL_Kapcsolodas.Content = "Sikerült Kapcsolódni";
                nev = TBO_Nev.Text;

                serverListener = new Thread(getMessage);
                serverListener.Start();

                BTN_Kapcsolodas.IsEnabled = false;
                BTN_Kuldes.IsEnabled = true;
            }
            catch (Exception)
            {
                LBL_Kapcsolodas.Content = "Sikertelen kapcsolódás";
            }
        }

        private void getMessage()
        {
            byte[] msgFromserver;
            int size;

            while (true)
            {
                try
                {
                    msgFromserver = new byte[1024];
                    size = clientSocket.Receive(msgFromserver);

                    Packet p = new Packet(msgFromserver);

                    if (p.packetType == "newID")
                    {
                        id = p.packetID;
                    }
                    if (size > 0)
                    {
                        // Jött adat
                        dataManager(p);
                    }
                }
                catch (Exception)
                {
                    connectionLost();
                }
            }
        }

        private void connectionLost()
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                LBL_Kapcsolodas.Content = "Kapcsolat megszakadt";
                BTN_Kapcsolodas.IsEnabled = true;
                BTN_Kuldes.IsEnabled = false;
            }));
            clientSocket.Close();
            serverListener.Abort();
        }

        private void dataManager(Packet p)
        {   //  Ő csinálja a szálak közti kommunikációt
            this.Dispatcher.Invoke(new Action(() => {
                LBO_Uzenetek.Items.Add(p.name + " -> " + p.message);

            }));
            //;
        }

        private void BTN_Kuldes_Click(object sender, RoutedEventArgs e)
        {
            Packet p = new Packet();
            p.message = TBO_Uzenet.Text;
            p.name = nev;
            p.packetType = "send";
            p.packetID = id;

            clientSocket.Send(p.toBytes());
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Packet p = new Packet();
            p.message = "Kapcsolat Bontva";
            p.name = nev;
            p.packetType = "Close";
            p.packetID = id;

            clientSocket.Send(p.toBytes());
            serverListener.Abort();
        }

        private void BTN_Disconnect_Click(object sender, RoutedEventArgs e)
        {
            clientSocket.Close();
            serverListener.Abort();
            Close();
        }
    }
}
