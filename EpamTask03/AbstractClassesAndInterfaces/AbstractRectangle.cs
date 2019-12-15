using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;

namespace EpamTask03
{
    /// <summary>
    /// The Abctract Class of a rectangle shape 
    /// </summary>
    public abstract class AbstractRectangle : AbstractShape
    {
        /// <summary>
        /// Width of a rectangle
        /// </summary>
        public double Width {

            get => width;

            set {

                if (value == height)
                    throw new ShapeException("Invalid value");

                ShapeException.CatchArgumentException(value);
                width = value;
            }
        }

        double width;

        /// <summary>
        /// Height of a rectangle
        /// </summary>
        public double Height
        {
            get => height;

            set
            {
                if (value == width)
                    throw new ShapeException("Invalid value");

                ShapeException.CatchArgumentException(value);
                height = value;
            }
        }

        double height;

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        /// <param name="radius"></param>
        public AbstractRectangle()
        {
            width = default;
            height = default;
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        /// <param name="radius"></param>
        public AbstractRectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        /// <param name="radius"></param>
        public AbstractRectangle(double width,double height,AbstractShape shape) : this(width,height)
        {
            ShapeException.CatchSquareException(this, shape);
            ShapeException.CatchTypeException(this, shape);
        }

        /// <summary>
        /// Overrided method GetPerimeter
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter() => (2*(Width+Height));

        /// <summary>
        /// Overrided method GetSquare
        /// </summary>
        /// <returns></returns>
        public override double GetSquare() => (Width * Height);


        /// <summary>
        /// Overrided method ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ($"{this.GetType().Name};{Width};{Height}");
    }
}
