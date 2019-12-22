using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask04.ServerAndClient
{
    /// <summary>
    /// The Class which contains the arguments for the server's message
    /// </summary>
    public class ServerMessageArgs : EventArgs
    {
        /// <summary>
        /// Client's ID 
        /// </summary>
        public readonly int ClientID;

        public ServerMessageArgs(int id)
        {
            ClientID = id;
        }

    }
}
