using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03.ClassesOfShapes
{
    public class PaperIsoscelesTriangle : AbstractIsoscelesTriangle, IColor
    {
        public ConsoleColor Color { get; }

        public PaperIsoscelesTriangle()
        {
            Color = ConsoleColor.White;
        }

        public PaperIsoscelesTriangle(double sideA,double sideB,ConsoleColor color) : base(sideA,sideB)
        {
            Color = color;
        }

        public PaperIsoscelesTriangle(double sideA,double sideB) : this(sideA, sideB, ConsoleColor.White)
        {
        }

        public PaperIsoscelesTriangle(double sideA, double sideB,AbstractShape shape, ConsoleColor color) : base(sideA,sideB,shape)
        {
            Color = color;
        }

        public PaperIsoscelesTriangle(double sideA, double sideB, AbstractShape shape) : this(sideA, sideB, shape, ConsoleColor.White)
        {
        }

        public override string ToString() => ($"{base.ToString()};{Color}");
    }
}
