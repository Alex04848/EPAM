using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    /// <summary>
    /// Class That describes Students Grade table in database
    /// </summary>
    public class StudentsGrade
    {
        /// <summary>
        /// Int property for Id from DB
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Grade
        /// </summary>
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

        /// <summary>
        /// Student
        /// </summary>
        public Student Student
        {
            get => student;

            set => student = value ?? throw new GradeException("Incorrect student's value!!!");   
        }

        /// <summary>
        /// Subject
        /// </summary>
        public Subject Subject
        {
            get => subject;
            
            set => subject = value ?? throw new GradeException("Incorrect subject's value!!!");
        }

        /// <summary>
        /// Session
        /// </summary>
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


        /// <summary>
        /// Overrided method GetHashCode which gets hash codes from all fields
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
            => (grade.GetHashCode() + student.GetHashCode() + subject.GetHashCode());

        /// <summary>
        /// Overrided method Equals which checks Equality of object obj and current object 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
              => (obj is StudentsGrade studentsGrade && studentsGrade.GetHashCode() == this.GetHashCode());

        /// <summary>
        /// Overrided ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
              => ($"{Student.FullName};{Subject.NameOfSubject};{Grade};{Session.NameOfSession}");

    }
}
