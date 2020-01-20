using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity.ExceptionsClasses
{
    public class SubjectException : UniversityException
    {
        public SubjectException() : base()
        {
        }

        public SubjectException(string message) : base(message)
        {
        }

    }
}
