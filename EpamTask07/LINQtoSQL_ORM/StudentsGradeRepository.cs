using EpamTask06;
using EpamTask06.ClassesOfUniversity;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EpamTask07.LINQtoSQL_ORM.DBHelper;

namespace EpamTask07.LINQtoSQL_ORM
{
    /// <summary>
    /// Repository for StudentsGrade Table
    /// </summary>
    public class StudentsGradeRepository : IRepository<StudentsGrade>
    {
        //--------------------Singleton------------------------------

        static Lazy<StudentsGradeRepository> repository = 
            new Lazy<StudentsGradeRepository>(() => new StudentsGradeRepository());

        public static StudentsGradeRepository GetRepository => repository.Value;

        //-----------------------------------------------------------

        DataContext db;

        IRepository<Student> repositoryForStudent = StudentRepository.GetRepository;

        IRepository<Subject> repositoryForSubject = SubjectRepository.GetRepository;

        IRepository<Session> repositoryForSession = SessionRepository.GetRepository;

        IRepository<Teacher> repositoryForTeacher = TeacherRepository.GetRepository;


        StudentsGradeRepository()
        {
            db = new DataContext(DBHelper.connectionString);
        }


        public void Create(StudentsGrade obj)
            => db.ExecuteCommand($"INSERT INTO [StudentsGrade] VALUES " +
                $"({GetID(obj.Student)}," +
                $"{GetID(obj.Subject)}," +
                $"{obj.Grade}," +
                $"{GetID(obj.Session)}," +
                $"{GetID(obj.Teacher)})");

        public void Delete(int id)
               => db.ExecuteCommand($"DELETE FROM [StudentsGrade] WHERE [ID] = {id}");

        public IEnumerable<StudentsGrade> GetCollection()
        {
            List<StudentsGrade> studentsGrades = new List<StudentsGrade>();
            List<int> idValues = db.ExecuteQuery<int>("SELECT [ID] FROM [StudentsGrade]").ToList();
         
            idValues.ForEach(idValue => studentsGrades.Add(Read(idValue)));

            return studentsGrades;
        }

        public StudentsGrade Read(int id)
        {
            StudentsGrade studentsGrade = db.ExecuteQuery<StudentsGrade>($"SELECT * FROM [StudentsGrade] WHERE [ID] = {id}")
                .FirstOrDefault();

            if(studentsGrade != null)
            {
                studentsGrade.Student = repositoryForStudent.Read(db.ExecuteQuery<int>($"SELECT [StudentID] FROM [StudentsGrade] WHERE [ID] = {id}")
                    .FirstOrDefault());
                studentsGrade.Subject = repositoryForSubject.Read(db.ExecuteQuery<int>($"SELECT [SubjectID] FROM [StudentsGrade] WHERE [ID] = {id}")
                    .FirstOrDefault());
                studentsGrade.Session = repositoryForSession.Read(db.ExecuteQuery<int>($"SELECT [SessionID] FROM [StudentsGrade] WHERE [ID] = {id}")
                    .FirstOrDefault());
                studentsGrade.Teacher = repositoryForTeacher.Read(db.ExecuteQuery<int>($"SELECT [TeacherID] FROM [StudentsGrade] WHERE [ID] = {id}")
                    .FirstOrDefault());
            }

            return studentsGrade;
        }

        public void Update(StudentsGrade obj)
            => db.ExecuteCommand($"UPDATE [StudentsGrade] SET " +
                $"[StudentID] = {GetID(obj.Student)}," +
                $"[SubjectID] = {GetID(obj.Subject)}," +
                $"[Grade] = {obj.Grade}," +
                $"[SessionID] = {GetID(obj.Session)}," +
                $"[TeacherID] = {GetID(obj.Teacher)}" +
                $"WHERE [ID] = {obj.Id}");
    }
}
