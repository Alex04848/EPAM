using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    public class StudentsGrade
    {
        public int Id { get; set; }


        public int Grade
        {
            get => grade;

            set
            {
                if (value < 0 || value > 10)
                    throw new GradeException("Incorrect value of a grade!!!");

                grade = value;
            }
        }

        public Student Student
        {
            get => student;

            set => student = value ?? throw new GradeException("Incorrect student's value!!!");   
        }

        public Subject Subject
        {
            get => subject;
            
            set => subject = value ?? throw new GradeException("Incorrect subject's value!!!");
        }

        public Session Session
        {
            get => session;

            set => session = value ?? throw new GradeException("Incorrect value for session!!!");
        }

        int grade;

        Student student;

        Subject subject;

        Session session;


        public StudentsGrade() : this(default,(new Student()),(new Subject()),(new Session()))
        {

        }

        public StudentsGrade(int grade,Student student,Subject subject,Session session)
        {
            this.Grade = grade;
            this.Student = student;
            this.Subject = subject;
            this.Session = session;
        }



        public override int GetHashCode()
            => (grade.GetHashCode() + student.GetHashCode() + subject.GetHashCode());

        public override bool Equals(object obj)
              => (obj is StudentsGrade studentsGrade && studentsGrade.GetHashCode() == this.GetHashCode());

        public override string ToString()
              => ($"{Student.FullName};{Subject.NameOfSubject};{Grade};{Session.NameOfSession}");

    }
}
