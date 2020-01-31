using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity.ExceptionsClasses
{
    /// <summary>
    /// Speciality Exception
    /// </summary>
    public class SpecialityException : UniversityException
    {
        public SpecialityException()
        {
        }

        public SpecialityException(string message) : base(message)
        {
        } 

    }
}
