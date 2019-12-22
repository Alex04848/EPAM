using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask04.Exceptions
{
    /// <summary>
    /// Exception Class for Server
    /// </summary>
    public class ServerException : Exception
    {
        public ServerException()
        {
        }

        public ServerException(string message) : base(message)
        {
        }

    }
}
