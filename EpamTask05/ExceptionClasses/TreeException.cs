using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05.ExceptionClasses
{
    /// <summary>
    /// The Exception Of tree class
    /// </summary>
    public class TreeException : Exception
    {
        public TreeException()
        {
        }

        public TreeException(string message) : base(message)
        {
        }


    }
}
