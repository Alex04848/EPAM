using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask06.ORMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask06.ClassesOfUniversity;

namespace EpamTask06.ORMClasses.Tests
{
    [TestClass()]
    public class SQLRepositoryForGroupTests
    {
        IRepository<Group> repository = SQLRepositoryForGroup.Repository;

        IRepository<Speciality> repositoryForSpeciality = SQLRepositoryForSpeciality.Repository;

        [TestMethod()]
        public void CreateAndDeleteTest()
        {
            //arrange
            Speciality speciality = new Speciality("TS", "Test Speciality");
            Group group = new Group(1,1,speciality);
            bool result;

            //act
            repositoryForSpeciality.Create(speciality);
            repository.Create(group);

            result = SQLWorker.CheckExistance(group);

            repository.Delete(SQLWorker.GetID(group));
            repositoryForSpeciality.Delete(SQLWorker.GetID(speciality));

            result = result && !SQLWorker.CheckExistance(group);



            Assert.IsTrue(result);
        }


        [TestMethod()]
        public void GetCollectionTest()
        {
            //arrange
            var groups = repository.GetCollection();

            //assert
            Assert.IsTrue(groups.All(group => SQLWorker.CheckExistance(group)));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public void ReadTest(int idValue)
        {
            //arrange
            Group group = repository.Read(idValue);

            //assert
            Assert.IsTrue(SQLWorker.CheckExistance(group));
        }

        [TestMethod()]
        public void UpdateAndDeleteTest()
        {
            //arrange
            Speciality speciality = new Speciality("TS", "Test Speciality");
            Group group = new Group(1, 1, speciality);
            bool result;

            //act
            repositoryForSpeciality.Create(speciality);
            repository.Create(group);

            result = SQLWorker.CheckExistance(group);
            group.Id = SQLWorker.GetID(group);

            group.NumOfCourse++;
            group.NumOfGroup++;

            repository.Update(group);

            result = result && SQLWorker.CheckExistance(group);

            repository.Delete(group.Id);
            repositoryForSpeciality.Delete(SQLWorker.GetID(speciality));

           
            //assert
            Assert.IsTrue(result);
        }

    }
}