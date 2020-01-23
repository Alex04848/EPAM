using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask06.DBAccess;
using EpamTask06.DataAnalysisClasses;
using EpamTask06.ClassesOfUniversity;
using System.IO;
using static System.IO.Directory;
using static EpamTask06.DBAccess.DBAccessObject;

namespace EpamTask06.ClassesForExcel
{
    public static class ExcelWriter
    {

        public static readonly string defaultPath = GetParent(GetParent(GetCurrentDirectory()).FullName)
                                                        .GetDirectories().First(dir => dir.Name.Equals("ExcelFiles")).FullName;

        public static readonly DataAnalysis dataAnalysis = new DataAnalysis(Subjects.GetCollection(),
                                                         Sessions.GetCollection(),
                                                         Specialities.GetCollection(),
                                                         Groups.GetCollection(),
                                                         Students.GetCollection(),
                                                         ExaminationEvents.GetCollection(),
                                                         StudentsGrades.GetCollection());

        static ExcelWriter()
        {
            Excel.ChangeDefaultPath(defaultPath);
        }


        public static void WriteResults()
                => WriteResults(WriteResultsOfSession);

        public static void WriteResultsOrderedByStudentsName()
                    => WriteResults(WriteResultsOfSessionOrderedByStudentsName);

        public static void WriteResultsOrderedByGrades()
                    => WriteResults(WriteResultsOfSessionOrderedByGrades);

        public static void WriteStudentsForExpelling()
                => WriteResults(WriteStudentsForExpelling);

        public static void WriteStudentsForExpellingOrderedByStudentsName()
                => WriteResults(WriteStudentsForExpellingOrderedByStudentsName);

        public static void WriteStudentsForExpellingOrderedByGrades()
              => WriteResults(WriteStudentsForExpellingOrderedByGrades);




        static void WriteResults(Action<Session,Group> method)
        {
            var sessionForWrite = dataAnalysis.Sessions.ToList();
            var groupsForWrite = dataAnalysis.Groups.ToList();

            sessionForWrite.ForEach(session =>
            {
                groupsForWrite.ForEach(group => method(session, group));
            });
        }


        static void WriteResultsOfSessionOrderedByStudentsName(Session session, Group group)
        {
            var resultsOfSession = dataAnalysis.GetResultsOfSessionOrderByStudentsName(session, group);

            WriteResultsOfSession(resultsOfSession, $"{session.NameOfSession} ({group}) - Упорядочен по списку студентов");
        }

        static void WriteResultsOfSession(Session session,Group group)
        {
            var resultsOfSession = dataAnalysis.GetResultsOfSession(session, group);

            WriteResultsOfSession(resultsOfSession, $"{session.NameOfSession} ({group})");
        }

        static void WriteResultsOfSessionOrderedByGrades(Session session, Group group)
        {
            var resultsOfSession = dataAnalysis.GetResultsOfSessionOrderByGrades(session, group);

            WriteResultsOfSession(resultsOfSession, $"{session.NameOfSession} ({group}) - Упорядочен по оценкам");
        }

        static void WriteStudentsForExpelling(Session session,Group group)
        {
            var resultsOfSession = dataAnalysis.GetStudentsForExpelling(session, group);

            WriteResultsOfSession(resultsOfSession, $"{session.NameOfSession} ({group}) - Студенты для отчисления");
        }

        static void WriteStudentsForExpellingOrderedByStudentsName(Session session, Group group)
        {
            var resultsOfSession = dataAnalysis.GetStudentsForExpellingOrderedByStudentsName(session, group);

            WriteResultsOfSession(resultsOfSession, $"{session.NameOfSession} ({group}) - Студенты для отчисления упорядоченные по имени");
        }

        static void WriteStudentsForExpellingOrderedByGrades(Session session, Group group)
        {
            var resultsOfSession = dataAnalysis.GetStudentsForExpellingOrderedByGrades(session, group);

            WriteResultsOfSession(resultsOfSession, $"{session.NameOfSession} ({group}) - Студенты для отчисления упорядоченные по оценкам");
        }

        static void WriteResultsOfSession(IEnumerable<SessionResults> sessionResults,string nameOfFile)
        {
            var resultsOfSession = sessionResults.ToList();

            Excel.GetWb();
            Excel.GetSheet();

            Excel.Write(0, 0, "Студент");
            Excel.Write(0, 1, "Средний балл");


            for (int i = 0; i < resultsOfSession.Count; i++)
            {
                Excel.Write((i + 1), 0, resultsOfSession[i].Student.FullName);
                Excel.Write((i + 1), 1, resultsOfSession[i].AverageGrade.ToString());
            }


            Excel.SaveAs(nameOfFile);
            Excel.Close();
        }

      

        public static void WriteResultsForGroups()
         => dataAnalysis.Sessions.ToList()
             .ForEach(session => WriteResultsOfSession(session, $"{session.NameOfSession} - Сводка по группам"));

        static void WriteResultsOfSession(Session session,string nameOfFile)
        {        
            var groupsList = dataAnalysis.Groups.ToList();

            Excel.GetWb();
            Excel.GetSheet();

            Excel.Write(0, 0, "Группа");
            Excel.Write(0, 1, "Минимальный балл");
            Excel.Write(0, 2, "Максимальный балл");
            Excel.Write(0, 3, "Средний балл");


            for (int i = 0;i < groupsList.Count; i++)
            {
                Excel.Write((i + 1), 0, groupsList[i].ToString());
                Excel.Write((i + 1), 1, dataAnalysis.GetMinimalGrade(session,groupsList[i]).ToString());
                Excel.Write((i + 1), 2, dataAnalysis.GetMaxGrade(session, groupsList[i]).ToString());
                Excel.Write((i + 1), 3, dataAnalysis.GetAverageGrade(session, groupsList[i]).ToString("F2"));
            }


            Excel.SaveAs(nameOfFile);
            Excel.Close();
        }


    }
}
