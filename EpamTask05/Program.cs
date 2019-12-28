using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<Int32> tree = new Tree<int>(50);

            Random rand = new Random();

            for (int i = 0; i < 20; i++)
            {
                int value = rand.Next(0, 100);

                if (!tree.Contains(value))
                    tree.AddNode(value);

            }


            Console.WriteLine();
            tree.View(new TreePrinter<Int32>());





            Console.ReadKey();
        }
    }
}
