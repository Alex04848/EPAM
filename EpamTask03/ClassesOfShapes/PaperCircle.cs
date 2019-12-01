using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.ClassesOfShapes
{
    public class PaperCircle : AbstractCircle, IColor
    {
        public ConsoleColor Color {

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

        public PaperCircle(double radius, ConsoleColor color) : base(radius)
        {
            Color = color;
        }

        public PaperCircle(double radius, AbstractShape shape, ConsoleColor color) : base(radius, shape)
        {
            Color = color;
        }

        public PaperCircle(double radius) : base(radius)
        {
        }

        public PaperCircle()
        {
            Color = ConsoleColor.White;
        }

        public PaperCircle(double radius,AbstractShape shape) : this(radius, shape, ConsoleColor.White)
        {
        }

        public PaperCircle(double radius,string color) : this(radius, ColorParser.Parse(color))
        {
        }

        public PaperCircle(double radius,AbstractShape shape,string color) : this(radius,shape, ColorParser.Parse(color))
        {

        }




        public override string ToString() => ($"{base.ToString()};{Color}");
    }
}
