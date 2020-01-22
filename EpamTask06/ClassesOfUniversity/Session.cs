using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    public class Session
    {
        public int Id { get; set; }


        public string NameOfSession { get; set; }

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



        public override int GetHashCode()
                => (NameOfSession.GetHashCode() + StartDate.GetHashCode() + EndDate.GetHashCode());

        public override bool Equals(object obj)
                => (obj is Session session && session.GetHashCode() == this.GetHashCode());

        public override string ToString()
                => ($"{NameOfSession};{startDate.ToString("dd/MM/yyyy")};{endDate.ToString("dd/MM/yyyy")}");

    }
}
