using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    [Table]
    /// <summary>
    /// Class That describes ExaminationEvent table in database
    /// </summary>
    public class ExaminationEvent
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        /// <summary>
        /// Int property for Id from DB
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Subject of ExaminationEvent
        /// </summary>
        public Subject Subject
        {
            get => subject;

            set => subject = value ?? throw new ExaminationEventException("Incorrect subject's value!!!");
        }

        /// <summary>
        /// Group for Event
        /// </summary>
        public Group Group
        {
            get => group;

            set => group = value ?? throw new ExaminationEventException("Incorrect group!!!");
        }

        [Column(Name = "DateOfExam")]
        /// <summary>
        /// Date of action
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Session of Event
        /// </summary>
        public Session Session
        {
            get => session;

            set => session = value ?? throw new ExaminationEventException("Incorrect value for session!!!");
        }

        [Column(Name = "TypeOfEvent")]
        /// <summary>
        /// Type Of Event
        /// </summary>
        public ExaminationEventType EventType
        {
            get => eventType;

            set
            {
                if (value < ExaminationEventType.Exam || value > ExaminationEventType.Credit)
                    throw new ExaminationEventException("Examination Event can be only exam or credit!!!");

                eventType = value;
            }
        }

        public Teacher Teacher {

            get => teacher;

            set => teacher = value ?? throw new ExaminationEventException("Incorrect teacher for examination Event!!!");

        }
        

        Subject subject;

        Group group;

        ExaminationEventType eventType;

        Session session;

        Teacher teacher;


        public ExaminationEvent() : this((new Subject()),(new Group()),DateTime.Now,ExaminationEventType.Exam, (new Session()),(new Teacher()))
        {
        }

        public ExaminationEvent(Subject subject,Group group,DateTime date,ExaminationEventType eventType,Session session,Teacher teacher)
        {
            this.Subject = subject;
            this.Group = group;
            this.Session = session;
            this.Date = date;
            this.EventType = eventType;         
            this.Teacher = teacher;
        }


        /// <summary>
        /// Overrided method GetHashCode which gets hash codes from all fields
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
                => (subject.GetHashCode() + group.GetHashCode() + Date.GetHashCode() + eventType.GetHashCode() + session.GetHashCode() + teacher.GetHashCode());

        /// <summary>
        /// Overrided method Equals which checks Equality of object obj and current object 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
                => (obj is ExaminationEvent examEvent && examEvent.GetHashCode() == this.GetHashCode());

        /// <summary>
        /// Overrided ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
                => ($"{Subject.NameOfSubject};{Group};{Date.ToString("dd/MM/yyyy")};{eventType.ToString()}");

    }
}
