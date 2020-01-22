using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask06.ClassesOfUniversity;
using EpamTask06.ORMClasses;
using EpamTask06.DataAnalysisClasses;
using EpamTask06.DBAccess;
using static EpamTask06.DBAccess.DBAccessObject;
using EpamTask06.ClassesForExcel;

namespace EpamTask06
{
    class Program
    {
        static void Main(string[] args)
        {
        
            //DataAnalysis dataAnalysis = new DataAnalysis(Subjects.GetCollection(),
            //                                             Sessions.GetCollection(),
            //                                             Specialities.GetCollection(),
            //                                             Groups.GetCollection(),
            //                                             Students.GetCollection(),
            //                                             ExaminationEvents.GetCollection(),
            //                                             StudentsGrades.GetCollection());

            //Group group = Groups.Read(1);
            //Session session = Sessions.Read(1);


            //var resultsList = dataAnalysis.GetResultsOfSession(session, group).ToList();

            //resultsList.ForEach(Console.WriteLine);


            ExcelWriter.WriteResults();



            Console.ReadKey();
        }
    }
}
