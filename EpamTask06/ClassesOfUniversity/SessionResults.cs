using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    /// <summary>
    /// This class is for getting Results from LINQ-to-Objects Query.
    /// The class descibes results of session.
    /// </summary>
    public class SessionResults
    {
        /// <summary>
        /// Student
        /// </summary>
        public Student Student {

            get => student;

            set => student = value ?? throw new SessionResultsException("Incorrect value of student");

        }

        /// <summary>
        /// Session
        /// </summary>
        public Session Session {

            get => session;

            set => session = value ?? throw new SessionResultsException("Incorrect value of session");

        }

        /// <summary>
        /// Average Grade
        /// </summary>
        public double AverageGrade {

            get => averageGrade;

            set
            {
                if (value < 0.0 || value > 10.0)
                    throw new SessionResultsException("Incorrect average grade");

                averageGrade = value;
            }

        }

        double averageGrade;

        Session session;

        Student student;

        public SessionResults() : this(new Student(),new Session(),default)
        {
        }

        public SessionResults(Student student,Session session,double averageGrade)
        {
            this.Session = session;
            this.Student = student;
            this.AverageGrade = averageGrade;
        }


        /// <summary>
        /// Overrided method GetHashCode which gets hash codes from all fields
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
            => (student.GetHashCode() + session.GetHashCode() + averageGrade.GetHashCode());

        /// <summary>
        /// Overrided method Equals which checks Equality of object obj and current object 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
                => (obj is SessionResults sessionResults && sessionResults.GetHashCode() == this.GetHashCode());

        /// <summary>
        /// Overrided ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString() 
            => ($"{session.NameOfSession};{student.FullName};{averageGrade}");

    }
}
