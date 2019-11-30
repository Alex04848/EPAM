using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask03.HelpClasses
{
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
