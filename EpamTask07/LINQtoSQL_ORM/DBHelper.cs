using EpamTask06.ClassesOfUniversity;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask07.LINQtoSQL_ORM
{
    public static class DBHelper
    {
        static DataContext db = new DataContext(connectionString);


        public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=University;Integrated Security=True;
                 Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public static int GetID(Teacher teacher)
            => db.ExecuteQuery<int>($"SELECT [ID] FROM [Teacher] WHERE " +
                $"[FullName] = N'{teacher.FullName}' AND " +
                $"[DateOfBirth] = '{teacher.DateOfBirth.ToString("yyyy-MM-dd")}' AND " +
                $"[Gender] = {(int)teacher.Gender}")
            .FirstOrDefault();

        public static int GetID(Subject subject)
            => db.ExecuteQuery<int>($"SELECT [ID] FROM [Subject] WHERE " +
                $"[NameOfSubject] = N'{subject.NameOfSubject}' AND " +
                $"[CountOfLections] = {subject.CountOfLections} AND " +
                $"[CountOfPractice] = {subject.CountOfPractice}")
            .FirstOrDefault();

        public static int GetID(Speciality speciality)
            => db.ExecuteQuery<int>($"SELECT [ID] FROM [Speciality] WHERE" +
                $"[AbreviationOfSpeciality] = N'{speciality.AbreviationOfSpeciality}' AND " +
                $"[FullNameOfSpeciality] = N'{speciality.NameOfSpeciality}'")
            .FirstOrDefault();

        public static int GetID(Session session)
            => db.ExecuteQuery<int>($"SELECT [ID] FROM [Session] WHERE " +
                $"[NameOfSession] = N'{session.NameOfSession}' AND " +
                $"[StartDate] = '{session.StartDate.ToString("yyyy-MM-dd")}' AND " +
                $"[EndDate] = '{session.EndDate.ToString("yyyy-MM-dd")}'")
            .FirstOrDefault();

        public static int GetID(Group group)
             => db.ExecuteQuery<int>($"SELECT [ID] FROM [Group] WHERE " +
                 $"[NumOfCourse] = {group.NumOfCourse} AND" +
                 $"[NumOfGroup] = {group.NumOfGroup} AND" +
                 $"[SpecialityID] = {GetID(group.SpecialityOfGroup)}")
            .FirstOrDefault();

        public static int GetID(Student student)
            => db.ExecuteQuery<int>($"SELECT [ID] FROM [Student] WHERE " +
                $"[FullName] = N'{student.FullName}' AND " +
                $"[DateOfBirth] = '{student.DateOfBirth.ToString("yyyy-MM-dd")}' AND " +
                $"[Gender] = {(int)student.Gender} AND " +
                $"[GroupID] = {GetID(student.StudentGroup)}")
            .FirstOrDefault();

        public static int GetID(ExaminationEvent examEvent)
            => db.ExecuteQuery<int>($"SELECT [ID] FROM [ExaminationEvent] WHERE " +
                $"[SubjectID] = {GetID(examEvent.Subject)} AND " +
                $"[GroupID] = {GetID(examEvent.Group)} AND " +
                $"[DateOfExam] = '{examEvent.Date.ToString("yyyy-MM-dd")}' AND" +
                $"[TypeOfEvent] = {(int)examEvent.EventType} AND" +
                $"[SessionID] = {GetID(examEvent.Session)} AND" +
                $"[TeacherID] = {GetID(examEvent.Teacher)}")
            .FirstOrDefault();

        public static int GetID(StudentsGrade studentsGrade)
            => db.ExecuteQuery<int>($"SELECT [ID] FROM [StudentsGrade] WHERE" +
                $"[StudentID] = {GetID(studentsGrade.Student)} AND " +
                $"[SubjectID] = {GetID(studentsGrade.Subject)} AND " +
                $"[Grade] = {studentsGrade.Grade} AND " +
                $"[SessionID] = {GetID(studentsGrade.Session)} AND " +
                $"[TeacherID] = {GetID(studentsGrade.Teacher)}")
            .FirstOrDefault();


        public static bool CheckExistance(Teacher teacher)
            => (GetID(teacher) != 0);

        public static bool CheckExistance(Subject subject)
            => (GetID(subject) != 0);

        public static bool CheckExistance(Speciality speciality)
            => (GetID(speciality) != 0);

        public static bool CheckExistance(Session session)
            => (GetID(session) != 0);

        public static bool CheckExistance(Group group)
             => (GetID(group) != 0);

        public static bool CheckExistance(Student student)
            => (GetID(student) != 0);

        public static bool CheckExistance(ExaminationEvent examEvent)
            => (GetID(examEvent) != 0);

        public static bool CheckExistance(StudentsGrade studentsGrade)
            => (GetID(studentsGrade) != 0);
    }
}
