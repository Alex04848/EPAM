using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using EpamTask04.Exceptions;
using System.Net.Sockets;

namespace EpamTask04.ServerAndClient
{
    /// <summary>
    /// Client class
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Id for client that will be used on the server side
        /// </summary>
        static int IdCounter = 0;

        /// <summary>
        /// Send message to the server Event
        /// </summary>
        public event EventHandler<ServerMessageArgs> SendMessageEvent;

        /// <summary>
        /// Last Received message from the server
        /// </summary>
        public MessageReceiver LastReceivedMessage { get; private set; }

        /// <summary>
        /// TcpClient variable
        /// </summary>
        TcpClient tcpClient;

        /// <summary>
        /// Get ClientID Property
        /// </summary>
        public int ClientID => clientID;

        /// <summary>
        /// The property for port
        /// </summary>
        public int Port
        {

            get => port;

            set
            {
                if (value < 0)
                    throw new ClientException("Invalid Port");

                port = value;
            }
        }

        /// <summary>
        /// The property for IPAdress
        /// </summary>
        public string IPAdressForConnection
        {
            get => ip;

            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ClientException("Invalid IP adress!!!");

                ip = value;
            }

        }

        int port;
        string ip;
        int clientID;


        public Client(string ip, int port)
        {
            this.IPAdressForConnection = ip;
            this.Port = port;

            clientID = ++IdCounter;

            tcpClient = new TcpClient();
        }

        /// <summary>
        /// Connect to the server
        /// </summary>
        public void Connect()
        {
            tcpClient = new TcpClient(IPAdressForConnection, Port);
        }

        /// <summary>
        /// SendMessage To The Server
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            tcpClient = new TcpClient(IPAdressForConnection, Port);

            byte[] buffer = Encoding.Unicode.GetBytes(message);

            tcpClient.GetStream().Write(buffer, 0, buffer.Length);

            SendMessageEvent?.Invoke(this, new ServerMessageArgs(clientID));

            tcpClient.Close();
        }

        /// <summary>
        /// Receive Message from the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ReceiveMessage(object sender, EventArgs e)
        {
            byte[] buffer = new byte[256];

            tcpClient.GetStream().Read(buffer, 0, buffer.Length);

            string message = Encoding.Unicode.GetString(buffer);

            LastReceivedMessage = new MessageReceiver(message);

            tcpClient.Close();
        }
    }
}