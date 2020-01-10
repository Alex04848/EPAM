using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05.GradeOfTestClasses
{
    /// <summary>
    /// The class which represents Mathematics Test
    /// </summary>
    public class MathTest : GradeOfTest
    {
        public MathTest(string fullName,int grade,DateTime date) : base(fullName, grade, date)
        {
            Subject = "Mathematics";
        }

        public MathTest() : this(string.Empty, default, default)
        {
        }

    }
}
