using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask06.ClassesOfUniversity.ExceptionsClasses;

namespace EpamTask06.ClassesOfUniversity
{
    public class Subject
    {
        public int Id { get; set; }


        public string NameOfSubject { get; set; }

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




        public override int GetHashCode()
            => (NameOfSubject.GetHashCode() + countOfLections.GetHashCode() + countOfPractice.GetHashCode());

        public override bool Equals(object obj)
                => (obj is Subject subj && subj.GetHashCode() == this.GetHashCode());

        public override string ToString()
            => ($"{NameOfSubject};{countOfLections};{countOfPractice}");

    }
}
