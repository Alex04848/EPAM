using EpamTask06.ClassesOfUniversity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EpamTask06.ORMClasses
{
    public class SQLRepositoryForSpeciality : IRepository<Speciality>
    {
        //--------------------------Singleton-----------------------

        static Lazy<SQLRepositoryForSpeciality> repository = 
            new Lazy<SQLRepositoryForSpeciality>(() => new SQLRepositoryForSpeciality());

        public static SQLRepositoryForSpeciality Repository => repository.Value;

        //-----------------------------------------------------------


        SqlConnection connection;

        SqlCommand command;

        SqlDataReader reader;


        private SQLRepositoryForSpeciality()
        {
            connection = new SqlConnection(SQLWorker.connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }

        public void Create(Speciality obj)
            => SQLWorker.SimpleQuery($"INSERT INTO [Speciality] VALUES (N'{obj.AbreviationOfSpeciality}',N'{obj.NameOfSpeciality}')");

        public void Delete(int id)
            => SQLWorker.SimpleQuery($"DELETE FROM [Speciality] WHERE [ID] = {id}");
     
        public IEnumerable<Speciality> GetCollection()
        {
            List<Speciality> specialities = new List<Speciality>();
            List<int> idValues = SQLWorker.GetIDValuesForTable("Speciality").ToList();

            idValues.ForEach(idValue => specialities.Add(Read(idValue)));

            
            return specialities;
        }

        public Speciality Read(int id)
        {
            Speciality speciality = null;
            connection.Open();

            command.CommandText = $"SELECT * FROM [Speciality] WHERE [ID] = {id}";
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                speciality = new Speciality(reader.GetString(1), reader.GetString(2));
                speciality.Id = reader.GetInt32(0);
            }

            connection.Close();



            return speciality;
        }

        public void Update(Speciality obj)
            => SQLWorker.SimpleQuery($"UPDATE [Speciality] " +
                $"SET [AbreviationOfSpeciality] = N'{obj.AbreviationOfSpeciality}',[FullNameOfSpeciality] = N'{obj.NameOfSpeciality}' " +
                $"WHERE [ID] = {obj.Id}");

    }
}
