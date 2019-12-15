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
    /// The class describes paper isosceles triangle shape,
    /// The class inherits from AbstractIsoscelesTriangle 
    /// class and implements IColor inteface
    /// </summary>
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

        ConsoleColor backFieldColor = ConsoleColor.White;

        bool isSetted;


        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public PaperIsoscelesTriangle()
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public PaperIsoscelesTriangle(double leftAndRightSide,double bottomSide) : base(leftAndRightSide,bottomSide)
        {
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        public PaperIsoscelesTriangle(double leftAndRightSide, double bottomSide,ConsoleColor color) : base(leftAndRightSide, bottomSide)
        {
            Color = color;
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        public PaperIsoscelesTriangle(double leftAndRightSide, double bottomSide, string color) : this(leftAndRightSide, bottomSide, ColorParser.Parse(color))
        {
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        public PaperIsoscelesTriangle(double leftAndRightSide, double bottomSide, AbstractShape shape) : base(leftAndRightSide, bottomSide, shape)
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
