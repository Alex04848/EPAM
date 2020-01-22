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
    public class SQLRepositoryForStudentsGradeTests
    {
        IRepository<StudentsGrade> repository = SQLRepositoryForStudentsGrade.Repository;


        IRepository<Subject> repositoryForSubject = SQLRepositoryForSubject.Repository;

        IRepository<Session> repositoryForSession = SQLRepositoryForSession.Repository;

        IRepository<Speciality> repositoryForSpeciality = SQLRepositoryForSpeciality.Repository;

        IRepository<Group> repositoryForGroup = SQLRepositoryForGroup.Repository;

        IRepository<Student> repositoryForStudent = SQLRepositoryForStudent.Repository;


        [TestMethod()]
        public void CreateAndDeleteTest()
        {
            //arrange
            Subject subject = new Subject("Test Subject",0,0);
            Session session = new Session("Test Session",DateTime.MinValue,DateTime.MaxValue);
            Speciality speciality = new Speciality("TS","Test Speciality");
            Group group = new Group(1, 1,speciality);
            Student student = new Student("Test Student",DateTime.Now,group,Gender.Male);

            StudentsGrade studentsGrade = new StudentsGrade(9,student,subject,session);
            bool result;

            //act
            repositoryForSubject.Create(subject);
            repositoryForSession.Create(session);
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repositoryForStudent.Create(student);

            repository.Create(studentsGrade);

            result = SQLWorker.CheckExistance(studentsGrade);

            repository.Delete(SQLWorker.GetID(studentsGrade));

            result = result && !SQLWorker.CheckExistance(studentsGrade);

            repositoryForStudent.Delete(SQLWorker.GetID(student));
            repositoryForGroup.Delete(SQLWorker.GetID(group));
            repositoryForSubject.Delete(SQLWorker.GetID(subject));
            repositoryForSpeciality.Delete(SQLWorker.GetID(speciality));
            repositoryForSession.Delete(SQLWorker.GetID(session));

            

            //assert
            Assert.IsTrue(result);
        }


        [TestMethod()]
        public void GetCollectionTest()
        {
            //arrange
            var grades = repository.GetCollection();

            //assert
            Assert.IsTrue(grades.All(grade => SQLWorker.CheckExistance(grade)));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void ReadTest(int idValue)
        {
            //arrange
            StudentsGrade grade = repository.Read(idValue);

            //assert
            Assert.IsTrue(SQLWorker.CheckExistance(grade));
        }

        [TestMethod()]
        public void UpdateAndDeleteTest()
        {
            //arrange
            Subject subject = new Subject("Test Subject", 0, 0);
            Session session = new Session("Test Session", DateTime.MinValue, DateTime.MaxValue);
            Speciality speciality = new Speciality("TS", "Test Speciality");
            Group group = new Group(1, 1, speciality);
            Student student = new Student("Test Student", DateTime.Now, group, Gender.Male);

            StudentsGrade studentsGrade = new StudentsGrade(9, student, subject, session);
            bool result;

            //act
            repositoryForSubject.Create(subject);
            repositoryForSession.Create(session);
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repositoryForStudent.Create(student);

            repository.Create(studentsGrade);

            result = SQLWorker.CheckExistance(studentsGrade);

            studentsGrade.Id = SQLWorker.GetID(studentsGrade);

            studentsGrade.Grade = 10;

            repository.Update(studentsGrade);

            result = result && SQLWorker.CheckExistance(studentsGrade);

            repository.Delete(studentsGrade.Id);

            repositoryForStudent.Delete(SQLWorker.GetID(student));
            repositoryForGroup.Delete(SQLWorker.GetID(group));
            repositoryForSubject.Delete(SQLWorker.GetID(subject));
            repositoryForSpeciality.Delete(SQLWorker.GetID(speciality));
            repositoryForSession.Delete(SQLWorker.GetID(session));



            //assert
            Assert.IsTrue(result);
        }


    }
}