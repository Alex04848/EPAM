using EpamTask06.ClassesOfUniversity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ORMClasses
{
    /// <summary>
    /// Repository for ExaminationEvent Table
    /// </summary>
    public class SQLRepositoryForExaminationEvent : IRepository<ExaminationEvent>
    {
        //--------------------------Singleton-----------------------

        static Lazy<SQLRepositoryForExaminationEvent> repository =
            new Lazy<SQLRepositoryForExaminationEvent>(() => new SQLRepositoryForExaminationEvent());

        public static SQLRepositoryForExaminationEvent Repository => repository.Value;

        //-----------------------------------------------------------


        IRepository<Group> groupRepository = SQLRepositoryForGroup.Repository;

        IRepository<Subject> subjectsRepository = SQLRepositoryForSubject.Repository;

        IRepository<Session> sessionRepository = SQLRepositoryForSession.Repository;

        IRepository<Teacher> teachersRepository = SQLRepositoryForTeacher.Repository;


        SqlConnection connection;

        SqlCommand command;

        SqlDataReader reader;

        SQLRepositoryForExaminationEvent()
        {
            connection = new SqlConnection(SQLWorker.connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }


        public void Create(ExaminationEvent obj)
        {
            DBException.CatchException(obj);

            SQLWorker.SimpleQuery($"INSERT INTO [ExaminationEvent] VALUES ({SQLWorker.GetID(obj.Subject)}," +
                $"{SQLWorker.GetID(obj.Group)}," +
                $"'{obj.Date.ToString("yyyy-MM-dd")}'," +
                $"{(int)obj.EventType}," +
                $"{SQLWorker.GetID(obj.Session)}," +
                $"{SQLWorker.GetID(obj.Teacher)})");
        }

        public void Delete(int id)
            => SQLWorker.SimpleQuery($"DELETE FROM [ExaminationEvent] WHERE [ID] = {id}");

        public IEnumerable<ExaminationEvent> GetCollection()
        {
            List<ExaminationEvent> examinationEvents = new List<ExaminationEvent>();
            List<int> idValues = SQLWorker.GetIDValuesForTable("ExaminationEvent").ToList();

            idValues.ForEach(idValue => examinationEvents.Add(Read(idValue)));

            return examinationEvents;
        }

        public ExaminationEvent Read(int id)
        {
            ExaminationEvent examinationEvent = null;

            connection.Open();

            command.CommandText = $"SELECT * FROM [ExaminationEvent] WHERE [ID] = {id}";
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                Subject subject = subjectsRepository.Read(reader.GetInt32(1));
                Group group = groupRepository.Read(reader.GetInt32(2));
                Session session = sessionRepository.Read(reader.GetInt32(5));
                Teacher teacher = teachersRepository.Read(reader.GetInt32(6));

                examinationEvent = new ExaminationEvent(subject, group, reader.GetDateTime(3), (ExaminationEventType)reader.GetInt32(4),session,teacher);
                examinationEvent.Id = reader.GetInt32(0);
            }

            connection.Close();
            

            return examinationEvent;
        }

        public void Update(ExaminationEvent obj)
        {
            DBException.CatchException(obj);

            SQLWorker.SimpleQuery($"UPDATE [ExaminationEvent] SET [SubjectID] = {SQLWorker.GetID(obj.Subject)}," +
                $"[GroupID] = {SQLWorker.GetID(obj.Group)}," +
                $"[DateOfExam] = '{obj.Date.ToString("yyyy-MM-dd")}'," +
                $"[TypeOfEvent] = {(int)obj.EventType}," +
                $"[SessionID] = {SQLWorker.GetID(obj.Session)}," +
                $"[TeacherID] = {SQLWorker.GetID(obj.Teacher)}" +
                $"WHERE [ID] = {obj.Id}");
        }
    }
}
