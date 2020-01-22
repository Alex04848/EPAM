﻿using EpamTask06.ClassesOfUniversity;
using EpamTask06.ORMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.DBAccess
{
    public static class DBAccessObject
    {
        public static IRepository<Student> Students { get; private set; } = SQLRepositoryForStudent.Repository;

        public static IRepository<Group> Groups { get; private set; } = SQLRepositoryForGroup.Repository;

        public static IRepository<Subject> Subjects { get; private set; } = SQLRepositoryForSubject.Repository;

        public static IRepository<Session> Sessions { get; private set; } = SQLRepositoryForSession.Repository;

        public static IRepository<Speciality> Specialities { get; private set; } = SQLRepositoryForSpeciality.Repository;

        public static IRepository<StudentsGrade> StudentsGrades { get; private set; } = SQLRepositoryForStudentsGrade.Repository;

        public static IRepository<ExaminationEvent> ExaminationEvents { get; private set; } = SQLRepositoryForExaminationEvent.Repository;


    }
}
