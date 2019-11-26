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

        public PaperEquilateralTriangle() : this(default, ConsoleColor.White)
        {
        }


        public override string ToString() => ($"{base.ToString()};{Color}");
    }
}
