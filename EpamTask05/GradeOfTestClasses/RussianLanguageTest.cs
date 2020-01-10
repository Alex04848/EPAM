using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05.GradeOfTestClasses
{
    /// <summary>
    /// The class which represents Russian Language Test
    /// </summary>
    public class RussianLanguageTest : GradeOfTest
    {
        public RussianLanguageTest(string fullName,int grade,DateTime date) : base(fullName, grade, date)
        {
            Subject = "Russian Language";
        }

        public RussianLanguageTest() : this(string.Empty,default,default)
        {
        }

    }
}
