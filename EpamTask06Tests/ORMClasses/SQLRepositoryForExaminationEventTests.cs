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
    /// The Class which test CRUD of ORM class for Examination Events
    /// </summary>
    [TestClass()]
    public class SQLRepositoryForExaminationEventTests
    {
        IRepository<ExaminationEvent> repository = SQLRepositoryForExaminationEvent.Repository;


        IRepository<Subject> repositoryForSubject = SQLRepositoryForSubject.Repository;

        IRepository<Speciality> repositoryForSpeciality = SQLRepositoryForSpeciality.Repository;

        IRepository<Group> repositoryForGroup = SQLRepositoryForGroup.Repository;

        IRepository<Session> repositoryForSession = SQLRepositoryForSession.Repository;



        [TestMethod()]
        public void CreateAndDeleteTest()
        {
            //arrange
            Subject subject = new Subject("Test Subject",0,0);
            Speciality speciality = new Speciality("TS","Test Speciality");
            Group group = new Group(1, 1,speciality);
            Session session = new Session("TestSession", DateTime.MinValue, DateTime.MaxValue);

            ExaminationEvent examinationEvent = new ExaminationEvent(subject,group,DateTime.Now,ExaminationEventType.Exam, session);
            bool result;

            //act
            repositoryForSubject.Create(subject);
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repositoryForSession.Create(session);


            repository.Create(examinationEvent);

            result = SQLWorker.CheckExistance(examinationEvent);
            repository.Delete(SQLWorker.GetID(examinationEvent));
            result = result && !SQLWorker.CheckExistance(examinationEvent);

            repositoryForGroup.Delete(SQLWorker.GetID(group));            
            repositoryForSpeciality.Delete(SQLWorker.GetID(speciality));
            repositoryForSubject.Delete(SQLWorker.GetID(subject));
            repositoryForSession.Delete(SQLWorker.GetID(session));



            //assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetCollectionTest()
        {
            //assert
            var examinationEvents = repository.GetCollection();

            //assert
            Assert.IsTrue(examinationEvents.All(examEvent => SQLWorker.CheckExistance(examEvent)));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void ReadTest(int idValue)
        {
            //arrange
            ExaminationEvent examinationEvent = repository.Read(idValue);

            //assert
            Assert.IsTrue(SQLWorker.CheckExistance(examinationEvent));
        }

        [TestMethod()]
        public void UpdateAndDeleteTest()
        {
            //arrange
            Subject subject = new Subject("Test Subject", 0, 0);
            Speciality speciality = new Speciality("TS", "Test Speciality");
            Group group = new Group(1, 1, speciality);
            Session session = new Session("TestSession", DateTime.MinValue, DateTime.MaxValue);

            ExaminationEvent examinationEvent = new ExaminationEvent(subject, group, DateTime.Now, ExaminationEventType.Exam, session);
            bool result;

            //act
            repositoryForSubject.Create(subject);
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repositoryForSession.Create(session);


            repository.Create(examinationEvent);

            result = SQLWorker.CheckExistance(examinationEvent);
            examinationEvent.Id = SQLWorker.GetID(examinationEvent);

            examinationEvent.Date = DateTime.MaxValue;

            repository.Update(examinationEvent);
            
            result = result && SQLWorker.CheckExistance(examinationEvent);

            repository.Delete(SQLWorker.GetID(examinationEvent));

            repositoryForGroup.Delete(SQLWorker.GetID(group));
            repositoryForSpeciality.Delete(SQLWorker.GetID(speciality));
            repositoryForSubject.Delete(SQLWorker.GetID(subject));
            repositoryForSession.Delete(SQLWorker.GetID(session));



            //assert
            Assert.IsTrue(result);
        }
    }
}