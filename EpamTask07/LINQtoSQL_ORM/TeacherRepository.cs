using EpamTask06;
using EpamTask06.ClassesOfUniversity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Linq;

namespace EpamTask07.LINQtoSQL_ORM
{
    public class TeacherRepository : IRepository<Teacher>
    {
        //-----------------Singleton----------------------

        static Lazy<TeacherRepository> repository = 
            new Lazy<TeacherRepository>(() => new TeacherRepository());

        public static TeacherRepository GetRepository => repository.Value;

        //------------------------------------------------


        DataContext db;


        TeacherRepository()
        {
            db = new DataContext(DBHelper.connectionString);
        }


        public void Create(Teacher obj)
            => db.ExecuteCommand($"INSERT INTO [Teacher] VALUES " +
                $"(N'{obj.FullName}','{obj.DateOfBirth.ToString("yyyy-MM-dd")}',{(int)obj.Gender})");

        public void Delete(int id)
                => db.ExecuteCommand($"DELETE FROM [Teacher] WHERE [ID] = {id}");

        public IEnumerable<Teacher> GetCollection()
                => db.GetTable<Teacher>();

        public Teacher Read(int id)
            => db.ExecuteQuery<Teacher>($"SELECT * FROM [Teacher] WHERE [ID] = {id}").FirstOrDefault();

        public void Update(Teacher obj)
            => db.ExecuteCommand($"UPDATE [Teacher] SET" +
                $" [FullName] = N'{obj.FullName}'," +
                $"[DateOfBirth] = '{obj.DateOfBirth.ToString("yyyy-MM-dd")}'," +
                $"[Gender] = {(int)obj.Gender}" +
                $" WHERE [ID] = {obj.Id}");
    }
}
