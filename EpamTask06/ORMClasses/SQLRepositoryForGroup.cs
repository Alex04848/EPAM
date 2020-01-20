using EpamTask06.ClassesOfUniversity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ORMClasses
{
    public class SQLRepositoryForGroup : IRepository<Group>
    {
        //--------------------------Singleton-----------------------

        static Lazy<SQLRepositoryForGroup> repository =
            new Lazy<SQLRepositoryForGroup>(() => new SQLRepositoryForGroup());

        public static SQLRepositoryForGroup Repository => repository.Value;

        //-----------------------------------------------------------


        SqlConnection connection;

        SqlCommand command;

        SqlDataReader reader;

        IRepository<Speciality> repositoryOfSpecialities = SQLRepositoryForSpeciality.Repository;


        SQLRepositoryForGroup()
        {
            connection = new SqlConnection(SQLWorker.connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }



        public void Create(Group obj)
        {
            if(SQLWorker.CheckExistance(obj.SpecialityOfGroup))
                throw new DBException("Incorrect speciality!!!");


            SQLWorker.SimpleQuery($"INSERT INTO [Group]" +
                $" VALUES ({obj.NumOfCourse},{obj.NumOfGroup},{SQLWorker.GetID(obj.SpecialityOfGroup)})");
        }

        public void Delete(int id)
                => SQLWorker.SimpleQuery($"DELETE FROM [Group] WHERE [ID] = {id}");

        public IEnumerable<Group> GetCollection()
        {
            List<Group> groups = new List<Group>();
            List<int> idValues = SQLWorker.GetIDValuesForTable("Group").ToList();

            idValues.ForEach(idValue => groups.Add(Read(idValue)));

            return groups;
        }

        public Group Read(int id)
        {
            Group group = null;

            connection.Open();
            command.CommandText = "SELECT * FROM [Group]";
            reader = command.ExecuteReader();

            if(reader.Read())
                group = new Group(reader.GetInt32(1), reader.GetInt32(2), repositoryOfSpecialities.Read(reader.GetInt32(3)));
            

            connection.Close();



            return group;
        }

        public void Update(Group obj)
        {
            if (SQLWorker.CheckExistance(obj.SpecialityOfGroup))
                throw new DBException("Incorrect speciality!!!");


            SQLWorker.SimpleQuery($"UPDATE [Group] SET " +
                $"[NumOfCourse] = {obj.NumOfCourse},[NumOfGroup] = {obj.NumOfGroup},[GroupID] = {SQLWorker.GetID(obj.SpecialityOfGroup)}");
        }


    }
}
