using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.ClassesOfShapes
{
    public class PaperIsoscelesTriangle : AbstractIsoscelesTriangle, IColor
    {
        public ConsoleColor Color
        {

            get => backFieldColor;

            set
            {
                if (isSetted)
                    throw new ColorException("The shape already painted");

                backFieldColor = value;
                isSetted = true;
            }
        }


        ConsoleColor backFieldColor;

        bool isSetted = false;

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

        public PaperIsoscelesTriangle(double sideA, double sideB, string color) : this(sideA, sideB, ColorParser.Parse(color))
        {
        }

        public PaperIsoscelesTriangle(double sideA,double sideB,AbstractShape shape, string color) : this(sideA, sideB, shape, ColorParser.Parse(color))
        {
        }



        public override string ToString() => ($"{base.ToString()};{Color}");
    }
}
