using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    public class Student
    {
        public int Id { get; set; }


        public string FullName { get; set; }

        public DateTime DateOfBirth {

            get => dateOfBirth;

            set
            {
                if ((DateTime.Now - value).Days / 365 > 100)
                    throw new StudentException("Incorrect date of Birth");

                dateOfBirth = value;
            }

        }

        public Group StudentGroup {

            get => group;

            set => group = value ?? throw new StudentException("Incorrect value of a group!!!");

        }

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


        public override int GetHashCode()
                => (FullName.GetHashCode() + DateOfBirth.GetHashCode() + StudentGroup.GetHashCode());

        public override bool Equals(object obj)
                => (obj is Student student && student.GetHashCode() == this.GetHashCode());

        public override string ToString()
                => ($"{FullName};{DateOfBirth.ToString("dd/MM/yyyy")};{StudentGroup}");

    }
}
