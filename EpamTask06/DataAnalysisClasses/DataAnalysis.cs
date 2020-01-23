using EpamTask06.ClassesOfUniversity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask06.DataAnalysisClasses.ExceptionClasses;

namespace EpamTask06.DataAnalysisClasses
{
    public class DataAnalysis
    {
        public IEnumerable<Subject> Subjects { get; }
        public IEnumerable<Session> Sessions { get; }
        public IEnumerable<Speciality> Specialities { get; }
        public IEnumerable<Group> Groups { get; }
        public IEnumerable<Student> Students { get; }
        public IEnumerable<ExaminationEvent> ExaminationEvents { get; }
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



        public IEnumerable<SessionResults> GetResultsOfSession(Session session,Group group)
        {
            IEnumerable<SessionResults> gradesOfSessionForAllStudents = null;

            DataAnalysisException.CheckGroup(group);
            DataAnalysisException.CheckSession(session);


             gradesOfSessionForAllStudents = StudentsGrades
                .Where(grades => grades.Session.Equals(session)) // Get Current Session
                .Where(grade => grade.Student.StudentGroup.Equals(group)) // Get Current Group
                .GroupBy(grades => grades.Student) // Group by students
                .Select(grades => new SessionResults(grades.Key,session,grades.Average(grade => grade.Grade)));


            return gradesOfSessionForAllStudents;
        }


        IEnumerable<StudentsGrade> GetGrades(Session session, Group group)
        {
            DataAnalysisException.CheckGroup(group);
            DataAnalysisException.CheckSession(session);

            return StudentsGrades
                        .Where(grades => grades.Session.Equals(session))
                        .Where(grades => grades.Student.StudentGroup.Equals(group));
        }


        public double GetMinimalGrade(Session session, Group group)
                => GetGrades(session, group).Min(grade => grade.Grade);
                
        public double GetMaxGrade(Session session, Group group)
                => GetGrades(session, group).Max(grade => grade.Grade);

        public double GetAverageGrade(Session session, Group group)
                => GetGrades(session, group).Average(grade => grade.Grade);


        public IEnumerable<SessionResults> GetStudentsForExpelling(Session session,Group group,double minimalAverageGrade = 5.5)
            => GetResultsOfSession(session, group)
                        .Where(result => result.AverageGrade < minimalAverageGrade);




        public IEnumerable<SessionResults> GetResultsOfSessionOrderByStudentsName(Session session, Group group)
            => GetResultsOfSession(session, group).OrderByDescending(res => res.Student.FullName);

        public IEnumerable<SessionResults> GetResultsOfSessionOrderByGrades(Session session, Group group)
           => GetResultsOfSession(session, group).OrderByDescending(res => res.AverageGrade);



        public IEnumerable<SessionResults> GetStudentsForExpellingOrderedByStudentsName(Session session, Group group, double minimalAverageGrade = 5.5)
            => GetStudentsForExpelling(session, group, minimalAverageGrade).OrderByDescending(res => res.Student.FullName);

        public IEnumerable<SessionResults> GetStudentsForExpellingOrderedByGrades(Session session, Group group, double minimalAverageGrade = 5.5)
                => GetStudentsForExpelling(session, group, minimalAverageGrade).OrderByDescending(res => res.AverageGrade);

    }
}
