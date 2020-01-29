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
    public class SQLRepositoryForTeacherTests
    {

        IRepository<Teacher> repository = SQLRepositoryForTeacher.Repository;

        [TestMethod()]
        public void CreateAndDeleteTest()
        {
            //arrange
            Teacher teacher = new Teacher("TestTeacher",DateTime.Now,Gender.Male);
            bool result;

            //act
            repository.Create(teacher);
            result = SQLWorker.CheckExistance(teacher);
            repository.Delete(SQLWorker.GetID(teacher));
            result = result && !SQLWorker.CheckExistance(teacher);


            //assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetCollectionTest()
        {
            //arrange
            var teachers = repository.GetCollection().ToList();

            //assert
            Assert.IsTrue(teachers.All(teacher => SQLWorker.CheckExistance(teacher)));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void ReadTest(int idValue)
        {
            //arrange
            Teacher teacher = repository.Read(idValue);


            //assert
            Assert.IsNotNull(teacher);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            //arrange
            Teacher teacher = new Teacher("TestTeacher", DateTime.Now, Gender.Male);
            bool result;

            //act
            repository.Create(teacher);
            result = SQLWorker.CheckExistance(teacher);

            teacher.Id = SQLWorker.GetID(teacher);
            teacher.FullName += " Updated";
            repository.Update(teacher);
          
            result = result && SQLWorker.CheckExistance(teacher);
            repository.Delete(SQLWorker.GetID(teacher));


            //assert
            Assert.IsTrue(result);
        }
    }
}