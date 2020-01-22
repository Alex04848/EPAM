using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    public class SessionResults
    {
        public Student Student {

            get => student;

            set => student = value ?? throw new SessionResultsException("Incorrect value of student");

        }

        public Session Session {

            get => session;

            set => session = value ?? throw new SessionResultsException("Incorrect value of session");

        }

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


        public override int GetHashCode()
            => (student.GetHashCode() + session.GetHashCode() + averageGrade.GetHashCode());

        public override bool Equals(object obj)
                => (obj is SessionResults sessionResults && sessionResults.GetHashCode() == this.GetHashCode());

        public override string ToString() 
            => ($"{session.NameOfSession};{student.FullName};{averageGrade}");

    }
}
