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
    /// <summary>
    /// Class for writing results of Session in Excel Files
    /// </summary>
    public static class ExcelWriter
    {
        /// <summary>
        /// Default Path
        /// </summary>
        public static readonly string defaultPath = GetParent(GetParent(GetCurrentDirectory()).FullName)
                                                        .GetDirectories().First(dir => dir.Name.Equals("ExcelFiles")).FullName;

        /// <summary>
        /// Data Analysis class with data from DB
        /// </summary>
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

        /// <summary>
        /// Write Results of Session
        /// </summary>
        public static void WriteResults()
                => WriteResults(WriteResultsOfSession);

        /// <summary>
        /// Write Results of Session Ordered by students name
        /// </summary>
        public static void WriteResultsOrderedByStudentsName()
                    => WriteResults(WriteResultsOfSessionOrderedByStudentsName);

        /// <summary>
        /// Write Results of Session Ordered by grades
        /// </summary>
        public static void WriteResultsOrderedByGrades()
                    => WriteResults(WriteResultsOfSessionOrderedByGrades);

        /// <summary>
        /// Write Students for Expelling
        /// </summary>
        public static void WriteStudentsForExpelling()
                => WriteResults(WriteStudentsForExpelling);

        /// <summary>
        /// Write Students for Expelling Ordered by students name 
        /// </summary>
        public static void WriteStudentsForExpellingOrderedByStudentsName()
                => WriteResults(WriteStudentsForExpellingOrderedByStudentsName);

        /// <summary>
        /// Write Students for Expelling Ordered by grades 
        /// </summary>
        public static void WriteStudentsForExpellingOrderedByGrades()
              => WriteResults(WriteStudentsForExpellingOrderedByGrades);

        /// <summary>
        /// Common method for writing results
        /// </summary>
        /// <param name="method"></param>
        static void WriteResults(Action<Session,Group> method)
        {
            var sessionForWrite = dataAnalysis.Sessions.ToList();
            var groupsForWrite = dataAnalysis.Groups.ToList();

            sessionForWrite.ForEach(session =>
            {
                groupsForWrite.ForEach(group => method(session, group));
            });
        }

        /// <summary>
        /// Write Results of Session Ordered by students name
        /// </summary>
        static void WriteResultsOfSessionOrderedByStudentsName(Session session, Group group)
        {
            var resultsOfSession = dataAnalysis.GetResultsOfSessionOrderByStudentsName(session, group);

            WriteResultsOfSession(resultsOfSession, $"{session.NameOfSession} ({group}) - Упорядочен по списку студентов");
        }

        /// <summary>
        /// Write Results of session
        /// </summary>
        static void WriteResultsOfSession(Session session,Group group)
        {
            var resultsOfSession = dataAnalysis.GetResultsOfSession(session, group);

            WriteResultsOfSession(resultsOfSession, $"{session.NameOfSession} ({group})");
        }

        /// <summary>
        /// Write Results of Session Ordered by grades
        /// </summary>
        static void WriteResultsOfSessionOrderedByGrades(Session session, Group group)
        {
            var resultsOfSession = dataAnalysis.GetResultsOfSessionOrderByGrades(session, group);

            WriteResultsOfSession(resultsOfSession, $"{session.NameOfSession} ({group}) - Упорядочен по оценкам");
        }

        /// <summary>
        /// Write Students for Expelling
        /// </summary>
        static void WriteStudentsForExpelling(Session session,Group group)
        {
            var resultsOfSession = dataAnalysis.GetStudentsForExpelling(session, group);

            WriteResultsOfSession(resultsOfSession, $"{session.NameOfSession} ({group}) - Студенты для отчисления");
        }

        /// <summary>
        /// Write Students for Expelling Ordered by students name 
        /// </summary>
        static void WriteStudentsForExpellingOrderedByStudentsName(Session session, Group group)
        {
            var resultsOfSession = dataAnalysis.GetStudentsForExpellingOrderedByStudentsName(session, group);

            WriteResultsOfSession(resultsOfSession, $"{session.NameOfSession} ({group}) - Студенты для отчисления упорядоченные по имени");
        }

        /// <summary>
        /// Write Students for Expelling Ordered by grades 
        /// </summary>
        static void WriteStudentsForExpellingOrderedByGrades(Session session, Group group)
        {
            var resultsOfSession = dataAnalysis.GetStudentsForExpellingOrderedByGrades(session, group);

            WriteResultsOfSession(resultsOfSession, $"{session.NameOfSession} ({group}) - Студенты для отчисления упорядоченные по оценкам");
        }

        /// <summary>
        /// Write Results of session
        ///</summary>
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


        /// <summary>
        /// Write Results of session For Groups
        ///</summary>
        public static void WriteResultsForGroups()
         => dataAnalysis.Sessions.ToList()
             .ForEach(session => WriteResultsOfSession(session, $"{session.NameOfSession} - Сводка по группам"));

        /// <summary>
        /// Write Results of session For Groups
        ///</summary>
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
