using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    [Table]
    /// <summary>
    /// Class That describes Student table in database
    /// </summary>
    public class Student : Person
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        /// <summary>
        /// Int property for Id from DB
        /// </summary>
        public int Id { get; set; }


        [Column]
        public override string FullName {

            get => fullName;

            set => fullName = value ?? throw new StudentException("Incorrect value of student's name!!!");

        }

        [Column]
        public override DateTime DateOfBirth 
        {

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

        [Column]
        /// <summary>
        /// Gender
        /// </summary>
        public override Gender Gender
        {
            get => gender;

            set
            {
                if (value != Gender.Male && value != Gender.Female)
                    throw new StudentException("Incorrect Gender of a student!!!");

                gender = value;
            }
        }


        Group group;
    
        public Student() : base()
        {
            group = new Group();
        }

        public Student(string fullName,DateTime dateOfBirth,Group group,Gender gender) : base(fullName, dateOfBirth, gender)
        {
            this.StudentGroup = group;
        }



        /// <summary>
        /// Overrided method GetHashCode which gets hash codes from all fields
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
                => (base.GetHashCode() + StudentGroup.GetHashCode());

      
        /// <summary>
        /// Overrided ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
                => ($"{base.ToString()};{StudentGroup}");

    }
}
