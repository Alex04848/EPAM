using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;

namespace EpamTask03
{
    class PaperRectangle : AbstractRectangle, IColor
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

        public PaperRectangle(double width,double height,ConsoleColor color) : base(width,height)
        {
            Color = color;
        }

        public PaperRectangle(double width,double height) : this(width, height, ConsoleColor.White)
        {
        }

        public PaperRectangle()
        {
            Color = ConsoleColor.White;
        }

        public PaperRectangle(double width, double height, AbstractShape shape) : this(width, height, shape,ConsoleColor.White)
        {
        }

        public PaperRectangle(double width,double height,AbstractShape shape, ConsoleColor color) : base(width,height,shape)
        {
            Color = color;
        }

        public PaperRectangle(double width, double height, string color) : this(width, height, ColorParser.Parse(color))
        {
        }

        public PaperRectangle(double width,double height,AbstractShape shape, string color) : this(width, height,shape, ColorParser.Parse(color))
        {
        }




        public override string ToString() => ($"{base.ToString()};{Color}");
    }
}
