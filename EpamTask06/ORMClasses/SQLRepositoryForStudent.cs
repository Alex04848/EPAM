using EpamTask06.ClassesOfUniversity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ORMClasses
{
    public class SQLRepositoryForStudent : IRepository<Student>
    {
        //--------------------------Singleton------------------------

        static Lazy<SQLRepositoryForStudent> repository =
            new Lazy<SQLRepositoryForStudent>(() => new SQLRepositoryForStudent());

        public static SQLRepositoryForStudent Repository => repository.Value;

        //-----------------------------------------------------------


        SqlConnection connection;

        SqlCommand command;

        SqlDataReader reader;

        IRepository<Group> repositoryOfGroups = SQLRepositoryForGroup.Repository;

        SQLRepositoryForStudent()
        {
            connection = new SqlConnection();
            command = new SqlCommand();
            command.Connection = connection;
        }



        public void Create(Student obj)
        {
            if (!SQLWorker.CheckExistance(obj.StudentGroup))
                throw new DBException("Incorrect group!!!");

            SQLWorker.SimpleQuery($"INSERT INTO [Student]" +
                $" VALUES (N'{obj.FullName}','{obj.DateOfBirth.ToString("yyyy-MM-dd")}'," +
                $"{SQLWorker.GetID(obj.StudentGroup)},{obj.Gender})");
        }

        public void Delete(int id)
             => SQLWorker.SimpleQuery($"DELETE FROM [Student] WHERE [ID] = {id}");

        public IEnumerable<Student> GetCollection()
        {
            List<Student> students = new List<Student>();
            List<int> idValues = SQLWorker.GetIDValuesForTable("Student").ToList();

            idValues.ForEach(idValue => students.Add(Read(idValue)));

            return students;
        }

        public Student Read(int id)
        {
            Student student = null;
            connection.Open();

            command.CommandText = "SELECT * FROM [Student]";
            reader = command.ExecuteReader();

            if(reader.Read())
            {
                student = new Student(reader.GetString(1), reader.GetDateTime(2), 
                    repositoryOfGroups.Read(reader.GetInt32(3)),(Gender)reader.GetInt32(4));
                student.Id = reader.GetInt32(0);
            }

            connection.Close();

            return student;
        }

        public void Update(Student obj)
        {
            if (!SQLWorker.CheckExistance(obj.StudentGroup))
                throw new DBException("Incorrect group!!!");

            SQLWorker.SimpleQuery($"UPDATE [Student] SET" +
                $" [FullName] = N'{obj.FullName}',[DateOfBirth] = '{obj.DateOfBirth.ToString("yyyy-MM-dd")}'," +
                $" [GroupID] = {SQLWorker.GetID(obj.StudentGroup)}, [Gender] = {obj.Gender}");
        }
    }
}
