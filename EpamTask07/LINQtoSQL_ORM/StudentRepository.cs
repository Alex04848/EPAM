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
    /// <summary>
    /// Repository for Student Table
    /// </summary>
    public class StudentRepository : IRepository<Student>
    {
        //--------------------Singleton-------------------

        static Lazy<StudentRepository> repository =
            new Lazy<StudentRepository>(() => new StudentRepository());

        public static StudentRepository GetRepository => repository.Value;

        //------------------------------------------------

        DataContext db;

        IRepository<Group> repositoryForGroup = GroupRepository.GetRepository;

        StudentRepository()
        {
            db = new DataContext(DBHelper.connectionString);
        }


        public void Create(Student obj)
            => db.ExecuteCommand($"INSERT INTO [Student] VALUES" +
                $" (N'{obj.FullName}'," +
                $"'{obj.DateOfBirth.ToString("yyyy-MM-dd")}'," +
                $"{DBHelper.GetID(obj.StudentGroup)}," +
                $"{(int)obj.Gender})");

        public void Delete(int id)
            => db.ExecuteCommand($"DELETE FROM [Student] WHERE [ID] = {id}");

        public IEnumerable<Student> GetCollection()
        {
            List<Student> students = new List<Student>();
            List<int> idValues = db.ExecuteQuery<int>($"SELECT [ID] FROM [Student]").ToList();
            
            idValues.ForEach(idValue => students.Add(Read(idValue)));

            return students;
        }

        public Student Read(int id)
        {
            Student student = db.ExecuteQuery<Student>($"SELECT * FROM [Student] WHERE [ID] = {id}").FirstOrDefault();

            if(student != null)
            {
                int idValue = db.ExecuteQuery<int>($"SELECT [GroupID] FROM [Student] WHERE [ID] = {id}").FirstOrDefault();
                student.StudentGroup = repositoryForGroup.Read(idValue);
            }


            return student;
        }

        public void Update(Student obj)
            => db.ExecuteCommand($"UPDATE [Student] SET " +
                $"[FullName] = N'{obj.FullName}'," +
                $"[DateOfBirth] = '{obj.DateOfBirth.ToString("yyyy-MM-dd")}'," +
                $"[GroupID] = {DBHelper.GetID(obj.StudentGroup)}," +
                $"[Gender] = {(int)obj.Gender}" +
                $"WHERE [ID] = {obj.Id}");
    }
}
