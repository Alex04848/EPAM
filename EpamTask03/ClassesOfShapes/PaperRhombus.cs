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
    /// The class describes paper rhombus shape,
    /// The class inherits from AbstractRhombus 
    /// class and implements IColor inteface
    /// </summary>
    public class PaperRhombus : AbstractRhombus, IColor
    {
        public ConsoleColor Color {

            get => backFieldColor;

            set {
                if (isSetted)
                    throw new ShapeException("The shape is already painted");

                backFieldColor = value;
                isSetted = true;
            }
        }

        ConsoleColor backFieldColor = ConsoleColor.White;

        bool isSetted;



        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public PaperRhombus()
        {
        }

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        public PaperRhombus(double side) : base(side)
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public PaperRhombus(double side, ConsoleColor color) : base(side)
        {
            Color = color;
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public PaperRhombus(double side,string color) : this(side, ColorParser.Parse(color))
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public PaperRhombus(double side,AbstractShape shape) : base(side, shape)
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
