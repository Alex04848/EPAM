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
    /// Repository for Subject Table
    /// </summary>
    public class SubjectRepository : IRepository<Subject>
    {
        //--------------------Singleton-------------------

        static Lazy<SubjectRepository> repository =
            new Lazy<SubjectRepository>(() => new SubjectRepository());

        public static SubjectRepository GetRepository => repository.Value;

        //------------------------------------------------

        DataContext db;

        SubjectRepository()
        {
            db = new DataContext(DBHelper.connectionString);
        }


        public void Create(Subject obj)
            => db.ExecuteCommand($"INSERT INTO [Subject] VALUES " +
                $"(N'{obj.NameOfSubject}'," +
                $"{obj.CountOfLections}," +
                $"{obj.CountOfPractice})");

        public void Delete(int id)
            => db.ExecuteCommand($"DELETE FROM [Subject] WHERE [ID] = {id}");

        public IEnumerable<Subject> GetCollection()
             => db.GetTable<Subject>();

        public Subject Read(int id)
            => db.ExecuteQuery<Subject>($"SELECT * FROM [Subject] WHERE [ID] = {id}")
            .FirstOrDefault();

        public void Update(Subject obj)
             => db.ExecuteCommand($"UPDATE [Subject] SET" +
                 $" [NameOfSubject] = N'{obj.NameOfSubject}'," +
                 $"[CountOfLections] = {obj.CountOfLections}," +
                 $"[CountOfPractice] = {obj.CountOfPractice}" +
                 $"WHERE [ID] = {obj.Id}");
    }
}
