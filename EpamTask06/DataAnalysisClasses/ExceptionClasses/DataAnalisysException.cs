using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EpamTask06.ClassesOfUniversity;
using System.Threading.Tasks;

namespace EpamTask06.DataAnalysisClasses.ExceptionClasses
{
    public class DataAnalysisException : Exception
    {
        public DataAnalysisException() : base()
        {
        }

        public DataAnalysisException(string message) : base(message)
        {
        }

        public static void CheckGroup(Group group)
        {       
             if (group == null)
                throw new DataAnalysisException("Incorrect value of group!!!");
        }

        public static void CheckSession(Session session)
        {
            if (session == null)
                throw new DataAnalysisException("Incorrect value of session!!!");
        }


    }
}
