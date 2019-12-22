using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask04.Parser;

namespace EpamTask04.ServerAndClient
{
    /// <summary>
    /// The Class which contains message from the server and Translated Message
    /// </summary>
    public class MessageReceiver
    {

        /// <summary>
        /// Original Message
        /// </summary>
        public readonly string Message;

        /// <summary>
        /// Message in Translit
        /// </summary>
        public readonly string TranslatedMessage;

        public MessageReceiver(string message)
        {
            Message = message;
            TranslatedMessage = TranslitParser.ToTranslit(message);
        }

        /// <summary>
        /// Overrided method ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ($"{Message};{TranslatedMessage}");
    }
}
