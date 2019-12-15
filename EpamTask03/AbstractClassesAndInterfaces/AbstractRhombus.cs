using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.AbstractClassesAndInterfaces
{
    /// <summary>
    /// The Abctract Class of a rhombus shape 
    /// </summary>
    public abstract class AbstractRhombus : AbstractShape
    {
        /// <summary>
        /// Rhombus is a parallelogram where all 
        /// sides are equal.
        /// </summary>
        public double Side
        {
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
        /// <param name="radius"></param>
        public AbstractRhombus()
        {
            side = default;
        }

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        /// <param name="radius"></param>
        public AbstractRhombus(double side)
        {
            Side = side;
        }

        /// <summary>
        /// Constructor with two parameter
        /// </summary>
        /// <param name="radius"></param>
        public AbstractRhombus(double side, AbstractShape shape) : this(side)
        {
            ShapeException.CatchSquareException(this, shape);
            ShapeException.CatchTypeException(this, shape);
        }


        /// <summary>
        /// Overrided method GetPerimeter
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
                    => (4*side);

        /// <summary>
        /// Overrided method GetSquare
        /// </summary>
        /// <returns></returns>
        public override double GetSquare()
            => (side*side*Math.Sin(Math.PI / 3.0));


        /// <summary>
        /// Overrided method ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ($"{this.GetType().Name};{side}");
    }
}
