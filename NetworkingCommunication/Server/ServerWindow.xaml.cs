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

using System.Collections.ObjectModel;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace mD_WPF_chSheet_01.NetworkingCommunication.Server
{
    /// <summary>
    /// Interaction logic for ServerWindow.xaml
    /// </summary>
    public partial class ServerWindow : Window
    {
        public static ObservableCollection<Clients> clientList = new ObservableCollection<Clients>();

        public class Clients
        {
            public Socket client { get; set; }
            public int clientId { get; set; }

            public Clients()
            {

            }
            public Clients(Socket client, int clientId)

            {
                this.client = client;
                this.clientId = clientId;
            }
        }

        public ServerWindow()
        {
            InitializeComponent();
            
        }
        
        private void BTN_ServerConnection_Click(object sender, RoutedEventArgs e)
        {
            //  Ip cím és portszám
            string IpAddress = "127.0.0.1";
            int port = 8000;

            // Type of commu ...nism? ...nication?
            Socket serverListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpAddress), port);
            serverListener.Bind(endPoint);

            serverListener.Listen(10);
            TBO_Server.Text = "The server wait to Connection";

            Socket clientSocket = null;
            int szamlalo = 0;

            ServerWindow prg = new ServerWindow();

            while (true)
            {
                clientSocket = serverListener.Accept();
                TBO_Server.Text = "The Client Connecting";

                Packet sp = new Packet();
                sp.message = "";
                sp.packetType = "newId";
                sp.packetID = szamlalo;

                clientSocket.Send(sp.toBytes());

                clientList.Add(new Clients(clientSocket, szamlalo));

                Thread userThread = new Thread(new ThreadStart(() => prg.user(clientSocket)));
                userThread.Start();

                szamlalo++;
            }
        }
        public void user(Socket client)
        {
            while (true)
            {
                try
                {
                    byte[] message = new byte[2048];
                    int size = client.Receive(message);

                    TBO_ServerMessage.Text = Encoding.UTF8.GetString(message, 0, size);

                    Packet sp = new Packet(message);

                    if (sp.packetType == "send")
                    {
                        broadcastMessage(message, size);
                    }
                    if (sp.packetType == "close")
                    {
                        clientList.Remove(
                            (from x in clientList
                             where x.clientId == sp.packetID
                             select x).FirstOrDefault()
                            );
                        client.Close();
                        return;
                    }

                }
                catch (Exception)
                {

                    return;
                }
            }
        }

        private void broadcastMessage(byte[] message, int size)
        {
            foreach (var item in clientList)
            {
                item.client.Send(message, 0, size, SocketFlags.None);
            }
        }

        

        private void BTN_ServerDisconnect_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BTN_CloseConnection_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
