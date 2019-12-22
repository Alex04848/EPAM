using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using EpamTask04.Exceptions;


namespace EpamTask04.ServerAndClient
{
    /// <summary>
    /// The Server Class
    /// </summary>
    public class Server
    {
        /// <summary>
        /// The list that contains id and a message of Client 
        /// </summary>
        public List<KeyValuePair<int, string>> MessagesFromClients { get; private set; } = new List<KeyValuePair<int, string>>();

        /// <summary>
        /// Event for Sending a message to Client
        /// </summary>
        public event EventHandler SendMessageEvent;

        /// <summary>
        /// TcpListener of server
        /// </summary>
        TcpListener tcpListener;

        /// <summary>
        /// The list of clients
        /// </summary>
        List<Client> clients = new List<Client>();

        /// <summary>
        /// Port of server
        /// </summary>
        public int Port
        {

            get => port;

            private set
            {
                if (value < 0)
                    throw new ServerException("Invalid Port");

                port = value;
            }
        }

        /// <summary>
        /// IPAdress of server
        /// </summary>
        public string IPAdressOfServer
        {

            get => ip;

            private set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ServerException("Invalid IPAdress");

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

        /// <summary>
        /// Adding a client and initializing events
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(Client client)
        {
            clients.Add(client);

            client.SendMessageEvent += ReceiveMessage;
            SendMessageEvent += client.ReceiveMessage;
        }

        /// <summary>
        /// Start of a server
        /// </summary>
        public void StartServer() => tcpListener.Start();

        /// <summary>
        /// Send message to client
        /// </summary>
        /// <param name="message"></param>
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

        /// <summary>
        /// ReceiveMessage From Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ReceiveMessage(object sender, ServerMessageArgs e)
        {
            TcpClient forRead = tcpListener.AcceptTcpClient();

            byte[] buffer = new byte[256];

            forRead.GetStream().Read(buffer, 0, buffer.Length);

            string message = Encoding.Unicode.GetString(buffer);



            MessagesFromClients.Add(new KeyValuePair<int, string>(e.ClientID, message));
        }

        /// <summary>
        /// Stop Server
        /// </summary>
        public void StopServer() => tcpListener.Stop();
    }
}
