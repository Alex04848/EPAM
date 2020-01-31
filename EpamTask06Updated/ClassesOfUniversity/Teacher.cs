using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace EpamTask06.ClassesOfUniversity
{
    /// <summary>
    /// Teacher class for University Classes
    /// </summary>
    [Table(Name = "Teacher")]
    public class Teacher : Person
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        /// <summary>
        /// Int property for Id from DB
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// FullName Of Teacher
        /// </summary>
        [Column]
        public override string FullName {

            get => fullName;

            set => fullName = value ?? throw new TeacherException("Incorrect name of Teacher!!!");

        }

        /// <summary>
        /// Date Of Birth of Teacher
        /// </summary>
        [Column]
        public override DateTime DateOfBirth {

            get => dateOfBirth;

            set {
                if ((DateTime.Now - value).TotalDays / 365 > 100)
                    throw new TeacherException("Incorrect date of birth!!!");

                dateOfBirth = value;
            }

        }

        /// <summary>
        /// Gender
        /// </summary>
        [Column]
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
