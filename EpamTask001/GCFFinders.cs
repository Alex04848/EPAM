using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask001
{

    /// <summary>
    ///  Тип Greatest Common Factor Finders (GCFFinder) - Предназначен для 
    ///  хранения методов которые описывают алгоритм нахождения НОД
    ///  данный тип содержит в себе алгоритм евклида и бинарный алгоритм евклида.
    ///  Сам класс является статическим, не вижу смысла делать его нестатическим так 
    ///  он является всего лишь 
    /// </summary>
    public static class GCFFinders
    {

        static List<Func<int, int, int>> algorithms = new List<Func<int, int, int>>()
        {
            BinaryEvklidAlgorithm,
            EvklidAlgorithm
        };

        public static int EvklidAlgorithm(int a,int b)
        {
            if (a != 0 && b != 0)
                return EvklidAlgorithm(Math.Min(a, b), Math.Max(a, b) % Math.Min(a, b));
            else
                return (a == 0 ? b : a);
        }

        public static int EvklidAlgorithm(params int[] values)
        {
            int result = 0;
            values.ToList().ForEach(arrayValue => result = EvklidAlgorithm(result, arrayValue));

            return result;
        }


        public static int BinaryEvklidAlgorithm(int a,int b)
        {

            if (a == b || a == 0 || b == 0 || a == 1 || b == 1)
                return ((a == Math.Min(a, b) && a != 0) ? a : b);
            else if (a % 2 == 0 && b % 2 == 0)
                return BinaryEvklidAlgorithm(a / 2, b / 2);
            else if (a % 2 == 0 || b % 2 == 0)
                return BinaryEvklidAlgorithm((a % 2 == 0 ? a / 2 : b / 2), (b % 2 != 0 ? b : a));
            else
                return BinaryEvklidAlgorithm(Math.Min(a,b),(Math.Max(a,b) - Math.Min(a,b))/2);
        }

        public static int AlgoritmWithTheTime(Func<int,int,int> algorithmFunction,int a,int b,out DateTime time)
        {
            DateTime timeStart = DateTime.Now;
            int result = algorithmFunction(a, b);
            DateTime timeEnd = DateTime.Now;
            time = new DateTime((timeEnd - timeStart).Ticks);

            return result;
        }
       
        public static List<BarGraphData> DataForBarGraph(int a,int b)
        {
            List<BarGraphData> dataForResult = new List<BarGraphData>();
            DateTime resultTime;

            algorithms.ForEach(algorithm =>
            {
                AlgoritmWithTheTime(algorithm, a, b, out resultTime);
                dataForResult.Add(new BarGraphData(algorithm.ToString(), resultTime));
            });
            


            return dataForResult;
        }


    }
}
