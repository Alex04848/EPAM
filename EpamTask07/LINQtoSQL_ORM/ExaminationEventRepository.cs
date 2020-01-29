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
    public class ExaminationEventRepository : IRepository<ExaminationEvent>
    {
        //--------------------Singleton-------------------

        static Lazy<ExaminationEventRepository> repository =
            new Lazy<ExaminationEventRepository>(() => new ExaminationEventRepository());

        public static ExaminationEventRepository GetRepository => repository.Value;

        //------------------------------------------------

        DataContext db;

        IRepository<Subject> repositoryForSubject = SubjectRepository.GetRepository;

        IRepository<Group> repositoryForGroup = GroupRepository.GetRepository;

        IRepository<Session> repositoryForSession = SessionRepository.GetRepository;

        IRepository<Teacher> repositoryForTeacher = TeacherRepository.GetRepository;


        ExaminationEventRepository()
        {
            db = new DataContext(DBHelper.connectionString);
        }


        public void Create(ExaminationEvent obj)
            => db.ExecuteCommand($"INSERT [ExaminationEvent] VALUES ({GetID(obj.Subject)}" +
                $",{GetID(obj.Group)}," +
                $"'{obj.Date.ToString("yyyy-MM-dd")}'," +
                $"{(int)obj.EventType}," +
                $"{GetID(obj.Session)}," +
                $"{GetID(obj.Teacher)})");

        public void Delete(int id)
            => db.ExecuteCommand($"DELETE FROM [ExaminationEvent] WHERE [ID] = {id}");

        public IEnumerable<ExaminationEvent> GetCollection()
        {
            List<ExaminationEvent> examinationEvents = new List<ExaminationEvent>();
            List<int> idValues = db.ExecuteQuery<int>($"SELECT [ID] FROM [ExaminationEvent]").ToList();

            idValues.ForEach(idValue => examinationEvents.Add(Read(idValue)));

            return examinationEvents;
        }

        public ExaminationEvent Read(int id)
        {
            ExaminationEvent examEvent = db.ExecuteQuery<ExaminationEvent>($"SELECT * FROM [ExaminationEvent] WHERE [ID] = {id}")
                .FirstOrDefault();

            if(examEvent != null)
            {
                examEvent.Subject = repositoryForSubject.Read(db.ExecuteQuery<int>($"SELECT [SubjectID] FROM [ExaminationEvent] WHERE [ID] = {id}")
                    .FirstOrDefault());
                examEvent.Group = repositoryForGroup.Read(db.ExecuteQuery<int>($"SELECT [GroupID] FROM [ExaminationEvent] WHERE [ID] = {id}")
                    .FirstOrDefault());
                examEvent.Session = repositoryForSession.Read(db.ExecuteQuery<int>($"SELECT [SessionID] FROM [ExaminationEvent] WHERE [ID] = {id}")
                    .FirstOrDefault());
                examEvent.Teacher = repositoryForTeacher.Read(db.ExecuteQuery<int>($"SELECT [TeacherID] FROM [ExaminationEvent] WHERE [ID] = {id}")
                    .FirstOrDefault());
            }

            return examEvent;
        }

        public void Update(ExaminationEvent obj)
            => db.ExecuteCommand($"UPDATE [ExaminationEvent] SET " +
                $"[SubjectID] = {GetID(obj.Subject)}," +
                $"[GroupID] = {GetID(obj.Group)}," +
                $"[DateOfExam] = '{obj.Date.ToString("yyyy-MM-dd")}'," +
                $"[TypeOfEvent] = {(int)obj.EventType}," +
                $"[SessionID] = {GetID(obj.Session)}," +
                $"[TeacherID] = {GetID(obj.Teacher)}" +
                $"WHERE [ID] = {obj.Id}");
    }
}
