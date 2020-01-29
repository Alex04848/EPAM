using EpamTask06;
using EpamTask06.ClassesOfUniversity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EpamTask06.ORMClasses
{
    public class SQLRepositoryForTeacher : IRepository<Teacher>
    {
        //-------------------Singleton-------------------------

        static Lazy<SQLRepositoryForTeacher> repository =
            new Lazy<SQLRepositoryForTeacher>(() => new SQLRepositoryForTeacher());

        public static SQLRepositoryForTeacher Repository = repository.Value;

        //-----------------------------------------------------


        SqlConnection connection;

        SqlCommand command;

        SqlDataReader reader;


        SQLRepositoryForTeacher()
        {
            connection = new SqlConnection(SQLWorker.connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }



        public void Create(Teacher obj)
            => SQLWorker.SimpleQuery($"INSERT INTO [Teacher] VALUES (N'{obj.FullName}'," +
                $"'{obj.DateOfBirth.ToString("yyyy-MM-dd")}',{(int)obj.Gender})");

        public void Delete(int id)
            => SQLWorker.SimpleQuery($"DELETE [Teacher] WHERE [ID] = {id}");

        public IEnumerable<Teacher> GetCollection()
        {
            List<Teacher> teachers = new List<Teacher>();
            List<int> idValues = SQLWorker.GetIDValuesForTable("Teacher").ToList();

            idValues.ForEach(idValue => teachers.Add(Read(idValue)));

            return teachers;
        }

        public Teacher Read(int id)
        {
            Teacher teacher = new Teacher();
            connection.Open();
            command.CommandText = $"SELECT * FROM [Teacher] WHERE [ID] = {id}";
            reader = command.ExecuteReader();

            if (reader.Read())       
                teacher = new Teacher(reader.GetString(1), reader.GetDateTime(2), (Gender)(reader.GetInt32(3))) { Id = reader.GetInt32(0) };

            connection.Close();


            return teacher;
        }

        public void Update(Teacher obj)
                => SQLWorker.SimpleQuery($"UPDATE [Teacher] SET [FullName] = N'{obj.FullName}'," +
                    $"[DateOfBirth] = '{obj.DateOfBirth.ToString("yyyy-MM-dd")}'," +
                    $"[Gender] = {(int)obj.Gender} " +
                    $"WHERE [ID] = {obj.Id}");
    }
}
