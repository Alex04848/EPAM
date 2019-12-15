using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.AbstractClassesAndInterfaces
{
    /// <summary>
    /// The class of an equilateral triangle 
    /// </summary>
    public abstract class AbstractEquilateralTriangle : AbstractShape
    {
        /// <summary>
        /// All sides of an equilateral triangle should be equal.
        /// That's why I use only one field and property for this field
        /// </summary>
        public double Side {

            get => side;

            set
            {
                ShapeException.CatchArgumentException(value);

                side = value;
            }
        }

        double side;

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public AbstractEquilateralTriangle()
        {
            side = default;
        }

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        /// <param name="radius"></param>
        public AbstractEquilateralTriangle(double side)
        {
            Side = side;
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        /// <param name="radius"></param>
        public AbstractEquilateralTriangle(double side,AbstractShape shape) : this(side)
        {
            ShapeException.CatchSquareException(this, shape);
            ShapeException.CatchTypeException(this, shape);
        }

        /// <summary>
        /// Overrided method GetPerimeter
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter() => (3*side);

        /// <summary>
        /// Overrided method GetSquare
        /// </summary>
        /// <returns></returns>
        public override double GetSquare() => ((side/2)*(Math.Sqrt(Math.Pow(side,2) - Math.Pow((side/2),2))));


        /// <summary>
        /// Overrided method ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ($"{this.GetType().Name};{Side}");
    }
}
