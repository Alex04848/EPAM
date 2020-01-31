using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask07.LINQtoSQL_ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask06.ClassesOfUniversity;
using EpamTask06;
using static EpamTask07.LINQtoSQL_ORM.DBHelper;

namespace EpamTask07.LINQtoSQL_ORM.Tests
{
    /// <summary>
    /// The Class which test CRUD of ORM class for Subject
    /// </summary>
    [TestClass()]
    public class SubjectRepositoryTests
    {
        IRepository<Subject> repository = SubjectRepository.GetRepository;


        [TestMethod()]
        public void CreateAndDeleteTest()
        {
            //arrange
            Subject subject = new Subject("TestSubject",10,10);
            bool result;

            //act
            repository.Create(subject);
            result = CheckExistance(subject);
            repository.Delete(GetID(subject));
            result = result & !CheckExistance(subject);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetCollectionTest()
        {
            //arrange
            var subjects = repository.GetCollection().ToList();

            //assert
            Assert.IsNotNull(subjects);
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public void ReadTest(int idValue)
        {
            //arrange
            Subject subject = repository.Read(idValue);

            //assert
            Assert.IsNotNull(subject);
        }

        [TestMethod()]
        public void UpdateTest()
        {  
            //arrange
            Subject subject = new Subject("TestSubject", 0, 10);
            bool result;

            //act
            repository.Create(subject);
            subject.Id = GetID(subject);
            result = CheckExistance(subject);

            subject.NameOfSubject += " Updated";
            repository.Update(subject);
            
            result = result & CheckExistance(subject);
            repository.Delete(subject.Id);

            //assert
            Assert.IsTrue(result);
        }
    }
}