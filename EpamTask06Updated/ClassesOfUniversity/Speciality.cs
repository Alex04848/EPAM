using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    /// <summary>
    /// Class That describes Speciality table in database
    /// </summary>
    public class Speciality
    {
        /// <summary>
        /// Int property for Id from DB
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Abreviation of Speciality
        /// </summary>
        public string AbreviationOfSpeciality {

            get => abreviationOfSpeciality;

            set => abreviationOfSpeciality = value ?? throw new SpecialityException("Incorrect abreviation of speciality!!!");

        }

        /// <summary>
        /// Name Of Speciality
        /// </summary>
        public string NameOfSpeciality {

            get => nameOfSpeciality;

            set => nameOfSpeciality = value ?? throw new SpecialityException("Incorrect name of speciality!!!");

        }


        string abreviationOfSpeciality;

        string nameOfSpeciality;


        public Speciality() : this(string.Empty,string.Empty)
        {

        }

        public Speciality(string abreviationOfSpeciality,string nameOfSpeciality)
        {
            this.AbreviationOfSpeciality = abreviationOfSpeciality;
            this.NameOfSpeciality = nameOfSpeciality;
        }


        /// <summary>
        /// Overrided method GetHashCode which gets hash codes from all fields
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
                => (AbreviationOfSpeciality.GetHashCode() + NameOfSpeciality.GetHashCode());

        /// <summary>
        /// Overrided method Equals which checks Equality of object obj and current object 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
                => (obj is Speciality speciality && speciality.GetHashCode() == this.GetHashCode());

        /// <summary>
        /// Overrided ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
                => ($"{AbreviationOfSpeciality};{NameOfSpeciality}");

    }
}
