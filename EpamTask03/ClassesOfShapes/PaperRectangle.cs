using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.ClassesOfShapes
{
    /// <summary>
    /// The class describes paper rectangle shape,
    /// The class inherits from AbstractRectangle 
    /// class and implements IColor inteface
    /// </summary>
    public class PaperRectangle : AbstractRectangle, IColor
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

        ConsoleColor backFieldColor = ConsoleColor.White;

        bool isSetted;


        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public PaperRectangle()
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public PaperRectangle(double width,double height) : base(width, height)
        {
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        public PaperRectangle(double width, double height, ConsoleColor color) : base(width, height)
        {
            Color = color;
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        public PaperRectangle(double width, double height, string color) : this(width, height, ColorParser.Parse(color))
        {
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        public PaperRectangle(double width, double height, AbstractShape shape) : base(width, height, shape)
        {
            backFieldColor = (shape as IColor).Color;
        }



        /// <summary>
        /// Overrided method ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ($"{base.ToString()};{Color}");
    }
}
