using EpamTask05.ClassesOfDataStructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EpamTask05
{
    class Program
    {
        static List<GradeOfTest> gradesOfTests = new List<GradeOfTest>()
        {
            new GradeOfTest("Alex",4,"System Programming",new DateTime(2019,12,24)),
            new GradeOfTest("Paul",6,"AVS",new DateTime(2019,12,4)),
            new GradeOfTest("Tuchelio",7,"System Programming",new DateTime(2019,12,4)),
            new GradeOfTest("Paul Svintuchelly",10,"MDSUBD",new DateTime(2019,5,19)),
            new GradeOfTest("Alex",8,"MOuY",new DateTime(2019,12,28))
        };

        static void Main(string[] args)
        {           
            Tree<GradeOfTest> treeWithGrades = new Tree<GradeOfTest>(gradesOfTests.First());

            gradesOfTests.Skip(1).ToList().ForEach(grade => treeWithGrades.AddNode(grade));

            Console.WriteLine("\n\n");

            treeWithGrades.View(new TreeOfGradesOfTestsPrinter());


            Console.ReadKey();
        }

    }
}
