using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity.ExceptionsClasses
{
    /// <summary>
    /// Exception For StudentException class
    /// </summary>
    public class StudentException : UniversityException
    {
        public StudentException() : base()
        {
        }

        public StudentException(string message) : base(message)
        {
        }

    }
}
