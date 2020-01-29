using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity.ExceptionsClasses
{
    /// <summary>
    /// Exception For StudentsGrade class
    /// </summary>
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
