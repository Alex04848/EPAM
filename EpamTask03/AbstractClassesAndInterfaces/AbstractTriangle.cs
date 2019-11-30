using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ExceptionClasses;


namespace EpamTask03.AbstractClassesAndInterfaces
{
    public abstract class AbstractTriangle : AbstractShape
    {
        public double SideA {

            get => sideA;

            set
            {
                ShapeException.CatchArgumentException(value);

                if (value == sideB || value == sideC)
                    throw new ShapeException("Invalid argument!!!");

                sideA = value;
            }

        }

        public double SideB
        {
            get => sideB;

            set
            {
                ShapeException.CatchArgumentException(value);


                if (value == sideA || value == sideC)
                    throw new ShapeException("Invalid argument!!!");

                sideB = value;
            }
        }

        public double SideC {

            get => sideC;

            set
            {
                ShapeException.CatchArgumentException(value);


                if (value == sideB || value == sideA)
                    throw new ShapeException("Invalid argument!!!");

                sideC = value;
            }
        }

        double sideA;

        double sideB;

        double sideC;

        public AbstractTriangle(double sideA,double sideB,double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public AbstractTriangle()
        {
            sideC = sideA = sideB = default;
        }

        public AbstractTriangle(double sideA, double sideB, double sideC,AbstractShape shape) : this(sideA, sideB, sideC)
        {
            ShapeException.CatchSquareException(this, shape);
            ShapeException.CatchTypeException(this, shape);
        }

        public override double GetPerimeter()
            => (sideA + sideB + sideC);

        public override double GetSquare()
        {
            double halfOfPerimeter = this.GetPerimeter();

            return (Math.Sqrt(halfOfPerimeter*(halfOfPerimeter - sideA)*(halfOfPerimeter - sideB)*(halfOfPerimeter - sideC)) );
        }

        public override string ToString() => ($"{this.GetType().Name};{sideA};{sideB};{sideC}");
    }
}
