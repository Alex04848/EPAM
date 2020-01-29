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
    /// The Class which test CRUD of ORM class for Session
    /// </summary>
    [TestClass()]
    public class SQLRepositoryForSessionTests
    {
        IRepository<Session> repository = SQLRepositoryForSession.Repository;


        [TestMethod()]
        public void CreateAndDeleteTest()
        {
            //arrange
            Session session = new Session("TestValue", DateTime.MinValue, DateTime.MaxValue);
            bool result;

            //act
            repository.Create(session);
            result = SQLWorker.CheckExistance(session);
            repository.Delete(SQLWorker.GetID(session));
            result = result && !SQLWorker.CheckExistance(session);


            //assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetCollectionTest()
        {
            //arrange
            var sessions = repository.GetCollection();

            //assert
            Assert.IsTrue(sessions.All(session => SQLWorker.CheckExistance(session)));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public void ReadTest(int idValue)
        {
            //arrange
            Session session = repository.Read(idValue);
            
            //assert
            Assert.IsTrue(SQLWorker.CheckExistance(session));
        }

        [TestMethod()]
        public void CreateAndUpdateTest()
        {
            //arrange
            Session session = new Session("TestValue", DateTime.MinValue, DateTime.MaxValue);
            bool result;

            //act
            repository.Create(session);
            result = SQLWorker.CheckExistance(session);
            session.Id = SQLWorker.GetID(session);
            session.NameOfSession = "ChangedName";

            repository.Update(session);
            result = result && SQLWorker.CheckExistance(session);
            repository.Delete(session.Id);


            //assert
            Assert.IsTrue(result);
        }

    }
}