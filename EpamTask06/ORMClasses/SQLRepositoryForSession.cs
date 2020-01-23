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
    /// Repository for Session Table
    /// </summary>
    public class SQLRepositoryForSession : IRepository<Session>
    {

        //--------------------------Singleton-----------------------

        static Lazy<SQLRepositoryForSession> repository =
            new Lazy<SQLRepositoryForSession>(() => new SQLRepositoryForSession());

        public static SQLRepositoryForSession Repository => repository.Value;

        //-----------------------------------------------------------


        SqlConnection connection;

        SqlCommand command;

        SqlDataReader reader;


        SQLRepositoryForSession()
        {
            connection = new SqlConnection(SQLWorker.connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }


        public void Create(Session obj)
            => SQLWorker.SimpleQuery($"INSERT INTO [Session] VALUES" +
                $" (N'{obj.NameOfSession}','{obj.StartDate.ToString("yyyy-MM-dd")}','{obj.EndDate.ToString("yyyy-MM-dd")}')");

        public void Delete(int id)
            => SQLWorker.SimpleQuery($"DELETE FROM [Session] WHERE [ID] = {id}");

        public IEnumerable<Session> GetCollection()
        {
            List<Session> sessions = new List<Session>();
            List<int> idValues = SQLWorker.GetIDValuesForTable("Session").ToList();

            idValues.ForEach(idValue => sessions.Add(Read(idValue)));


            return sessions;
        }

        public Session Read(int id)
        {
            Session session = null;

            connection.Open();
            command.CommandText = $"SELECT * FROM [Session] WHERE [ID] = {id}";
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                session = new Session(reader.GetString(1),reader.GetDateTime(2), reader.GetDateTime(3));
                session.Id = reader.GetInt32(0);
            }

            connection.Close();

            return session;
        }

        public void Update(Session obj)
            => SQLWorker.SimpleQuery($"UPDATE [Session] SET " +
                $"[NameOfSession] = N'{obj.NameOfSession}'," +
                $"[StartDate] = '{obj.StartDate.ToString("yyyy-MM-dd")}'," +
                $"[EndDate] = '{obj.EndDate.ToString("yyyy-MM-dd")}'" +
                $" WHERE [ID] = {obj.Id}");

    }
}
