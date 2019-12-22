using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask04.Parser;

namespace EpamTask04.ServerAndClient
{
    public class MessageReceiver
    {
        public readonly string Message;

        public readonly string TranslatedMessage;

        public MessageReceiver(string message)
        {
            Message = message;
            TranslatedMessage = TranslitParser.ToTranslit(message);
        }

        public override string ToString() => ($"{Message};{TranslatedMessage}");
    }
}
