using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.AbstractClassesAndInterfaces
{
    /// <summary>
    /// The Abctract Class of a parallelogram shape 
    /// </summary>
    public abstract class AbstractParallelogram : AbstractShape
    {
        /// <summary>
        /// Left side and right side of a shape should be equal and parallel 
        /// </summary>
        public double LeftAndRightSide {

            get => leftAndRightSide;

            set
            {
                ShapeException.CatchArgumentException(value);

                if (value == bottomAndTopSide)
                    throw new ShapeException("Invalid argument");

                leftAndRightSide = value;
            }
        }

        /// <summary>
        /// Bottom side and top side of a shape should be equal and parallel 
        /// </summary>
        public double BottomAndTopSide
        {
            get => bottomAndTopSide;

            set
            {
                ShapeException.CatchArgumentException(value);

                if (value == leftAndRightSide)
                    throw new ShapeException("Invalid argument");

                bottomAndTopSide = value;
            }

        }

        /// <summary>
        /// It's an angle between left side and bottom side
        /// </summary>
        public double Angle
        {
            get => angle;

            set
            {
                ShapeException.CatchArgumentException(value);

                if (value >= (Math.PI / 2.0))
                    throw new ShapeException("The angle of parallelogram can't be more than 90 degrees");

                angle = value;
            }

        }


        double leftAndRightSide;

        double bottomAndTopSide;

        double angle = (Math.PI / 6);

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public AbstractParallelogram()
        {
            leftAndRightSide = bottomAndTopSide = default;
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        /// <param name="radius"></param>
        public AbstractParallelogram(double leftAndRightSide, double bottomAndTopSide)
        {
            LeftAndRightSide = leftAndRightSide;
            BottomAndTopSide = bottomAndTopSide;
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        /// <param name="leftAndRightSide"></param>
        /// <param name="bottomAndTopSide"></param>
        /// <param name="angleInDegrees"></param>
        public AbstractParallelogram(double leftAndRightSide,double bottomAndTopSide, double angleInDegrees) : this(leftAndRightSide,bottomAndTopSide)
        {
            Angle = (angleInDegrees / 57);
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        /// <param name="radius"></param>
        public AbstractParallelogram(double leftAndRightSide,double bottomAndTopSide,AbstractShape shape) : this(leftAndRightSide, bottomAndTopSide)
        {
            ShapeException.CatchSquareException(this, shape);
            ShapeException.CatchTypeException(this, shape);
        }

        /// <summary>
        /// Overrided method GetPerimeter
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
                    => (2*(leftAndRightSide + bottomAndTopSide));

        /// <summary>
        /// Overrided method GetSquare
        /// </summary>
        /// <returns></returns>
        public override double GetSquare()
                    => (leftAndRightSide*bottomAndTopSide*Math.Sin(angle));


        /// <summary>
        /// Overrided method ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ($"{this.GetType().Name};{leftAndRightSide};{bottomAndTopSide};{angle*57}");
    }
}
