using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask07.LINQtoSQL_ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EpamTask07.LINQtoSQL_ORM.DBHelper;
using EpamTask06.ClassesOfUniversity;
using EpamTask06;

namespace EpamTask07.LINQtoSQL_ORM.Tests
{
    /// <summary>
    /// The Class which test CRUD of ORM class for Student
    /// </summary>
    [TestClass()]
    public class StudentRepositoryTests
    {
        IRepository<Student> repository = StudentRepository.GetRepository;

        IRepository<Group> repositoryForGroup = GroupRepository.GetRepository;

        IRepository<Speciality> repositoryForSpeciality = SpecialityRepository.GetRepository;


        [TestMethod()]
        public void CreateAndDeleteTest()
        {
            //arrange
            Speciality speciality = new Speciality("For Student", "Test Spec");
            Group group = new Group(1, 1, speciality);
            Student student = new Student("Test Student", DateTime.Now, group, Gender.Male);
            bool result;

            //act
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repository.Create(student);

            result = CheckExistance(student);

            repository.Delete(GetID(student));
            repositoryForGroup.Delete(GetID(group));
            repositoryForSpeciality.Delete(GetID(speciality));

            result = result && !CheckExistance(student);


            //assert
            Assert.IsTrue(result);
        }


        [TestMethod()]
        public void GetCollectionTest()
        {
            //arrange
            var students = repository.GetCollection();

            //assert
            Assert.IsTrue(students.All(student => CheckExistance(student)));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void ReadTest(int idValue)
        {
            //arrange
            Student student = repository.Read(idValue);

            //assert
            Assert.IsTrue(CheckExistance(student));
        }


        [TestMethod()]
        public void UpdateAndDeleteTest()
        {
            //arrange
            Speciality speciality = new Speciality("TS_ForSt`1", "Test Speciality");
            Group group = new Group(1, 1, speciality);
            Student student = new Student("Test Student`1", DateTime.Now, group, Gender.Male);
            bool result;

            //act
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repository.Create(student);

            result = CheckExistance(student);
            student.Id = GetID(student);

            student.FullName = "Change Test";

            repository.Update(student);

            result = result && CheckExistance(student);

            repository.Delete(GetID(student));
            repositoryForGroup.Delete(GetID(group));
            repositoryForSpeciality.Delete(GetID(speciality));


            //assert
            Assert.IsTrue(result);
        }


    }
}