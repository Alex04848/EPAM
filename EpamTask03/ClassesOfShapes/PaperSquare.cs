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
    /// The class describes paper square shape,
    /// The class inherits from AbstractSquare 
    /// class and implements IColor inteface
    /// </summary>
    public class PaperSquare : AbstractSquare, IColor
    {
        public ConsoleColor Color {

            get => backFieldColor;

            set {
                if (isSetted)
                    throw new ShapeException("The shape already painted");

                backFieldColor = value;
                isSetted = true;
            }
        }

        ConsoleColor backFieldColor = ConsoleColor.White;

        bool isSetted;


        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public PaperSquare()
        {
        }

        public PaperSquare(double side) : base(side)
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public PaperSquare(double side, ConsoleColor color) : base(side)
        {
            Color = color;
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public PaperSquare(double side,string color) : this(side, ColorParser.Parse(color))
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public PaperSquare(double side,AbstractShape shape) : base(side, shape)
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
