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
    public class SpecialityRepository : IRepository<Speciality>
    {
        //--------------------Singleton-------------------

        static Lazy<SpecialityRepository> repository =
            new Lazy<SpecialityRepository>(() => new SpecialityRepository());

        public static SpecialityRepository GetRepository => repository.Value;

        //------------------------------------------------


        DataContext db;

        SpecialityRepository()
        {
            db = new DataContext(DBHelper.connectionString);
        }


        public void Create(Speciality obj)
            => db.ExecuteCommand($"INSERT INTO [Speciality] VALUES " +
                $"(N'{obj.AbreviationOfSpeciality}'," +
                $"N'{obj.NameOfSpeciality}')");

        public void Delete(int id)
            => db.ExecuteCommand($"DELETE FROM [Speciality] WHERE [ID] = {id}");

        public IEnumerable<Speciality> GetCollection()
            => db.GetTable<Speciality>();

        public Speciality Read(int id)
            => db.ExecuteQuery<Speciality>($"SELECT * FROM [Speciality] WHERE [ID] = {id}")
            .FirstOrDefault();

        public void Update(Speciality obj)
                => db.ExecuteCommand($"UPDATE [Speciality] SET" +
                    $" [AbreviationOfSpeciality] = N'{obj.AbreviationOfSpeciality}'," +
                    $"[FullNameOfSpeciality] = N'{obj.NameOfSpeciality}'" +
                    $"WHERE [ID] = {obj.Id}");
    }
}
