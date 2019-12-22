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
    public class Client
    {
        static int IdCounter = 0;


        public event EventHandler<ServerMessageArgs> SendMessageEvent;

        public MessageReceiver LastReceivedMessage { get; private set; }


        TcpClient tcpClient;

        public int ClientID => clientID;
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

        public void Connect()
        {
            tcpClient = new TcpClient(IPAdressForConnection, Port);
        }

        public void SendMessage(string message)
        {
            tcpClient = new TcpClient(IPAdressForConnection, Port);

            byte[] buffer = Encoding.Unicode.GetBytes(message);

            tcpClient.GetStream().Write(buffer, 0, buffer.Length);

            SendMessageEvent?.Invoke(this, new ServerMessageArgs(clientID));

            tcpClient.Close();
        }

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