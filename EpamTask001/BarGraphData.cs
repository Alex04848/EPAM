using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask001
{
    /// <summary>
    /// Тип который описывает данные для построения гистрограммы,
    /// посколько данные неизменны
    /// для реализации типа была использована структура(значимый тип)
    /// </summary>
    public struct BarGraphData
    {
        public DateTime GetTime => allTime;

        DateTime allTime;

        public string GetMethodName => nameOfMethod;

        string nameOfMethod;

        public BarGraphData(string methodName,DateTime time)
        {
            nameOfMethod = methodName; 
            allTime = time;
        }

        public override string ToString() => ($"{nameOfMethod};{allTime.Ticks}");
    }

}
