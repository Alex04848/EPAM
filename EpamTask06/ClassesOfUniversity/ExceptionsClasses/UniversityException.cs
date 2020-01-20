using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity.ExceptionsClasses
{
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
