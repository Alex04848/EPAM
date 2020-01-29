using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    /// <summary>
    /// Class That describes Session table in database
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Int property for Id from DB
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name Of Session
        /// </summary>
        public string NameOfSession {

            get => nameOfSession;

            set => nameOfSession = value ?? throw new SessionException("Incorrect name of session");

        }

        /// <summary>
        /// Session's start date
        /// </summary>
        public DateTime StartDate
        {
            get => startDate;

            set
            {
                if (value >= endDate)
                    throw new SessionException("Incorrect start date!!!");

                startDate = value;
            }
        }

        /// <summary>
        /// Session's end date
        /// </summary>
        public DateTime EndDate
        {
            get => endDate;

            set
            {
                if (value <= startDate)
                    throw new SessionException("Incorrect end date!!!");

                endDate = value;
            }
        }


        DateTime startDate = DateTime.MinValue;

        DateTime endDate = DateTime.MaxValue;

        string nameOfSession;


        /// <summary>
        /// All Time of Session
        /// </summary>
        public TimeSpan GetTimeOfSession => (EndDate - StartDate);



        public Session() : this(string.Empty,DateTime.MinValue,DateTime.MaxValue)
        {
        }


        public Session(string nameOfSession,DateTime startDate,DateTime endDate)
        {
            this.NameOfSession = nameOfSession;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }


        /// <summary>
        /// Overrided method GetHashCode which gets hash codes from all fields
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
                => (NameOfSession.GetHashCode() + StartDate.GetHashCode() + EndDate.GetHashCode());

        /// <summary>
        /// Overrided method Equals which checks Equality of object obj and current object 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
                => (obj is Session session && session.GetHashCode() == this.GetHashCode());

        /// <summary>
        /// Overrided ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
                => ($"{NameOfSession};{startDate.ToString("dd/MM/yyyy")};{endDate.ToString("dd/MM/yyyy")}");

    }
}
