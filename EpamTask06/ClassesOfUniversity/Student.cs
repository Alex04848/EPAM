using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    /// <summary>
    /// Class That describes Student table in database
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Int property for Id from DB
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Full Name of Student
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        public DateTime DateOfBirth {

            get => dateOfBirth;

            set
            {
                if ((DateTime.Now - value).Days / 365 > 100)
                    throw new StudentException("Incorrect date of Birth");

                dateOfBirth = value;
            }

        }

        /// <summary>
        /// Group of Student
        /// </summary>
        public Group StudentGroup {

            get => group;

            set => group = value ?? throw new StudentException("Incorrect value of a group!!!");

        }

        /// <summary>
        /// Gender
        /// </summary>
        public Gender Gender
        {
            get => gender;

            set
            {
                if (value != Gender.Male && value != Gender.Female)
                    throw new StudentException("Incorrect Gender of a student!!!");

                gender = value;
            }
        }

        /// <summary>
        /// Property for getting age
        /// </summary>
        public int GetAge => ((DateTime.Now - DateOfBirth).Days / 365);



        Group group;

        DateTime dateOfBirth;

        Gender gender;


        public Student() : this(string.Empty,DateTime.Now,(new Group()),default)
        {
        }

        public Student(string fullName,DateTime dateOfBirth,Group group,Gender gender)
        {
            this.FullName = fullName;
            this.DateOfBirth = dateOfBirth;
            this.StudentGroup = group;
            this.Gender = gender;
        }


        /// <summary>
        /// Overrided method GetHashCode which gets hash codes from all fields
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
                => (FullName.GetHashCode() + DateOfBirth.GetHashCode() + StudentGroup.GetHashCode());

        /// <summary>
        /// Overrided method Equals which checks Equality of object obj and current object 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
                => (obj is Student student && student.GetHashCode() == this.GetHashCode());

        /// <summary>
        /// Overrided ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
                => ($"{FullName};{DateOfBirth.ToString("dd/MM/yyyy")};{StudentGroup}");

    }
}
