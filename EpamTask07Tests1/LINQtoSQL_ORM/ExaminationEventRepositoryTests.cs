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
    [TestClass()]
    public class ExaminationEventRepositoryTests
    {
        IRepository<ExaminationEvent> repository = ExaminationEventRepository.GetRepository;


        IRepository<Subject> repositoryForSubject = SubjectRepository.GetRepository;

        IRepository<Speciality> repositoryForSpeciality = SpecialityRepository.GetRepository;

        IRepository<Group> repositoryForGroup = GroupRepository.GetRepository;

        IRepository<Session> repositoryForSession = SessionRepository.GetRepository;

        IRepository<Teacher> repositoryForTeacher = TeacherRepository.GetRepository;


        [TestMethod()]
        public void CreateAndDeleteTest()
        {
            //arrange
            Subject subject = new Subject("Test Subject", 0, 0);
            Speciality speciality = new Speciality("TS", "Test Speciality");
            Group group = new Group(1, 1, speciality);
            Session session = new Session("TestSession", DateTime.Now, DateTime.Now.AddDays(5));
            Teacher teacher = new Teacher("TestTeacher", DateTime.Now, Gender.Male);

            ExaminationEvent examinationEvent = new ExaminationEvent(subject, group, DateTime.Now, ExaminationEventType.Exam, session, teacher);
            bool result;

            //act
            repositoryForSubject.Create(subject);
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repositoryForSession.Create(session);
            repositoryForTeacher.Create(teacher);


            repository.Create(examinationEvent);

            result = CheckExistance(examinationEvent);
            repository.Delete(GetID(examinationEvent));
            result = result && !CheckExistance(examinationEvent);

            repositoryForGroup.Delete(GetID(group));

            repositoryForSubject.Delete(GetID(subject));
            repositoryForSession.Delete(GetID(session));
            repositoryForTeacher.Delete(GetID(teacher));

            repositoryForSpeciality.Delete(GetID(speciality));
           


            //assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetCollectionTest()
        {
            //assert
            var examinationEvents = repository.GetCollection();

            //assert
            Assert.IsTrue(examinationEvents.All(examEvent => CheckExistance(examEvent)));
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
            Assert.IsTrue(CheckExistance(examinationEvent));
        }

        [TestMethod()]
        public void UpdateAndDeleteTest()
        {
            //arrange
            Subject subject = new Subject("TestSubj", 0, 0);
            Speciality speciality = new Speciality("TS`5", "Test Speeciality");
            Group group = new Group(1, 1, speciality);
            Session session = new Session("TestSession`1", DateTime.Now, DateTime.Now.AddDays(5));
            Teacher teacher = new Teacher("TestTeacher`1", DateTime.Now, Gender.Male);

            ExaminationEvent examinationEvent = new ExaminationEvent(subject, group, DateTime.Now, ExaminationEventType.Exam, session, teacher);
            bool result;

            //act
            repositoryForSubject.Create(subject);
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repositoryForSession.Create(session);
            repositoryForTeacher.Create(teacher);


            repository.Create(examinationEvent);

            result = CheckExistance(examinationEvent);
            examinationEvent.Id = GetID(examinationEvent);

            examinationEvent.Date = DateTime.MaxValue;

            repository.Update(examinationEvent);

            result = result && CheckExistance(examinationEvent);

            repository.Delete(GetID(examinationEvent));

            repositoryForGroup.Delete(GetID(group));
            repositoryForSpeciality.Delete(GetID(speciality));
            repositoryForSubject.Delete(GetID(subject));
            repositoryForSession.Delete(GetID(session));
            repositoryForTeacher.Delete(GetID(teacher));


            //assert
            Assert.IsTrue(result);
        }
    }
}