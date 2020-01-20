using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    public class Speciality
    {
        public int Id { get; set; }

        public string AbreviationOfSpeciality { get; set; }

        public string NameOfSpeciality { get; set; }


        public Speciality() : this(string.Empty,string.Empty)
        {

        }

        public Speciality(string abreviationOfSpeciality,string nameOfSpeciality)
        {
            this.AbreviationOfSpeciality = abreviationOfSpeciality;
            this.NameOfSpeciality = nameOfSpeciality;
        }


        public override int GetHashCode()
                => (AbreviationOfSpeciality.GetHashCode() + NameOfSpeciality.GetHashCode());

        public override bool Equals(object obj)
                => (obj is Speciality speciality && speciality.GetHashCode() == this.GetHashCode());

        public override string ToString()
                => ($"{AbreviationOfSpeciality};{NameOfSpeciality}");

    }
}
