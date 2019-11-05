using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EpamTask001.GCFFinders;

namespace EpamTask001
{
    class Program
    {
        static List<(int, int)> testValues = new List<(int, int)>()
        {
            (75,25),
            (44,28),
            (105,55),
            (789,447)
        };

        static void Main(string[] args)
        {
             Console.WriteLine("----------------------------------------");
             Console.WriteLine("\t\tTests");
             Console.WriteLine("----------------------------------------");

            testValues.ForEach(value =>
            {
                Console.WriteLine($"EvklidAlgorithm({value.Item1};{value.Item2})={EvklidAlgorithm(value.Item1,value.Item2)}");
                Console.WriteLine($"BinaryAlgorithm({value.Item1};{value.Item2})={BinaryEvklidAlgorithm(value.Item1, value.Item2)}");
            });

             Console.WriteLine("----------------------------------------");
             Console.WriteLine("\t\tWithTheTime");
             Console.WriteLine("----------------------------------------");

             TimeSpan time, timeSec;

             int firstValue = 781, secondValue = 231;


            Console.WriteLine($"NOD({firstValue};{secondValue}) = {AlgorithmWithTheTime(EvklidAlgorithm, firstValue, secondValue, out timeSec)}" +
                  $" time: {timeSec.TotalMilliseconds} ms");

            Console.WriteLine($"NOD({firstValue};{secondValue}) = {AlgorithmWithTheTime(BinaryEvklidAlgorithm, firstValue, secondValue, out time)} " +
                  $"time: {time.TotalMilliseconds} ms");


            Console.WriteLine("----------------------------------------");
            Console.WriteLine("\t\tData for BarGraph");
            Console.WriteLine("----------------------------------------");

            var list = DataForBarGraph(firstValue, secondValue);

            list.ForEach(value => Console.WriteLine(value));

            


            Console.ReadKey();
        }
    }
}
