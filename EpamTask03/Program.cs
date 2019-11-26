using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ClassesOfShapes;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03
{
    class Program
    {
        static void Main(string[] args)
        {
            PaperRectangle paperRectangle = new PaperRectangle(20, 20, ConsoleColor.Green);

            FilmEquilateralTriangle triangle = new FilmEquilateralTriangle(5.5);

            Display(triangle);

            FilmRectangle filmRect = new FilmRectangle(triangle);

            Console.WriteLine();

            Display(filmRect);

            


            Console.ReadKey();
        }


        public static void Display(AbstractShape shape)
        {
            Console.WriteLine(shape);

            Console.WriteLine($"Perimeter():{shape.GetPerimeter():F2}");

            Console.WriteLine($"Square():{shape.GetSquare():F2}");
        }
    }
}
