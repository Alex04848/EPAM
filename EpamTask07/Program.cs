using EpamTask06;
using EpamTask06.ClassesOfUniversity;
using EpamTask06.ORMClasses;
using EpamTask07.LINQtoSQL_ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EpamTask07.LINQtoSQL_ORM.DBHelper;

namespace EpamTask07
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<ExaminationEvent> repository = ExaminationEventRepository.GetRepository;

            var exam = repository.Read(1);

            int id = GetID(exam);



            Console.ReadKey();
        }
    }
}
