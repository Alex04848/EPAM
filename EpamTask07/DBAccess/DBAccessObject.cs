using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask06;
using EpamTask06.ClassesOfUniversity;
using EpamTask07.LINQtoSQL_ORM;

namespace EpamTask07.DBAccess
{
    /// <summary>
    /// Static Class for Access to DB
    /// </summary>
    public static class DBAccessObject
    {
        public static IRepository<Student> Students { get; private set; } = StudentRepository.GetRepository;

        public static IRepository<Group> Groups { get; private set; } = GroupRepository.GetRepository;

        public static IRepository<Subject> Subjects { get; private set; } = SubjectRepository.GetRepository;

        public static IRepository<Session> Sessions { get; private set; } = SessionRepository.GetRepository;

        public static IRepository<Speciality> Specialities { get; private set; } = SpecialityRepository.GetRepository;

        public static IRepository<StudentsGrade> StudentsGrades { get; private set; } = StudentsGradeRepository.GetRepository;

        public static IRepository<ExaminationEvent> ExaminationEvents { get; private set; } = ExaminationEventRepository.GetRepository;

        public static IRepository<Teacher> Teachers { get; set; } = TeacherRepository.GetRepository;

    }

}
