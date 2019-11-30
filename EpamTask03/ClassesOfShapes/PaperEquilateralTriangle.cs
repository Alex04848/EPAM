using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03.ClassesOfShapes
{
    public class PaperEquilateralTriangle : AbstractEquilateralTriangle, IColor
    {
        public ConsoleColor Color { get; }

        public PaperEquilateralTriangle(double side,ConsoleColor color) : base(side)
        {
            Color = color;
        }

        public PaperEquilateralTriangle(double side) : this(side, ConsoleColor.White)
        {
        }

        public PaperEquilateralTriangle()
        {
            Color = ConsoleColor.White;
        }

        public PaperEquilateralTriangle(double side,AbstractShape shape) : this(side,shape,ConsoleColor.White)
        {
        }

        public PaperEquilateralTriangle(double side,AbstractShape shape,ConsoleColor color) : base(side,shape)
        {
            Color = color;
        }

        public PaperEquilateralTriangle(double side,string color) : this(side, ColorParser.Parse(color))
        {
        }

        public PaperEquilateralTriangle(double side,AbstractShape shape,string color) : this(side, shape, ColorParser.Parse(color))
        {
        }



        public override string ToString() => ($"{base.ToString()};{Color}");
    }
}
