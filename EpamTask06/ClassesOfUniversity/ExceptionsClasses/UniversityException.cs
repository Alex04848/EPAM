using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity.ExceptionsClasses
{
    /// <summary>
    /// Common exception for all exception classes
    /// </summary>
    public class UniversityException : Exception
    {
        public UniversityException() : base()
        {
        }

        public UniversityException(string message) : base(message)
        {
        }

    }
}
