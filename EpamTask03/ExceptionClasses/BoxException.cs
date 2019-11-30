using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask03.ExceptionClasses
{
    public class BoxException : Exception
    {
        public BoxException(string message) : base(message)
        {
        }

        public BoxException()
        {
        }


    }
}
