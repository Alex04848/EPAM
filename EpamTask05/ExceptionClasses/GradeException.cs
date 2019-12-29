using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05.ExceptionClasses
{
    /// <summary>
    /// The Exception For GradeOfTest Class
    /// </summary>
    public class GradeException : ArgumentException
    {
        public GradeException()
        {
        }

        public GradeException(string message) : base(message)
        {
        }

    }
}
