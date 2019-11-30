using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ClassesOfShapes;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;
using EpamTask03.InputOutputClasses;
using EpamTask03.HelpClasses;

namespace EpamTask03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AbstractShape> shapes = IOXml.OutputInList(@"C:\Users\xxxal\Desktop\BoxSec.xml");

            Box box = new Box(shapes);


            box.Shapes.ForEach(shape => shape.Display());


            var paperRect = new PaperRectangle(20, 10, "Green");

            if (!box.ContainsShape(paperRect))
                box.AddShape(paperRect);


            IOXml.InputInXmlFile(box, @"C:\Users\xxxal\Desktop\BoxFirst.xml");

            IOStreams.InputInXmlFile(box, @"C:\Users\xxxal\Desktop\BoxSec.xml");



            Console.ReadKey();
        }
    }
}
