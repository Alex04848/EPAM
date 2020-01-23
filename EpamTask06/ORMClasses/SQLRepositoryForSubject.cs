using EpamTask06.ClassesOfUniversity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EpamTask06.ORMClasses
{
    /// <summary>
    /// Repository for Subject Table
    /// </summary>
    public class SQLRepositoryForSubject : IRepository<Subject>
    {
        //--------------------------Singleton-----------------------

        static Lazy<SQLRepositoryForSubject> repository =
            new Lazy<SQLRepositoryForSubject>(() => new SQLRepositoryForSubject());

        public static SQLRepositoryForSubject Repository => repository.Value;

        //-----------------------------------------------------------



        SqlConnection connection;

        SqlCommand command;

        SqlDataReader reader;

        SQLRepositoryForSubject()
        {
            connection = new SqlConnection(SQLWorker.connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }


        public void Create(Subject obj)
          => SQLWorker.SimpleQuery($"INSERT INTO [Subject] VALUES (N'{obj.NameOfSubject}',{obj.CountOfLections},{obj.CountOfPractice})");

        public void Delete(int id)
           => SQLWorker.SimpleQuery($"DELETE FROM [Subject] WHERE [ID] = {id}");

        public IEnumerable<Subject> GetCollection()
        {
            List<Subject> subjects = new List<Subject>();

            var idValues = SQLWorker.GetIDValuesForTable("Subject").ToList();

            idValues.ForEach(idValue => subjects.Add(Read(idValue)));


            return subjects;
        }

        public Subject Read(int id)
        {
            Subject subject = null;

            connection.Open();
            command.CommandText = $"SELECT * FROM [Subject] WHERE [ID] = {id}";
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                subject = new Subject(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                subject.Id = reader.GetInt32(0);
            }


            connection.Close();
            return subject;
        }

        public void Update(Subject obj)
            => SQLWorker.SimpleQuery($"UPDATE [Subject] SET [NameOfSubject] = N'{obj.NameOfSubject}'," +
                $"[CountOfLections] = {obj.CountOfLections}, [CountOfPractice] = {obj.CountOfPractice} " +
                $"WHERE [ID] = {obj.Id}");

    }
}
