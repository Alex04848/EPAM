using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask07.LINQtoSQL_ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask06;
using EpamTask06.ClassesOfUniversity;
using static EpamTask07.LINQtoSQL_ORM.DBHelper;

namespace EpamTask07.LINQtoSQL_ORM.Tests
{
    [TestClass()]
    public class TeacherRepositoryTests
    {
        IRepository<Teacher> repository = TeacherRepository.GetRepository;


        [TestMethod()]
        public void CreateAndDeleteTest()
        {
            //arrange
            Teacher teacher = new Teacher("TestTeacher", DateTime.Now, Gender.Male);
            bool result;

            //act
            repository.Create(teacher);
            result = CheckExistance(teacher);
            repository.Delete(GetID(teacher));
            result = result && !CheckExistance(teacher); 

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetCollectionTest()
        {
            //arrange
            List<Teacher> teachers = repository.GetCollection().ToList();

            //assert
            Assert.IsNotNull(teachers);
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
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
            teacher.Id = GetID(teacher);
            result = CheckExistance(teacher);

            teacher.FullName += " Updated";
            repository.Update(teacher);

            result = result && CheckExistance(teacher);

            repository.Delete(teacher.Id);


            //assert
            Assert.IsTrue(result);
        }
    }
}