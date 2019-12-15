using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask03.HelpClasses
{
    /// <summary>
    /// The static class which has only one method.
    /// This method is for viewing of a shape.
    /// I could write this method in AbstractShape class,
    /// but it would be a big mistake and violation of a Single Responsibility Principle,
    /// because AbstractShape class describes only essence of an abstract shape 
    /// and this class only print information about a shape.
    /// </summary>
    public static class ShapeViewer
    {

        /// <summary>
        /// The method which displays information. 
        /// </summary>
        /// <param name="shape"></param>
        public static void Display(this AbstractShape shape)
        {
            if (shape != null)
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
}
