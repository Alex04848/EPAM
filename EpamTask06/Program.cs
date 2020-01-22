using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask06.ClassesOfUniversity;
using EpamTask06.ORMClasses;

namespace EpamTask06
{
    class Program
    {
        static void Main(string[] args)
        {
            //IRepository<Subject> repository = SQLRepositoryForSubject.Repository;

            //var subjects = repository.GetCollection().ToList();

            //subjects.ForEach(Console.WriteLine);

            //IRepository<Speciality> repository = SQLRepositoryForSpeciality.Repository;

            //var specialities = repository.GetCollection().ToList();

            //specialities.ForEach(Console.WriteLine);

            IRepository<StudentsGrade> repository = SQLRepositoryForStudentsGrade.Repository;

            var grades = repository.GetCollection().ToList();

            grades.Where(t => t.Session.Id == 1 && t.Student.StudentGroup.Id == 1).ToList().ForEach(Console.WriteLine);




            Console.ReadKey();
        }
    }
}
