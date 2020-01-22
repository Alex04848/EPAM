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
        {
            var sessionForWrite = dataAnalysis.Sessions.ToList();
            var groupsForWrite = dataAnalysis.Groups.ToList();

            sessionForWrite.ForEach(session =>
            {
                groupsForWrite.ForEach(group => WriteResultsOfSession(session, group));
            });
        }



        static void WriteResultsOfSession(Session session,Group group)
        {
            List<SessionResults> resultsOfSession = dataAnalysis.GetResultsOfSession(session, group).ToList();

            Excel.GetWb();
            Excel.GetSheet();

            Excel.Write(0, 0, "Студент");
            Excel.Write(0, 1,"Средний балл");


            for(int i = 0;i < resultsOfSession.Count; i++)
            {
                Excel.Write((i + 1), 0, resultsOfSession[i].Student.FullName);
                Excel.Write((i + 1), 1, resultsOfSession[i].AverageGrade.ToString());
            }    


            Excel.SaveAs($"{session.NameOfSession} ({group})");
            Excel.Close();
        }



    }
}
