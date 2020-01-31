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

        /// <summary>
        /// Average grade for Student
        /// </summary>
        /// <param name="session"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public double GetAverageGrade(Session session, Student student)
            => GetValueAndCheckEmpty(StudentsGrades.Where(grade => grade.Session.Equals(session))
                             .Where(grade => grade.Student.Equals(student)));

        /// <summary>
        /// Result of session for Speciality
        /// </summary>
        /// <param name="session"></param>
        /// <param name="speciality"></param>
        /// <returns></returns>
        public double GetResultsForSpeciality(Session session, Speciality speciality)
           => GetValueAndCheckEmpty(StudentsGrades
                .Where(grade => grade.Session.Equals(session))
                .Where(grade => grade.Student.StudentGroup.SpecialityOfGroup.Equals(speciality)));

        /// <summary>
        /// Result of session for Teacher
        /// </summary>
        /// <param name="session"></param>
        /// <param name="speciality"></param>
        /// <returns></returns>
        public double GetResultsForTeacher(Session session, Teacher teacher)
            => GetValueAndCheckEmpty(StudentsGrades
                    .Where(grade => grade.Session.Equals(session))
                    .Where(grade => grade.Teacher.Equals(teacher)));

        /// <summary>
        /// Result of year for Subject
        /// </summary>
        /// <param name="session"></param>
        /// <param name="speciality"></param>
        /// <returns></returns>
        public double GetYearResultForSubject(Subject subject, int year)
            => GetValueAndCheckEmpty(StudentsGrades
                            .Where(grade => grade.Subject.Equals(subject))
                            .Where(grade => grade.Session.EndDate.Year == year));

        /// <summary> 
        /// Method which gets all years
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GetAllYears()
            => Sessions
                        .Select(session => session.EndDate.Year)
                        .Distinct();

        /// <summary>
        /// Method which performs checking of number of elemenets in collection if the number equals zero, than the method returns default value,
        /// else the method returns Avg of grades
        /// </summary>
        /// <param name="studentsGrades"></param>
        /// <returns></returns>
        double GetValueAndCheckEmpty(IEnumerable<StudentsGrade> studentsGrades)
            => (studentsGrades.Count() > 0 ? studentsGrades.Average(grade => grade.Grade) : default);

    }
}
