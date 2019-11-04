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
    ///  как он не представляет какую-то конкретную сущность, а просто собирает
    ///  в себе алгоритмы поиска НОД 
    /// </summary>
    public static class GCFFinders
    {
        /// <summary>
        /// В данном списке объектов хранятся делегаты которые представляют методы реализующие алгоритмы для поиска НОД
        /// данный список понадобится для метода подготовки данных для гистограммы
        /// </summary>
        static List<Func<int, int, int>> algorithms = new List<Func<int, int, int>>()
        {
            BinaryEvklidAlgorithm,
            EvklidAlgorithm
        };

        /// <summary>
        /// Данный метод представляет стандартную реализацию алгоритма Евклида
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int EvklidAlgorithm(int a,int b)
        {
            if (a != 0 && b != 0)
                return EvklidAlgorithm(Math.Min(a, b), Math.Max(a, b) % Math.Min(a, b));
            else
                return (a == 0 ? b : a);
        }

        /// <summary>
        /// Данный перегруженный метод представляет возможность найти НОД для более чем двух элементов.
        /// Это метод работает благодаря механизму Ad-Hoc полиморфизма и модификатору params. 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int EvklidAlgorithm(params int[] values)
        {
            int result = 0;
            values.ToList().ForEach(arrayValue => result = EvklidAlgorithm(result, arrayValue));

            return result;
        }

        /// <summary>
        /// Данный метод представляет реализацию бинарного алгоритма Евклида
        /// Алгоритм:
        /// 1.НОД(0, n) = n; НОД(m, 0) = m; НОД(m, m) = m;
        /// 2.НОД(1, n) = 1; НОД(m, 1) = 1;
        /// 3.Если m, n чётные, то НОД(m, n) = 2*НОД(m/2, n/2);
        /// 4.Если m чётное, n нечётное, то НОД(m, n) = НОД(m/2, n);
        /// 5.Если n чётное, m нечётное, то НОД(m, n) = НОД(m, n/2);
        /// 6.Если m, n нечётные и n > m, то НОД(m, n) = НОД((n-m)/2, m);
        /// 7.Если m, n нечётные и n<m, то НОД(m, n) = НОД((m-n)/2, n);
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int BinaryEvklidAlgorithm(int a,int b)
        {

            if (a == b || a == 0 || b == 0 || a == 1 || b == 1)
                return ((a == Math.Min(a, b) && a != 0) ? a : b);
            else if (a % 2 == 0 && b % 2 == 0)
                return (2*BinaryEvklidAlgorithm(a / 2, b / 2));
            else if (a % 2 == 0 || b % 2 == 0)
                return BinaryEvklidAlgorithm((a % 2 == 0 ? a / 2 : b / 2), (b % 2 != 0 ? b : a));
            else
                return BinaryEvklidAlgorithm(((Math.Max(a,b) - Math.Min(a,b))/2),Math.Min(a, b));
        }
        /// <summary>
        /// Данный метод принимает делегат указывающий на метод и данные для метода,
        /// а так же имеет выходной параметр для вычисления времени.
        /// Сам метод и предназначен для вычисления результата с возращением времени
        /// </summary>
        /// <param name="algorithmFunction"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int AlgorithmWithTheTime(Func<int,int,int> algorithmFunction,int a,int b,out DateTime time)
        {
            DateTime timeStart = DateTime.Now;
            int result = algorithmFunction(a, b);
            DateTime timeEnd = DateTime.Now;
            var difference = (timeEnd - timeStart);
            time = new DateTime() + difference;

            return result;
        }
       
        /// <summary>
        /// Данный методы предоставляет данные для построения гистограммы 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static List<BarGraphData> DataForBarGraph(int a,int b)
        {
            List<BarGraphData> dataForResult = new List<BarGraphData>();
            DateTime resultTime;

            algorithms.ForEach(algorithm =>
            {
                AlgorithmWithTheTime(algorithm, a, b, out resultTime);
                dataForResult.Add(new BarGraphData(algorithm.Method.Name, resultTime));
            });
            


            return dataForResult;
        }

    }
}
