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
    /// The class describes paper parallelogram shape,
    /// The class inherits from AbstractParallelogram 
    /// class and implements IColor inteface
    /// </summary>
    public class PaperParallelogram : AbstractParallelogram , IColor
    {
        public ConsoleColor Color {

            get => backFieldColor;

            set
            {
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
        public PaperParallelogram()
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public PaperParallelogram(double leftAndRightSide,double bottomAndTopSide) : base(leftAndRightSide, bottomAndTopSide)
        {
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        public PaperParallelogram(double leftAndRightSide, double bottomAndTopSide,ConsoleColor color) : base(leftAndRightSide, bottomAndTopSide)
        {
            Color = color;
        }

        /// <summary>
        /// Constructor with four parameters
        /// </summary>
        public PaperParallelogram(double leftAndRightSide, double bottomAndTopSide, double angleInDegrees, ConsoleColor color) : base(leftAndRightSide,bottomAndTopSide,angleInDegrees)
        {
            Color = color;
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        public PaperParallelogram(double leftAndRightSide, double bottomAndTopSide, string color) : this(leftAndRightSide, bottomAndTopSide, ColorParser.Parse(color))
        {
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        public PaperParallelogram(double leftAndRightSide, double bottomAndTopSide,AbstractShape shape) : base(leftAndRightSide,bottomAndTopSide,shape)
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
