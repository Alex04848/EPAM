using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity.ExceptionsClasses
{

    public class GradeException : UniversityException
    {
        public GradeException() : base()
        {
        }

        public GradeException(string message) : base(message)
        {
        }

    }
}
