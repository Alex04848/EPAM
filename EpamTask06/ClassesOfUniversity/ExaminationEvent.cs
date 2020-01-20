using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    public class ExaminationEvent
    {
        public int Id { get; set; }


        public Subject Subject
        {
            get => subject;

            set => subject = value ?? throw new ExaminationEventException("Incorrect subject's value!!!");
        }

        public Group Group
        {
            get => group;

            set => group = value ?? throw new ExaminationEventException("Incorrect group!!!");
        }

        public DateTime Date { get; set; }

        public Session Session
        {
            get => session;

            set => session = value ?? throw new ExaminationEventException("Incorrect value for session!!!");
        }

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


        Subject subject;

        Group group;

        ExaminationEventType eventType;

        Session session;


        public ExaminationEvent() : this((new Subject()),(new Group()),DateTime.Now,ExaminationEventType.Exam, (new Session()))
        {
        }

        public ExaminationEvent(Subject subject,Group group,DateTime date,ExaminationEventType eventType,Session session)
        {
            this.Subject = subject;
            this.Group = group;
            this.EventType = eventType;
            this.Session = session;
        }



        public override int GetHashCode()
                => (subject.GetHashCode() + group.GetHashCode() + Date.GetHashCode() + eventType.GetHashCode());

        public override bool Equals(object obj)
                => (obj is ExaminationEvent examEvent && examEvent.GetHashCode() == this.GetHashCode());

        public override string ToString()
                => ($"{Subject.NameOfSubject};{Group};{Date.ToString("dd/MM/yyyy")};{eventType.ToString()}");

    }
}
