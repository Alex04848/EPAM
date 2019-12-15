using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.AbstractClassesAndInterfaces
{
    /// <summary>
    /// The Abctract Class of a square shape 
    /// </summary>
    public abstract class AbstractSquare : AbstractShape
    {
        /// <summary>
        /// All sides are equal
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
        public AbstractSquare()
        {
            side = default;
        }

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        public AbstractSquare(double side)
        {
            Side = side;
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public AbstractSquare(double side,AbstractShape shape) : this(side)
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
                => (side*side);


        /// <summary>
        /// Overrided method ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ($"{this.GetType().Name};{side}");
    }
}
