using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask04.ServerAndClient
{
    public class ServerMessageArgs : EventArgs
    {
        public readonly int ClientID;

        public ServerMessageArgs(int id)
        {
            ClientID = id;
        }

    }
}
