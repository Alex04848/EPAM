using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05.GradeOfTestClasses
{
    /// <summary>
    /// The class which represents Physics Test
    /// </summary>
    public class PhysicsTest : GradeOfTest
    {
        public PhysicsTest(string fullName,int grade,DateTime date) : base(fullName,grade,date)
        {
            Subject = "Physics";
        }

        public PhysicsTest() : this(string.Empty,default,default)
        {
        }

    }
}
