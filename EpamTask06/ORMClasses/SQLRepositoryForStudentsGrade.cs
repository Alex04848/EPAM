using EpamTask06.ClassesOfUniversity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ORMClasses
{
    public class SQLRepositoryForStudentsGrade : IRepository<StudentsGrade>
    { 
        
        //--------------------------Singleton-----------------------

        static Lazy<SQLRepositoryForStudentsGrade> repository =
            new Lazy<SQLRepositoryForStudentsGrade>(() => new SQLRepositoryForStudentsGrade());

        public static SQLRepositoryForStudentsGrade Repository => repository.Value;

        //-----------------------------------------------------------


        IRepository<Student> studentsRepository = SQLRepositoryForStudent.Repository;

        IRepository<Subject> subjectsRepository = SQLRepositoryForSubject.Repository;

        IRepository<Session> sessionRepository = SQLRepositoryForSession.Repository;



        SqlConnection connection;

        SqlCommand command;

        SqlDataReader reader;

        SQLRepositoryForStudentsGrade()
        {
            connection = new SqlConnection(SQLWorker.connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }


        public void Create(StudentsGrade obj)
        {
            DBException.CatchException(obj);


            SQLWorker.SimpleQuery($"INSERT INTO [StudentsGrade] VALUES" +
                $" ({SQLWorker.GetID(obj.Student)}," +
                $" {SQLWorker.GetID(obj.Subject)}," +
                $"{obj.Grade}," +
                $"{SQLWorker.GetID(obj.Session)})");
        }

        public void Delete(int id)
                => SQLWorker.SimpleQuery($"DELETE FROM [StudentsGrade] WHERE [ID] = {id}");

        public IEnumerable<StudentsGrade> GetCollection()
        {
            List<StudentsGrade> studentsGrades = new List<StudentsGrade>();
            List<int> idValues = SQLWorker.GetIDValuesForTable("StudentsGrade").ToList();

            idValues.ForEach(idValue => studentsGrades.Add(Read(idValue)));

            return studentsGrades;
        }

        public StudentsGrade Read(int id)
        {
            StudentsGrade studentsGrade = null;

            connection.Open();
            command.CommandText = $"SELECT * FROM [StudentsGrade] WHERE [ID] = {id}";
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                Student student = studentsRepository.Read(reader.GetInt32(1));
                Subject subject = subjectsRepository.Read(reader.GetInt32(2));
                Session session = sessionRepository.Read(reader.GetInt32(4));

                studentsGrade = new StudentsGrade(reader.GetInt32(3),student,subject,session);
                student.Id = reader.GetInt32(0);
            }

            connection.Close();

            return studentsGrade;
        }

        public void Update(StudentsGrade obj)
        {
            DBException.CatchException(obj);

            SQLWorker.SimpleQuery($"UPDATE [StudentsGrade] SET " +
                $"[StudentID] = {SQLWorker.GetID(obj.Student)}," +
                $"[SubjectID] = {SQLWorker.GetID(obj.Subject)}," +
                $"[Grade] = {obj.Grade}," +
                $"[SessionID] = {SQLWorker.GetID(obj.Session)} " +
                $" WHERE [ID] = {obj.Id}");
        }
       
    }
}
