using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask03.ExceptionClasses
{
    /// <summary>
    /// The class which represents exceptions class for the box
    /// </summary>
    public class BoxException : Exception
    {
        /// <summary>
        /// Constructor gets a description string
        /// </summary>
        public BoxException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public BoxException()
        {
        }


    }
}
