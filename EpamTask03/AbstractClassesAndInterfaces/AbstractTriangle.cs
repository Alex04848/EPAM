using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ExceptionClasses;


namespace EpamTask03.AbstractClassesAndInterfaces
{
    /// <summary>
    /// The Abctract Class of a triangle shape 
    /// </summary>
    public abstract class AbstractTriangle : AbstractShape
    {
        /// <summary>
        /// First side of triangle
        /// </summary>
        public double SideA {

            get => sideA;

            set
            {
                ShapeException.CatchArgumentException(value);

                if (value == sideB || value == sideC)
                    throw new ShapeException("Invalid argument!!!");
                else if (sideB != default && sideC != default)
                    if((sideB + sideC <= value) || (sideB + value <= sideC) || (sideC + value <= sideB))
                        throw new ShapeException("Invalid argument!!!");

                sideA = value;
            }

        }

        /// <summary>
        /// Second side of triangle
        /// </summary>
        public double SideB
        {
            get => sideB;

            set
            {
                ShapeException.CatchArgumentException(value);


                if (value == sideA || value == sideC)
                    throw new ShapeException("Invalid argument!!!");
                else if(sideA != default && sideC != default)
                    if ((sideA + sideC <= value) || (sideA + value <= sideC) || (sideC + value <= sideA))
                        throw new ShapeException("Invalid argument!!!");

                sideB = value;
            }
        }

        /// <summary>
        /// Third side of triangle
        /// </summary>
        public double SideC {

            get => sideC;

            set
            {
                ShapeException.CatchArgumentException(value);


                if (value == sideB || value == sideA)
                    throw new ShapeException("Invalid argument!!!");
                else if (sideA != default && sideB != default)
                    if ((sideA + sideB <= value) || (sideA + value <= sideB) || (sideB + value <= sideA))
                        throw new ShapeException("Invalid argument!!!");

                sideC = value;
            }
        }

        double sideA;

        double sideB;

        double sideC;

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        /// <param name="radius"></param>
        public AbstractTriangle()
        {
            sideC = sideA = sideB = default;
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        /// <param name="radius"></param>
        public AbstractTriangle(double sideA,double sideB,double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        /// <summary>
        /// Constructor with four parameters
        /// </summary>
        /// <param name="radius"></param>
        public AbstractTriangle(double sideA, double sideB, double sideC,AbstractShape shape) : this(sideA, sideB, sideC)
        {
            ShapeException.CatchSquareException(this, shape);
            ShapeException.CatchTypeException(this, shape);
        }

        /// <summary>
        /// Overrided method GetPerimeter
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter()
            => (sideA + sideB + sideC);

        /// <summary>
        /// Overrided method GetSquare
        /// </summary>
        /// <returns></returns>
        public override double GetSquare()
        {
            double halfOfPerimeter = (this.GetPerimeter() / 2.0);

            return (Math.Sqrt(halfOfPerimeter*(halfOfPerimeter - sideA)*(halfOfPerimeter - sideB)*(halfOfPerimeter - sideC)) );
        }



        /// <summary>
        /// Overrided method ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ($"{this.GetType().Name};{sideA};{sideB};{sideC}");
    }
}
