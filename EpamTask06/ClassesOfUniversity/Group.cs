using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    /// <summary>
    /// Class That describes Group table in database
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Int property for Id from DB
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Number of Course
        /// </summary>
        public int NumOfCourse
        {
            get => numOfCourse;

            set
            {
                if (value < 0)
                    throw new GroupException("Incorrect number of course!!!");

                numOfCourse = value;
            }
        }

        /// <summary>
        /// Number of Group
        /// </summary>
        public int NumOfGroup
        {
            get => numOfGroup;

            set
            {
                if (value < 0)
                    throw new GroupException("Incorrect number of group!!!");

                numOfGroup = value;
            }
        }

        /// <summary>
        /// Speciality of Group
        /// </summary>
        public Speciality SpecialityOfGroup {

            get => speciality;

            set => speciality = value ?? throw new GroupException("Incorrect value of speciality!!!");

        }

        int numOfCourse;

        int numOfGroup;

        Speciality speciality;


        public Group() : this(default,default, (new Speciality()))
        {
        }

        public Group(int numOfCourse,int numOfGroup,Speciality speciality)
        {
            this.NumOfCourse = numOfCourse;
            this.NumOfGroup = numOfGroup;
            this.SpecialityOfGroup = speciality;
        }


        /// <summary>
        /// Overrided method GetHashCode which gets hash codes from all fields
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
                => (numOfCourse.GetHashCode() + numOfGroup.GetHashCode() + SpecialityOfGroup.GetHashCode());

        /// <summary>
        /// Overrided method Equals which checks Equality of object obj and current object 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
                => (obj is Group group && group.GetHashCode() == this.GetHashCode());

        /// <summary>
        /// Overrided ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
               => ($"{SpecialityOfGroup.AbreviationOfSpeciality}-{NumOfCourse}{numOfGroup}"); 

    }
}
