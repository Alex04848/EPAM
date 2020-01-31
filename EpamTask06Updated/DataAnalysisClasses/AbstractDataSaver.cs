using EpamTask06.ClassesOfUniversity;
using EpamTask06.DataAnalysisClasses.ExceptionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.DataAnalysisClasses
{
    /// <summary>
    /// Common class for DataAnalysis Classes
    /// </summary>
    public abstract class AbstractDataSaver
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

        /// <summary>
        /// Teachers
        /// </summary>
        public IEnumerable<Teacher> Teachers { get; }


        public AbstractDataSaver(IEnumerable<Subject> subjects,
                            IEnumerable<Session> sessions,
                            IEnumerable<Speciality> specialities,
                            IEnumerable<Group> groups,
                            IEnumerable<Student> students,
                            IEnumerable<ExaminationEvent> examinationEvents,
                            IEnumerable<StudentsGrade> studentsGrades,
                            IEnumerable<Teacher> teachers)
        {
            this.Subjects = subjects ?? throw new DataAnalysisException("Incorrect collection of subjects");
            this.Sessions = sessions ?? throw new DataAnalysisException("Incorrect collection of sessions"); ;
            this.Specialities = specialities ?? throw new DataAnalysisException("Incorrect collection of specialities");
            this.Groups = groups ?? throw new DataAnalysisException("Incorrect collection of groups");
            this.Students = students ?? throw new DataAnalysisException("Incorrect collection of students");
            this.ExaminationEvents = examinationEvents ?? throw new DataAnalysisException("Incorrect collection of examination events");
            this.StudentsGrades = studentsGrades ?? throw new DataAnalysisException("Incorrect collection of students grades");
            this.Teachers = teachers ?? throw new DataAnalysisException("Incorrect collection of teachers");
        }

    }
}
