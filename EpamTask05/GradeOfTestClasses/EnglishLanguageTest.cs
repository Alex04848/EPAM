using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05.GradeOfTestClasses
{
    /// <summary>
    /// The class which represents English Language Test
    /// </summary>
    public class EnglishLanguageTest : GradeOfTest
    {
        public EnglishLanguageTest(string fullName,int grade,DateTime date) : base(fullName, grade, date)
        {
            Subject = "English Language";
        }

        public EnglishLanguageTest() : this(string.Empty,default,default)
        {
        }

    }
}
