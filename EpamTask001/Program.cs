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
        static void Main(string[] args)
        {
            Console.WriteLine(EvklidAlgorithm(75, 25));
            Console.WriteLine(EvklidAlgorithm(75, 40, 25));
            Console.WriteLine(EvklidAlgorithm(75, 40, 25, 55, 555));
            Console.WriteLine(EvklidAlgorithm());





            Console.ReadKey();
        }
    }
}
