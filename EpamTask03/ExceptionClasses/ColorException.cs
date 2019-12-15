using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask03.ExceptionClasses
{
    /// <summary>
    /// The class which represents exceptions class for the Colors
    /// </summary>
    public class ColorException : Exception
    {
        /// <summary>
        /// Constructor gets a descripiton string 
        /// </summary>
        /// <param name="message"></param>
        public ColorException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public ColorException()
        {
        }

    }
}
