using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask06.ClassesForExcel;
using static System.IO.Directory;
using EpamTask07.DataAnalysisClasses;
using static EpamTask07.DBAccess.DBAccessObject;
using EpamTask06.ClassesOfUniversity;

namespace EpamTask07.ExcelWriterClasses
{
    public static class ExcelWriter
    {
        public static string PathToFile { get; set; } = GetParent(GetParent(GetCurrentDirectory()).FullName)
                                                        .GetDirectories().First(dir => dir.Name.Equals("ExcelFiles")).FullName;

        public static DataAnalysis DataAnalysis { get; set; } = new DataAnalysis(Subjects.GetCollection(),
                                                         Sessions.GetCollection(),
                                                         Specialities.GetCollection(),
                                                         Groups.GetCollection(),
                                                         Students.GetCollection(),
                                                         ExaminationEvents.GetCollection(),
                                                         StudentsGrades.GetCollection(),
                                                         Teachers.GetCollection());
        static ExcelWriter()
        {
            Excel.ChangeDefaultPath(PathToFile);
        }

        public static void WriteResultsOfSessionForSpeciality(bool orderFlag = false)
            => DataAnalysis.Sessions.ToList().ForEach(session => WriteResultsOfSessionForSpeciality(session,orderFlag));

        public static void WriteResultsOfSessionForTeacher(bool orderFlag = false)
            => DataAnalysis.Sessions.ToList().ForEach(session => WriteResultsOfSessionForTeacher(session, orderFlag));

        public static void WriteResultsForYears()
            => DataAnalysis.GetAllYears()
                                        .ToList()
                                        .ForEach(WriteResultsForYear);


        static void WriteResultsOfSessionForSpeciality(Session session, bool orderFlag)
        {
            List<(Speciality, double)> specialitiesAndGradeList = new List<(Speciality, double)>();

            Excel.GetWb();
            Excel.GetSheet();

            Excel.Write(0, 0, "Аббревиатура");
            Excel.Write(0, 1, "Имя Специальности");
            Excel.Write(0, 2, "Средний балл");

            var specialitiesArray = DataAnalysis.Specialities.ToArray();


            for(int i = 0;i < specialitiesArray.Length;i++)
                specialitiesAndGradeList.Add((specialitiesArray[i],
                    DataAnalysis.GetResultsForSpeciality(session, specialitiesArray[i])));

            if (orderFlag)
                specialitiesAndGradeList = specialitiesAndGradeList.OrderBy(spcAndGrd => spcAndGrd.Item2).ToList();

            for (int i = 0; i < specialitiesAndGradeList.Count; i++)
            {            
                Excel.Write((i + 1), 0, specialitiesAndGradeList[i].Item1.AbreviationOfSpeciality);
                Excel.Write((i + 1), 1, specialitiesAndGradeList[i].Item1.NameOfSpeciality);
                Excel.Write((i + 1), 2, specialitiesAndGradeList[i].Item2.ToString("F2"));
            }

            if(orderFlag)
                Excel.SaveAs($"{session.NameOfSession} Результат по Специальностям (Упорядоченный по Среднему баллу)");
            else
                Excel.SaveAs($"{session.NameOfSession} Результат по Специальностям");

            Excel.Close();
        }

        static void WriteResultsOfSessionForTeacher(Session session,bool orderFlag)
        {
            List<(Teacher, double)> teachersAndGrades = new List<(Teacher, double)>();
            Excel.GetWb();
            Excel.GetSheet();

            Excel.Write(0, 0, "Преподаватель");
            Excel.Write(0, 1, "Средний балл");

            var teachers = DataAnalysis.Teachers.ToArray();

            for (int i = 0; i < teachers.Length; i++)          
                teachersAndGrades
                    .Add((teachers[i], DataAnalysis.GetResultsForTeacher(session, teachers[i])));

            if (orderFlag)
                teachersAndGrades = teachersAndGrades.OrderBy(tchrAndGrd => tchrAndGrd.Item2).ToList();

            for (int i = 0; i < teachersAndGrades.Count; i++)
            {
                Excel.Write((i + 1), 0, teachersAndGrades[i].Item1.FullName);              
                Excel.Write((i + 1), 1, teachersAndGrades[i].Item2.ToString("F2"));
            }

            if(orderFlag)
                Excel.SaveAs($"{session.NameOfSession} Результат по Преподавателям (Упорядочено по среднему баллу)");
            else
                Excel.SaveAs($"{session.NameOfSession} Результат по Преподавателям");

            Excel.Close();
        }

        static void WriteResultsForYear(int year)
        {
            Excel.GetWb();
            Excel.GetSheet();

            Excel.Write(0, 0, "Предмет");
            Excel.Write(0, 1, "Средний балл");


            var subjects = DataAnalysis.Subjects.ToArray();

            for (int i = 0; i < subjects.Length; i++)
            {
                Excel.Write((i + 1), 0, subjects[i].NameOfSubject);       
                Excel.Write((i + 1), 1, DataAnalysis.GetYearResultForSubject(subjects[i],year).ToString("F2"));
            }

            Excel.SaveAs($"Предметы {year} года Результаты");
            Excel.Close();
        }

    }
}
