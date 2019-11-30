using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03.ClassesOfShapes
{
    public class PaperTriangle : AbstractTriangle, IColor
    {
        public ConsoleColor Color { get; } 

        public PaperTriangle()
        {
            Color = ConsoleColor.White;
        }

        public PaperTriangle(double sideA,double sideB,double sideC,ConsoleColor color) : base(sideA, sideB, sideC)
        {
            Color = color;
        }

        public PaperTriangle(double sideA, double sideB, double sideC) : this(sideA, sideB, sideC, ConsoleColor.White)
        {
        }

        public PaperTriangle(double sideA, double sideB, double sideC,AbstractShape shape,ConsoleColor color) : base(sideA, sideB, sideC,shape)
        {
            Color = color;
        }

        public PaperTriangle(double sideA, double sideB, double sideC, AbstractShape shape) : this(sideA,sideB,sideC,shape,ConsoleColor.White)
        {
        }

        public PaperTriangle(double sideA,double sideB,double sideC,string color) : this(sideA, sideB, sideC, ColorParser.Parse(color))
        {
        }

        public PaperTriangle(double sideA,double sideB,double sideC,AbstractShape shape,string color) : this(sideA, sideB, sideC, shape, ColorParser.Parse(color))
        {
        }



        public override string ToString() => ($"{base.ToString()};{Color}");
    }
}
