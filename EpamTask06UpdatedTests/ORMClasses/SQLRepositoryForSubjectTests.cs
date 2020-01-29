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
    /// The Class which test CRUD of ORM class for Subject
    /// </summary>
    [TestClass()]
    public class SQLRepositoryForSubjectTests
    {
        IRepository<Subject> repository = SQLRepositoryForSubject.Repository;


        [DataTestMethod()]
        public void CreateAndDeleteTest()
        {
            //arrange
            Subject subject = new Subject("TestSubj", 0, 0);
            bool result;


            //act
            repository.Create(subject);
            result = SQLWorker.CheckExistance(subject);
            repository.Delete(SQLWorker.GetID(subject));
            result = result && !SQLWorker.CheckExistance(subject);

            //assert
            Assert.IsTrue(result);
        }

        [DataTestMethod()]
        public void GetCollectionTest()
        {          
            //arrange
            var subjects = repository.GetCollection().ToList();

            //assert
            Assert.IsTrue(subjects.All(subj => SQLWorker.CheckExistance(subj)));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void ReadTest(int idValue)
        {
            //arrange
            var subj = repository.Read(idValue);

            //assert
            Assert.IsTrue(SQLWorker.CheckExistance(subj));
        }


        [TestMethod()]
        public void CreateAndUpdateTest()
        {
            //arrange
            Subject subject = new Subject("TestSubj", 0, 0);
            bool result;


            //act
            repository.Create(subject);
            subject.Id = SQLWorker.GetID(subject);
            result = SQLWorker.CheckExistance(subject);
            subject.NameOfSubject = "TestChange";
            repository.Update(subject);
            result = result && SQLWorker.CheckExistance(subject);
            repository.Delete(subject.Id);


            //assert
            Assert.IsTrue(result);
        }


    }
}