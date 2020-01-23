using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask06.ClassesOfUniversity.ExceptionsClasses;

namespace EpamTask06.ClassesOfUniversity
{
    /// <summary>
    /// Class That describes Subject table in database
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Int property for Id from DB
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Name Of Subject in DB
        /// </summary>
        public string NameOfSubject { get; set; }

        /// <summary>
        /// Count of Lections Property
        /// </summary>
        public int CountOfLections
        {
            get => countOfLections;

            set
            {
                if (value < 0)
                    throw new SubjectException("Incorrect count of lections!!!");

                countOfLections = value;
            }

        }

        /// <summary>
        /// Count of practice property
        /// </summary>
        public int CountOfPractice
        {
            get => countOfPractice;

            set
            {
                if (value < 0)
                    throw new SubjectException("Incorrect count of practice!!!");

                countOfPractice = value;
            }
        }


        int countOfLections;

        int countOfPractice;


        public Subject() : this(string.Empty,default,default)
        {
        }

        public Subject(string nameOfSubject,int countOfLections,int countOfPractice)
        {
            this.NameOfSubject = nameOfSubject;
            this.countOfLections = countOfLections;
            this.CountOfPractice = countOfPractice;
        }



        /// <summary>
        /// Overrided method GetHashCode which gets hash codes from all fields
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
            => (NameOfSubject.GetHashCode() + countOfLections.GetHashCode() + countOfPractice.GetHashCode());

        /// <summary>
        /// Overrided method Equals which checks Equality of object obj and current object 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
                => (obj is Subject subj && subj.GetHashCode() == this.GetHashCode());

        /// <summary>
        /// Overrided ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => ($"{NameOfSubject};{countOfLections};{countOfPractice}");

    }
}
