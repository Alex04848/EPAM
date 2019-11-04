using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask02._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vFirst = new Vector(1, 2, 3);
            Vector vSecond = new Vector(2,9,17);


            vFirst *= 5;

            Console.WriteLine(vFirst);

            Console.WriteLine(vFirst * vSecond);


            Console.ReadKey();
        }
    }
}
