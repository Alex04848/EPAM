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
    public partial class DataAnalysis : AbstractDataSaver
    {
        public DataAnalysis(IEnumerable<Subject> subjects,
                              IEnumerable<Session> sessions,
                              IEnumerable<Speciality> specialities,
                              IEnumerable<Group> groups,
                              IEnumerable<Student> students,
                              IEnumerable<ExaminationEvent> examinationEvents,
                              IEnumerable<StudentsGrade> studentsGrades,
                              IEnumerable<Teacher> teachers) : base(subjects,
                                                                    sessions,
                                                                    specialities,
                                                                    groups,
                                                                    students,
                                                                    examinationEvents,
                                                                    studentsGrades,
                                                                    teachers)
        {

        }

        public double GetAverageGrade(Session session, Student student)
            => GetValueAndCheckEmpty(StudentsGrades.Where(grade => grade.Session.Equals(session))
                             .Where(grade => grade.Student.Equals(student)));

        public double GetResultsForSpeciality(Session session, Speciality speciality)
           => GetValueAndCheckEmpty(StudentsGrades
                .Where(grade => grade.Session.Equals(session))
                .Where(grade => grade.Student.StudentGroup.SpecialityOfGroup.Equals(speciality)));

        public double GetResultsForTeacher(Session session, Teacher teacher)
            => GetValueAndCheckEmpty(StudentsGrades
                    .Where(grade => grade.Session.Equals(session))
                    .Where(grade => grade.Teacher.Equals(teacher)));

        public double GetYearResultForSubject(Subject subject, int year)
            => GetValueAndCheckEmpty(StudentsGrades
                            .Where(grade => grade.Subject.Equals(subject))
                            .Where(grade => grade.Session.EndDate.Year == year));

        public IEnumerable<int> GetAllYears()
            => Sessions
                        .Select(session => session.EndDate.Year)
                        .Distinct();

        double GetValueAndCheckEmpty(IEnumerable<StudentsGrade> studentsGrades)
            => (studentsGrades.Count() > 0 ? studentsGrades.Average(grade => grade.Grade) : default);

    }
}
