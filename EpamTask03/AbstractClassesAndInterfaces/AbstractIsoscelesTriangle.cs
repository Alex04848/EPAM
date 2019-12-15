using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.AbstractClassesAndInterfaces
{
    /// <summary>
    /// The class of a isosceles triangle 
    /// </summary>
    public abstract class AbstractIsoscelesTriangle : AbstractShape
    {
        /// <summary>
        /// Left side and right side should be equal
        /// </summary>
        public double LeftAndRightSide {

            get => leftAndRightSide;

            set
            {
                ShapeException.CatchArgumentException(value);

                if (value == bottomSide)
                    throw new ShapeException("Invalid argument!!!");
                else if (2 * value <= bottomSide)
                    throw new ShapeException("Invalid argument!!!");

                leftAndRightSide = value;

            }
        }

        /// <summary>
        /// Bottom side of a triangle
        /// </summary>
        public double BottomSide {

            get => bottomSide;

            set
            {
                ShapeException.CatchArgumentException(value);

                if (value == leftAndRightSide)
                    throw new ShapeException("Invalid argument!!!");
                else if (2 * leftAndRightSide <= value)
                    throw new ShapeException("Invalid argument!!!");

                bottomSide = value;
            }
        } 

        double leftAndRightSide;

        double bottomSide;

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public AbstractIsoscelesTriangle()
        {
            bottomSide = leftAndRightSide = default;
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        /// <param name="radius"></param>
        public AbstractIsoscelesTriangle(double leftAndRightSide, double bottomSide)
        {
            LeftAndRightSide = leftAndRightSide;
            BottomSide = bottomSide;
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        /// <param name="radius"></param>
        public AbstractIsoscelesTriangle(double leftAndRightSide, double bottomSide, AbstractShape shape) : this(leftAndRightSide, bottomSide)
        {
            ShapeException.CatchSquareException(this, shape);
            ShapeException.CatchTypeException(this, shape);
        }

        /// <summary>
        /// Overrided method GetPerimeter
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter() 
            => (2*leftAndRightSide + bottomSide);

        /// <summary>
        /// Overrided method GetSquare
        /// </summary>
        /// <returns></returns>
        public override double GetSquare()
            => ((0.5)* bottomSide * Math.Sqrt(Math.Pow(leftAndRightSide,2) - Math.Pow((bottomSide / 2),2)));



        /// <summary>
        /// Overrided method ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ($"{this.GetType().Name};{LeftAndRightSide};{bottomSide}");
    }
}
