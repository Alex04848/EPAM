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
            IRepository<Subject> repository = SQLRepositoryForSubject.Repository;

            var subjects = repository.GetCollection().ToList();

            subjects.ForEach(Console.WriteLine);



            Console.ReadKey();
        }
    }
}
