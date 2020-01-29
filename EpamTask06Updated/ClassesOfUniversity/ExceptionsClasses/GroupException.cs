using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity.ExceptionsClasses
{
    /// <summary>
    /// Exception For Group class
    /// </summary>
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
