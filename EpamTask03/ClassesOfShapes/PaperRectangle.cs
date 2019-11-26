using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03
{
    class PaperRectangle : AbstractRectangle, IColor
    {
        public ConsoleColor Color { get; }

        public PaperRectangle(double width,double height,ConsoleColor color) : base(width,height)
        {
            Color = color;
        }

        public PaperRectangle(double width,double height) : this(width, height, ConsoleColor.White)
        {
        }

        public PaperRectangle() : this(default,default)
        {
        }

        public PaperRectangle(AbstractEquilateralTriangle triangle) : base(triangle)
        {
        }



        public override string ToString() => ($"{base.ToString()};{Color}");
    }
}
