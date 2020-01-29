using EpamTask06;
using EpamTask06.ClassesOfUniversity;
using EpamTask06.ORMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask07
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Teacher> repository = SQLRepositoryForTeacher.Repository;

            var list = repository.GetCollection().ToList();

            list.ForEach(Console.WriteLine);


            Console.WriteLine(list.All(value => SQLWorker.CheckExistance(value)));


            Console.ReadKey();
        }
    }
}
