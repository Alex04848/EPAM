using EpamTask06.ClassesOfUniversity.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity
{
    /// <summary>
    /// Type of Examination event, it can be:
    /// 1) Exam (экзамен)
    /// 2) Credit (зачёт)
    /// </summary>
    public enum ExaminationEventType : Int32
    {
        Exam,
        Credit
    }

}