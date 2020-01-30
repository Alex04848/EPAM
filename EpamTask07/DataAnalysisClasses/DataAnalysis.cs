using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask06.DataAnalysisClasses;
using EpamTask06.ClassesOfUniversity;
using EpamTask06.DataAnalysisClasses.ExceptionClasses;

namespace EpamTask07.DataAnalysisClasses
{
    /// <summary>
    /// The Class which gets and analize data of University Classes
    /// </summary>
    public partial class DataAnalysis
    {
        /// <summary>
        /// Subjects
        /// </summary>
        public IEnumerable<Subject> Subjects { get; }

        /// <summary>
        /// Sessions
        /// </summary>
        public IEnumerable<Session> Sessions { get; }

        /// <summary>
        /// Specialities
        /// </summary>
        public IEnumerable<Speciality> Specialities { get; }

        /// <summary>
        /// Groups
        /// </summary>
        public IEnumerable<Group> Groups { get; }

        /// <summary>
        /// Students
        /// </summary>
        public IEnumerable<Student> Students { get; }

        /// <summary>
        /// ExaminationEvents
        /// </summary>
        public IEnumerable<ExaminationEvent> ExaminationEvents { get; }

        /// <summary>
        /// StudentsGrades
        /// </summary>
        public IEnumerable<StudentsGrade> StudentsGrades { get; }


        public DataAnalysis(IEnumerable<Subject> subjects,
                            IEnumerable<Session> sessions,
                            IEnumerable<Speciality> specialities,
                            IEnumerable<Group> groups,
                            IEnumerable<Student> students,
                            IEnumerable<ExaminationEvent> examinationEvents,
                            IEnumerable<StudentsGrade> studentsGrades)
        {
            this.Subjects = subjects ?? throw new DataAnalysisException($"Incorrect collection of subjects");
            this.Sessions = sessions ?? throw new DataAnalysisException($"Incorrect collection of sessions"); ;
            this.Specialities = specialities ?? throw new DataAnalysisException($"Incorrect collection of specialities");
            this.Groups = groups ?? throw new DataAnalysisException($"Incorrect collection of groups");
            this.Students = students ?? throw new DataAnalysisException($"Incorrect collection of students");
            this.ExaminationEvents = examinationEvents ?? throw new DataAnalysisException($"Incorrect collection of examination events");
            this.StudentsGrades = studentsGrades ?? throw new DataAnalysisException($"Incorrect collection of students grades");
        }

        public double GetAverageGrade(Session session, Student student)
            => StudentsGrades.Where(grade => grade.Session.Equals(session))
                             .Where(grade => grade.Student.Equals(student))
                             .Average(grade => grade.Grade);

        public IEnumerable<SessionResults> GetResultsForSpeciality(Session session,Speciality speciality)
           => StudentsGrades
                .Where(grade => grade.Session.Equals(session))
                .Where(grade => grade.Student.StudentGroup.SpecialityOfGroup.Equals(speciality))
                .Select(grade => new SessionResults(grade.Student, session, GetAverageGrade(session, grade.Student)));

        public IEnumerable<SessionResults> GetResultsForTeacher(Session session, Teacher teacher)
            => StudentsGrades
                    .Where(grade => grade.Session.Equals(session))
                    .Where(grade => grade.Teacher.Equals(teacher))
                    .Select(grade => new SessionResults(grade.Student, session, GetAverageGrade(session,grade.Student)));

        public IEnumerable<SessionResults> GetYearResultForSubject(Subject subject, int year)
            => StudentsGrades
                            .Where(grade => grade.Subject.Equals(subject))
                            .Where(grade => grade.Session.EndDate.Year == year)
                            .Select(grade => new SessionResults(grade.Student, grade.Session, GetAverageGrade(grade.Session, grade.Student)));


    }
}
