using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace EpamTask04.ServerAndClient
{
    public class Server
    {
        public List<KeyValuePair<int, string>> MessagesFromClients { get; private set; } = new List<KeyValuePair<int, string>>();


        public event EventHandler SendMessageEvent;

        TcpListener tcpListener;

        List<Client> clients = new List<Client>();

        public int Port
        {

            get => port;

            private set
            {
                //I should create my own exception class
                if (value < 0)
                    throw new ArgumentOutOfRangeException();

                port = value;
            }
        }

        public string IPAdressOfServer
        {

            get => ip;

            private set
            {
                //I should create my own exception class
                if (String.IsNullOrEmpty(value))
                    throw new FormatException();

                ip = value;
            }

        }

        string ip;
        int port;

        public Server(string ip, int port)
        {

            this.IPAdressOfServer = ip;
            this.Port = port;


            tcpListener = new TcpListener(IPAddress.Parse(IPAdressOfServer), Port);
        }

        public void AddClient(Client client)
        {
            clients.Add(client);

            client.SendMessageEvent += ReceiveMessage;
            SendMessageEvent += client.ReceiveMessage;
        }

        public void StartServer() => tcpListener.Start();

        public void SendMessage(string message)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(message);

            clients.ForEach(client =>
            {
                client.Connect();

                tcpListener.AcceptTcpClient().GetStream().Write(buffer, 0, buffer.Length);
            });

            SendMessageEvent?.Invoke(this, EventArgs.Empty);
        }

        public void ReceiveMessage(object sender, ServerMessageArgs e)
        {
            TcpClient forRead = tcpListener.AcceptTcpClient();

            byte[] buffer = new byte[256];

            forRead.GetStream().Read(buffer, 0, buffer.Length);

            string message = Encoding.Unicode.GetString(buffer);



            MessagesFromClients.Add(new KeyValuePair<int, string>(e.ClientID, message));
        }

        public void StopServer() => tcpListener.Stop();
    }
}
