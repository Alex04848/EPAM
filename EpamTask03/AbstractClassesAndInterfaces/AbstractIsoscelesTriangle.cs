using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.AbstractClassesAndInterfaces
{
    public abstract class AbstractIsoscelesTriangle : AbstractShape
    {
        public double SideA {

            get => sideA;

            set
            {
                ShapeException.CatchArgumentException(value);

                if (value == sideA)
                    throw new ShapeException("Invalid argument!!!");

                sideB = value;

            }
        }

        public double SideB {

            get => sideB;

            set
            {
                ShapeException.CatchArgumentException(value);

                if (value == sideA)
                    throw new ShapeException("Invalid argument!!!");

                sideB = value;
            }
        } 

        double sideA;

        double sideB;

        public AbstractIsoscelesTriangle()
        {
            sideA = default;
            sideB = default;
        }

        public AbstractIsoscelesTriangle(double sideA,double sideB)
        {
            SideA = sideA;
            SideB = sideB;
        }

        public AbstractIsoscelesTriangle(double sideA,double sideB,AbstractShape shape) : this(sideA, sideB)
        {
            ShapeException.CatchSquareException(this, shape);
            ShapeException.CatchTypeException(this, shape);
        }

        public override double GetPerimeter() 
            => (2*sideA + sideB);

        public override double GetSquare()
            => ((0.5)*sideB*Math.Sqrt(Math.Pow(sideA,2) - Math.Pow((sideB/2),2)));


        public override string ToString()
            => ($"{this.GetType().Name};{sideA};{sideB}");
    }
}
