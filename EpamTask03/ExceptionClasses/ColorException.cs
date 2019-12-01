using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask03.ExceptionClasses
{
    public class ColorException : Exception
    {
        public ColorException(string message) : base(message)
        {
        }

        public ColorException()
        {
        }

    }
}
