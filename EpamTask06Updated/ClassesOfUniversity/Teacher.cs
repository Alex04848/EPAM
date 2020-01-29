using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    public class Teacher : Person
    {
        public override string FullName {

            get => fullName;

            set => fullName = value ?? throw new TeacherException("Incorrect name of Teacher!!!");

        }
        public override DateTime DateOfBirth {

            get => dateOfBirth;

            set {
                if ((DateTime.Now - value).TotalDays / 365 > 100)
                    throw new TeacherException("Incorrect date of birth!!!");

                dateOfBirth = value;
            }

        }

        public override Gender Gender
        {
            get => gender;

            set
            {
                if (value != Gender.Male && value != Gender.Female)
                    throw new TeacherException("Incorrect Gender of a teacher!!!");

                gender = value;
            }
        }


        public Teacher()
        {
        }

        public Teacher(string fullName,DateTime dateOfBirth,Gender gender) : base(fullName,dateOfBirth,gender)
        {
        }

    }
}
