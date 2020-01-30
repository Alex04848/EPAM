using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    public abstract class Person
    {
      
        /// <summary>
        /// Full Name of Student
        /// </summary>
        public abstract string FullName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        public abstract DateTime DateOfBirth { get; set; }
     

        /// <summary>
        /// Gender
        /// </summary>
        public abstract Gender Gender { get; set; }
       

        /// <summary>
        /// Property for getting age
        /// </summary>
        public int GetAge => ((DateTime.Now - DateOfBirth).Days / 365);


        protected string fullName;

        protected DateTime dateOfBirth;

        protected Gender gender;


        public Person() : this(string.Empty, DateTime.Now, default)
        {
        }

        public Person(string fullName, DateTime dateOfBirth, Gender gender)
        {
            this.FullName = fullName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
        }


        /// <summary>
        /// Overrided method GetHashCode which gets hash codes from all fields
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
                => (FullName.GetHashCode() + DateOfBirth.GetHashCode());

        /// <summary>
        /// Overrided method Equals which checks Equality of object obj and current object 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
                => (obj is Person student && student.GetHashCode() == this.GetHashCode());

        /// <summary>
        /// Overrided ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
                => ($"{FullName};{DateOfBirth.ToString("dd/MM/yyyy")}");

    }
}
