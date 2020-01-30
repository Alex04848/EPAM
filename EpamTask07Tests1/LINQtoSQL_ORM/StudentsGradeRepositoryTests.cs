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
    public class StudentsGradeRepositoryTests
    {
        IRepository<StudentsGrade> repository = StudentsGradeRepository.GetRepository;


        IRepository<Subject> repositoryForSubject = SubjectRepository.GetRepository;

        IRepository<Session> repositoryForSession = SessionRepository.GetRepository;

        IRepository<Speciality> repositoryForSpeciality = SpecialityRepository.GetRepository;

        IRepository<Group> repositoryForGroup = GroupRepository.GetRepository;

        IRepository<Student> repositoryForStudent = StudentRepository.GetRepository;

        IRepository<Teacher> repositoryForTeacher = TeacherRepository.GetRepository;


        [TestMethod()]
        public void CreateAndDeleteTest()
        {
            //arrange
            Subject subject = new Subject("Test Subject`1", 0, 0);
            Session session = new Session("Test Session20", DateTime.Now, DateTime.Now.AddDays(5));
            Speciality speciality = new Speciality("TS`5", "Test Speciality`1");
            Group group = new Group(1, 1, speciality);
            Student student = new Student("Test Student`3", DateTime.Now, group, Gender.Male);
            Teacher teacher = new Teacher("Test Teacher`3", DateTime.Now, Gender.Male);

            StudentsGrade studentsGrade = new StudentsGrade(9, student, subject, session, teacher);
            bool result;

            //act
            repositoryForSubject.Create(subject);
            repositoryForSession.Create(session);
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repositoryForStudent.Create(student);
            repositoryForTeacher.Create(teacher);

            repository.Create(studentsGrade);

            result = CheckExistance(studentsGrade);

            repository.Delete(GetID(studentsGrade));

            result = result && !CheckExistance(studentsGrade);

            repositoryForStudent.Delete(GetID(student));
            repositoryForGroup.Delete(GetID(group));
            repositoryForSubject.Delete(GetID(subject));
            repositoryForSpeciality.Delete(GetID(speciality));
            repositoryForSession.Delete(GetID(session));
            repositoryForTeacher.Delete(GetID(teacher));


            //assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetCollectionTest()
        {
            //arrange
            var grades = repository.GetCollection();

            //assert
            Assert.IsTrue(grades.All(grade => CheckExistance(grade)));
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
            Assert.IsTrue(CheckExistance(grade));
        }

        [TestMethod()]
        public void UpdateAndDeleteTest()
        {
            //arrange
            Subject subject = new Subject("Test Subject`55", 0, 0);
            Session session = new Session("Test Session`133", DateTime.Now, DateTime.Now.AddDays(5));
            Speciality speciality = new Speciality("TS``1", "Test Speciality");
            Group group = new Group(1, 1, speciality);
            Student student = new Student("Test Student``1", DateTime.Now, group, Gender.Male);
            Teacher teacher = new Teacher("Test Teacher``1", DateTime.Now, Gender.Male);

            StudentsGrade studentsGrade = new StudentsGrade(9, student, subject, session, teacher);
            bool result;

            //act
            repositoryForSubject.Create(subject);
            repositoryForSession.Create(session);
            repositoryForSpeciality.Create(speciality);
            repositoryForGroup.Create(group);
            repositoryForStudent.Create(student);
            repositoryForTeacher.Create(teacher);

            repository.Create(studentsGrade);

            result = CheckExistance(studentsGrade);

            studentsGrade.Id = GetID(studentsGrade);

            studentsGrade.Grade = 10;

            repository.Update(studentsGrade);

            result = result && CheckExistance(studentsGrade);

            repository.Delete(studentsGrade.Id);

            repositoryForStudent.Delete(GetID(student));
            repositoryForGroup.Delete(GetID(group));
            repositoryForSubject.Delete(GetID(subject));
            repositoryForSpeciality.Delete(GetID(speciality));
            repositoryForSession.Delete(GetID(session));
            repositoryForTeacher.Delete(GetID(teacher));



            //assert
            Assert.IsTrue(result);
        }
    }
}