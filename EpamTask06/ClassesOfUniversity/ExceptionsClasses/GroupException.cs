using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity.ExceptionsClasses
{
    public class GroupException : UniversityException
    {
        public GroupException() : base()
        {
        }

        public GroupException(string message) : base(message)
        {
        }

    }
}
