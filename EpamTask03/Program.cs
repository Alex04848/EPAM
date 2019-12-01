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
            Box box = new Box(new List<AbstractShape>() {
                new FilmRectangle(20,10),
                new PaperCircle(5,"Green"),
                new PaperTriangle(5,7,9,"Yellow"),
                new FilmCircle(7),
                new FilmEquilateralTriangle(9.5),
                new PaperIsoscelesTriangle(5.5,4,"Cyan")
            });
  
            box.Shapes.ForEach(shape => {

                Console.WriteLine();
                shape.Display();
                Console.WriteLine();

            });
         
            Console.WriteLine($"ViewByIndex: {box[0]}");

            Console.WriteLine($"GetByIndex: {box.GetByIndex(2)}");

            Console.WriteLine($"CountOfShapes: {box.CurrentCount}");


            Console.ReadKey();
        }
    }
}
