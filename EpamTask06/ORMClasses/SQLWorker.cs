using EpamTask06.ClassesOfUniversity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ORMClasses
{
    public static class SQLWorker 
    {
        static SqlConnection connection;

        static SqlCommand command;

        static SqlDataReader reader;

        static SQLWorker()
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }


        public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=University;Integrated Security=True;" +
            @"Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public static void SimpleQuery(string query)
        {
            connection.Open();

            command.CommandText = query;
            command.ExecuteNonQuery();

            connection.Close();
        }

        public static IEnumerable<int> GetIDValuesForTable(string tableName)
        {
            List<int> idValues = new List<int>();

            connection.Open();

            command.CommandText = $"SELECT [ID] FROM [{tableName}]";
            reader = command.ExecuteReader();

            while (reader.Read())
                idValues.Add(reader.GetInt32(0));

            connection.Close();

            return idValues;
        }
 
        static int GetID(string query)
        {
            int idValue = -1;

            connection.Open();
            command.CommandText = query;
            reader = command.ExecuteReader();


            if (reader.Read())
                idValue = reader.GetInt32(0);

            connection.Close();



            return idValue;
        }



        public static int GetID(Session session)
            => GetID($"SELECT [ID] FROM [Session]" +
                $" WHERE [NameOfSession] = N'{session.NameOfSession}' AND" +
                $"[StartDate] = N'{session.StartDate.ToString("yyyy-MM-dd")}' AND " +
                $"[EndDate] = N'{session.EndDate.ToString("yyyy-MM-dd")}'");

        public static int GetID(Subject subject)
            => GetID($"SELECT [ID] FROM [Subject]" +
                $" WHERE [NameOfSubject] = N'{subject.NameOfSubject}' AND [CountOfLections] = {subject.CountOfLections} AND " +
                $"[CountOfPractice] = {subject.CountOfPractice}");
          
        public static int GetID(Speciality speciality)
          => GetID($"SELECT [ID] FROM [Speciality]" +
                $" WHERE [AbreviationOfSpeciality] = N'{speciality.AbreviationOfSpeciality}' AND " +
                $"[FullNameOfSpeciality] = {speciality.NameOfSpeciality}");

        public static int GetID(Group group)
        {
            int idValue = GetID(group.SpecialityOfGroup);

            return GetID($"SELECT [ID] FROM [Group] " +
                $"WHERE [NumOfCourse] = {group.NumOfCourse} AND " +
                $"[NumOfGroup] = {group.NumOfGroup} AND " +
                $"[SpecialityID] = {idValue}");
        }

        public static int GetID(Student student)
        {
            int idValue = GetID(student.StudentGroup);

            return GetID($"SELECT [ID] FROM [Student] WHERE [FullName] = N'{student.FullName}' AND " +
                $"[DateOfBirth] = '{student.DateOfBirth.ToString("yyyy-MM-dd")}' AND " +
                $"[GroupID] = {idValue} AND" +
                $"[Gender] = {student.Gender}");
        }

        public static int GetID(StudentsGrade studentsGrade)
        {
            int idValueForStudent = GetID(studentsGrade.Student);
            int idValueForSubject = GetID(studentsGrade.Subject);
            int idValueForSession = GetID(studentsGrade.Session);

            return GetID($"SELECT [ID] FROM [StudentsGrade] WHERE " +
                $"[StudentID] = {idValueForStudent} AND " +
                $"[SubjectID] = {idValueForSubject} AND " +
                $"[Grade] = {studentsGrade.Grade} AND " +
                $"[SessionID] = {idValueForSession}");
        }

        public static int GetID(ExaminationEvent examEvent)
        {
            int idValueForGroup = GetID(examEvent.Group);
            int idValueForSubject = GetID(examEvent.Subject);
            int idValueForSession = GetID(examEvent.Session);

            return GetID($"SELECT [ID] FROM [ExaminationEvent] WHERE " +
                $"[SubjectID] = {idValueForSubject} AND " +
                $"[GroupID] = {idValueForGroup} AND " +
                $"[DateOfExam] = '{examEvent.Date.ToString("yyyy-MM-dd")}'" +
                $"[TypeOfEvent] = {examEvent.EventType} AND " +
                $"[SessionID] = {idValueForSession}");
        }



        public static bool CheckExistance(Session session)
            => (GetID(session) != -1);

        public static bool CheckExistance(Subject subject)
            => (GetID(subject) != -1);

        public static bool CheckExistance(Speciality speciality)
            => (GetID(speciality) != -1);

        public static bool CheckExistance(Group group)
            => (GetID(group) != -1);

        public static bool CheckExistance(Student student)
            => (GetID(student) != -1);

        public static bool CheckExistance(StudentsGrade grade)
            => (GetID(grade) != -1);

        public static bool CheckExistance(ExaminationEvent examinationEvent)
                => (GetID(examinationEvent) != -1);

    }
}


