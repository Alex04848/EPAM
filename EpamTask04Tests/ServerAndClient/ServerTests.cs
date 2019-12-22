using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask04.ServerAndClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EpamTask04.ServerAndClient.Tests
{
    [TestClass()]
    public class ServerAndClientsTests
    {
        /// <summary>
        /// Method that performs cheking correctness of sending message to the client 
        /// and checking that message have been translated correctly
        /// </summary>
        /// <param name="ipAdress"></param>
        /// <param name="port"></param>
        /// <param name="russianMessage"></param>
        /// <param name="translatedMessage"></param>
        [DataTestMethod()]
        [DataRow("127.0.0.1", 255, "Привет, мир!!!", "Privet, mir!!!")]
        [DataRow("127.0.0.1", 255, "Новый год", "Novyj god")]
        [DataRow("127.0.0.1", 255, "дотНет", "dotNet")]
        public void SendToAClient(string ipAdress, int port, string russianMessage, string translatedMessage)
        {
            //arrange
            Server server = new Server(ipAdress, port);
            Client client = new Client(ipAdress, port);
            server.AddClient(client);

            //action
            Task task = new Task(() =>
            {
                server.StartServer();
                server.SendMessage(russianMessage);
            });
            task.Start();
            task.Wait();

            Debug.WriteLine(client.LastReceivedMessage);

            server.StopServer();

            //assert
            Assert.IsTrue(client.LastReceivedMessage.Message.Contains(russianMessage) && client.LastReceivedMessage.TranslatedMessage.Contains(translatedMessage));
        }


        /// <summary>
        /// Method that checks correctness of sending to the server 
        /// </summary>
        /// <param name="ipAdress"></param>
        /// <param name="port"></param>
        /// <param name="firstMessage"></param>
        /// <param name="secondMessage"></param>
        [DataTestMethod()]
        [DataRow("127.0.0.1", 255, "MessageFirst", "MessageSecond")]
        [DataRow("127.0.0.1", 255, "RandomMessage", "RandomMessage")]
        [DataRow("127.0.0.1", 255, "FirstValue", "SecValue")]
        public void SendToAServer(string ipAdress, int port, string firstMessage, string secondMessage)
        {
            //arrange
            Server server = new Server(ipAdress, port);
            Client client = new Client(ipAdress, port);
            Client clientSec = new Client(ipAdress, port);
            server.AddClient(client);
            server.AddClient(clientSec);

            //action
            Task task = new Task(() => {
                server.StartServer();
            });
            task.Start();
            task.Wait();

            client.SendMessage(firstMessage);
            clientSec.SendMessage(secondMessage);

            server.StopServer();


            bool check = server.MessagesFromClients
                .All(t => (t.Key == client.ClientID && t.Value.Contains(firstMessage)) || (t.Key == clientSec.ClientID && t.Value.Contains(secondMessage)));


            //assert
            Assert.IsTrue(check);
        }

    }
}