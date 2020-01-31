using EpamTask06.ClassesOfUniversity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ORMClasses
{
    /// <summary>
    /// Db Exception for ORM Classes
    /// </summary>
    public class DBException : Exception
    {
        public DBException() : base()
        {
        }

        public DBException(string message) : base(message)
        {
        }

        public static void CatchException(StudentsGrade grade)
        {
            if (!SQLWorker.CheckExistance(grade.Student))
                throw new DBException("Incorrect student!!!");
            else if (!SQLWorker.CheckExistance(grade.Subject))
                throw new DBException("Incorrect subject!!!");
            else if (!SQLWorker.CheckExistance(grade.Session))
                throw new DBException("Incorrect session!!!");
        }

        public static void CatchException(ExaminationEvent examOrCredit)
        {
            if (!SQLWorker.CheckExistance(examOrCredit.Group))
                throw new DBException("Incorrect group!!!");
            else if (!SQLWorker.CheckExistance(examOrCredit.Subject))
                throw new DBException("Incorrect subject!!!");
            else if (!SQLWorker.CheckExistance(examOrCredit.Session))
                throw new DBException("Incorrect session!!!");
        }

    }
}
