using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask05.ExceptionClasses;

namespace EpamTask05.GradeOfTestClasses
{
    /// <summary>
    /// The class which represents grade of a test
    /// </summary>
    public class GradeOfTest
    {
        /// <summary>
        /// Full name of a student
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Student's grade
        /// </summary>
        public int Grade {

            get => grade;

            set
            {
                if (value >= 0 && value <= 10)
                    grade = value;
                else
                    throw new GradeException("The grade can't be more than ten and less than zero!!!");
            }
        }

        /// <summary>
        /// The subject of a test
        /// </summary>
        public string Subject { get; protected set; }

        /// <summary>
        /// The date
        /// </summary>
        public DateTime Date { get; set; }

        int grade;


        public GradeOfTest(string fullName,int grade,DateTime date)
        {
            this.FullName = fullName;
            this.Grade = grade;
            this.Date = date;
        }

        public GradeOfTest() : this(string.Empty, default, default)
        {
        }


        /// <summary>
        /// Overrided method GetHashCode
        /// </summary>
        /// <param name="treeNodeFirst"></param>
        /// <param name="treeNodeSecond"></param>
        /// <returns></returns>
        public override int GetHashCode()
                => (FullName.GetHashCode() + Grade.GetHashCode() + Subject.GetHashCode() + Date.GetHashCode());

        /// <summary>
        /// Overrided method Equals
        /// </summary>
        /// <param name="treeNodeFirst"></param>
        /// <param name="treeNodeSecond"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
                => (obj is GradeOfTest gradeOfTest && gradeOfTest.GetType() == this.GetType() && this.GetHashCode() == gradeOfTest.GetHashCode());

        /// <summary>
        /// Overrided method ToString
        /// </summary>
        /// <param name="treeNodeFirst"></param>
        /// <param name="treeNodeSecond"></param>
        /// <returns></returns>
        public override string ToString() => ($"{FullName};{Subject};{Grade};{Date.ToString("dd/MM/yy")}");
    }
}
