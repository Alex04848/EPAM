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
    public class DBHelperTests
    {
        IRepository<ExaminationEvent> repositoryForExaminationEvent = ExaminationEventRepository.GetRepository;


        IRepository<Subject> repositoryForSubject = SubjectRepository.GetRepository;

        IRepository<Speciality> repositoryForSpeciality = SpecialityRepository.GetRepository;

        IRepository<Group> repositoryForGroup = GroupRepository.GetRepository;

        IRepository<Session> repositoryForSession = SessionRepository.GetRepository;

        IRepository<Teacher> repositoryForTeacher = TeacherRepository.GetRepository;

        IRepository<Student> repositoryForStudent = StudentRepository.GetRepository;


        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void GetIDForSubject(int idValue)
        {
            //arrange
            Subject subj = repositoryForSubject.Read(idValue);

            //assert
            Assert.IsTrue(subj.Id == GetID(subj));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public void GetIDForSession(int idValue)
        {
            //arrange
            Session session = repositoryForSession.Read(idValue);

            //assert
            Assert.IsTrue(session.Id == GetID(session));
        }


        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public void GetIDForSpeciality(int idValue)
        {
            //arrange
            Speciality speciality = repositoryForSpeciality.Read(idValue);

            //assert
            Assert.IsTrue(speciality.Id == GetID(speciality));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void GetIDForTeacher(int idValue)
        {
            //arrange
            Teacher teacher = repositoryForTeacher.Read(idValue);

            //assert
            Assert.IsTrue(teacher.Id == GetID(teacher));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public void GetIDForGroup(int idValue)
        {
            //arrange
            Group group = repositoryForGroup.Read(idValue);

            //assert
            Assert.IsTrue(group.Id == GetID(group));
        }

        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void GetIDForExaminationEvent(int idValue)
        {
            //arrange
            ExaminationEvent examEvent = repositoryForExaminationEvent.Read(idValue);

            //assert
            Assert.IsTrue(examEvent.Id == GetID(examEvent));
        }


        [DataTestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void GetIDForStudent(int idValue)
        {
            //arrange
            Student student = repositoryForStudent.Read(idValue);

            //assert
            Assert.IsTrue(student.Id == GetID(student));
        }

    }
}