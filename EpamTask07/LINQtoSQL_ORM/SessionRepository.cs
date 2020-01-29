using EpamTask06;
using EpamTask06.ClassesOfUniversity;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask07.LINQtoSQL_ORM
{
    public class SessionRepository : IRepository<Session>
    {
        //--------------------Singleton-------------------

        static Lazy<SessionRepository> repository =
            new Lazy<SessionRepository>(() => new SessionRepository());

        public static SessionRepository GetRepository => repository.Value;

        //------------------------------------------------


        DataContext db;

        SessionRepository()
        {
            db = new DataContext(DBHelper.connectionString);
        }

        public void Create(Session obj)
        {
            db.GetTable<Session>().InsertOnSubmit(obj);

            db.SubmitChanges();
        }

        public void Delete(int id)
                => db.ExecuteCommand($"DELETE FROM [Session] WHERE [ID] = {id}");

        public IEnumerable<Session> GetCollection()
                => db.GetTable<Session>();


        public Session Read(int id)
            => db.ExecuteQuery<Session>($"SELECT * FROM [Session] WHERE [ID] = {id}")
            .FirstOrDefault();

        public void Update(Session obj)
                => db.ExecuteCommand($"UPDATE [Session] SET " +
                    $"[NameOfSession] = N'{obj.NameOfSession}'," +
                    $"[StartDate] = '{obj.StartDate.ToString("yyyy-MM-dd")}'," +
                    $"[EndDate] = '{obj.EndDate.ToString("yyyy-MM-dd")}' " +
                    $"WHERE [ID] = {obj.Id}");

    }
}
