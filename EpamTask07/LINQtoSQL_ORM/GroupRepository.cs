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
    public class GroupRepository : IRepository<Group>
    {
        //--------------------Singleton-------------------

        static Lazy<GroupRepository> repository =
            new Lazy<GroupRepository>(() => new GroupRepository());

        public static GroupRepository GetRepository => repository.Value;

        //------------------------------------------------

        DataContext db;

        IRepository<Speciality> repositoryForSpeciality = SpecialityRepository.GetRepository;


        GroupRepository()
        {
            db = new DataContext(DBHelper.connectionString);
        }


        public void Create(Group obj)
            => db.ExecuteCommand($"INSERT INTO [Group] VALUES " +
                $"({obj.NumOfCourse}," +
                $"{obj.NumOfGroup}" +
                $",{DBHelper.GetID(obj.SpecialityOfGroup)})");

        public void Delete(int id)
            => db.ExecuteCommand($"DELETE FROM [Group] WHERE [ID] = {id}");

        public IEnumerable<Group> GetCollection()
        {
            List<Group> groups = new List<Group>();
            List<int> idValues = db.ExecuteQuery<int>("SELECT [ID] FROM [Group]").ToList();
            
            idValues.ForEach(idValue => groups.Add(Read(idValue)));


            return groups;
        }

        public Group Read(int id)
        {
            Group group = db.ExecuteQuery<Group>($"SELECT * FROM [Group] WHERE [ID] = {id}")
                .FirstOrDefault();

            if(group != null)
            {
                int idValue = db.ExecuteQuery<int>($"SELECT [SpecialityID] FROM [Group] WHERE [ID] = {id}").FirstOrDefault();
                group.SpecialityOfGroup = repositoryForSpeciality.Read(idValue);
            }


            return group;
        }

        public void Update(Group obj)
            => db.ExecuteCommand($"UPDATE [Group] SET " +
                $"[NumOfCourse] = {obj.NumOfCourse}," +
                $"[NumOfGroup] = {obj.NumOfGroup}," +
                $"[SpecialityID] = {DBHelper.GetID(obj.SpecialityOfGroup)}" +
                $"WHERE [ID] = {obj.Id}");
    }
}
