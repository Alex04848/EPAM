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
    /// <summary>
    /// The Class which test CRUD of ORM class for Speciality
    /// </summary>
    [TestClass()]
    public class SQLRepositoryForSpecialityTests
    {
        IRepository<Speciality> repository = SQLRepositoryForSpeciality.Repository;


        [TestMethod()]
        public void CreateDeleteTest()
        {
            //arrange
            Speciality speciality = new Speciality("TS", "Test Speciality");
            bool result;

            //act
            repository.Create(speciality);
            result = SQLWorker.CheckExistance(speciality);
            speciality.Id = SQLWorker.GetID(speciality);

            repository.Delete(speciality.Id);
            result = result && !SQLWorker.CheckExistance(speciality);

            //assert
            Assert.IsTrue(result);
        }


        [TestMethod()]
        public void GetCollectionTest()
        {
            //arrange
            var specialities = repository.GetCollection();

            //assert
            Assert.IsTrue(specialities.All(speciality => SQLWorker.CheckExistance(speciality)));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public void ReadTest(int idValue)
        {
            //arrange 
            Speciality speciality = repository.Read(idValue);

            //assert
            Assert.IsTrue(SQLWorker.CheckExistance(speciality));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            //arrange
            Speciality speciality = new Speciality("TS", "Test Speciality");
            bool result;

            //act
            repository.Create(speciality);
            result = SQLWorker.CheckExistance(speciality);
            speciality.Id = SQLWorker.GetID(speciality);
            speciality.NameOfSpeciality = "Test Change";
            repository.Update(speciality);
            result = result && SQLWorker.CheckExistance(speciality);
            repository.Delete(speciality.Id);


            //assert
            Assert.IsTrue(result);
        }
    }
}