using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ClassesOfShapes;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;

namespace EpamTask03
{
    class Program
    {
        static void Main(string[] args)
        {


            try
            {
                PaperTriangle triangle = new PaperTriangle(4, 5, 7, ConsoleColor.Red);

                triangle.Display();

                PaperCircle paperCircle = new PaperCircle();

                PaperRectangle paperRectangle = new PaperRectangle();

                PaperEquilateralTriangle paperEquilateralTriangle = new PaperEquilateralTriangle();


            } 
            catch (ShapeException shapeExcpt)
            {
                Console.WriteLine(shapeExcpt.Message);
            }


           



            Console.ReadKey();
        }


      
    }

    public static class ShapeViewer
    {
        public static void Display(this AbstractShape shape)
        {
            if (shape is IColor)
                Console.ForegroundColor = (shape as IColor).Color;

            Console.WriteLine(shape);

            Console.WriteLine($"Perimeter = {shape.GetPerimeter():F2}");

            Console.WriteLine($"Square = {shape.GetSquare():F2}");

            Console.ResetColor();
        }
    }

}
