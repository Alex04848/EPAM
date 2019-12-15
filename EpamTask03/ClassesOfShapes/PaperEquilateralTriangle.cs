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
    /// The class describes paper equilateral triangle shape,
    /// The class inherits from AbstractEquilateralTriangle 
    /// class and implements IColor inteface
    /// </summary>
    public class PaperEquilateralTriangle : AbstractEquilateralTriangle, IColor
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
        public PaperEquilateralTriangle()
        {
        }

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        public PaperEquilateralTriangle(double side) : base(side)
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public PaperEquilateralTriangle(double side, ConsoleColor color) : base(side)
        {
            Color = color;
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public PaperEquilateralTriangle(double side,string color) : this(side, ColorParser.Parse(color))
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public PaperEquilateralTriangle(double side, AbstractShape shape) : base(side,shape)
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
