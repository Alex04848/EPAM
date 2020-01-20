using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    public class Group
    {

        public int Id { get; set; }

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



        public override int GetHashCode()
                => (numOfCourse.GetHashCode() + numOfGroup.GetHashCode() + SpecialityOfGroup.GetHashCode());

        public override bool Equals(object obj)
                => (obj is Group group && group.GetHashCode() == this.GetHashCode());

        public override string ToString()
               => ($"{SpecialityOfGroup}-{NumOfCourse}{numOfGroup}"); 

    }
}
