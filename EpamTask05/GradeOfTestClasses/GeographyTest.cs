using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05.GradeOfTestClasses
{
    /// <summary>
    /// The class which represents Geography Test
    /// </summary>
    public class GeographyTest : GradeOfTest
    {
        public GeographyTest(string fullName,int grade,DateTime date) : base(fullName,grade,date)
        {
            Subject = "Geography";
        }

        public GeographyTest() : this(string.Empty, default, default)
        {
        }

    }
}
