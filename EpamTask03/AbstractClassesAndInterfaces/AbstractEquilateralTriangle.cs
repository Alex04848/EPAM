using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.AbstractClassesAndInterfaces
{
    public abstract class AbstractEquilateralTriangle : AbstractShape
    {
        public double Side {

            get => side;

            set
            {
                ShapeException.CatchArgumentException(value);
                side = value;
            }
        }

        double side;

        public AbstractEquilateralTriangle(double side)
        {
            Side = side;
        }

        public AbstractEquilateralTriangle()
        {
            side = default;
        }

        public AbstractEquilateralTriangle(double side,AbstractShape shape) : this(side)
        {
            ShapeException.CatchSquareException(this, shape);
            ShapeException.CatchTypeException(this, shape);
        }


        public override double GetPerimeter() => (3*side);

        public override double GetSquare() => ((side/2)*(Math.Sqrt(Math.Pow(side,2) - Math.Pow((side/2),2))));

        public override string ToString() => ($"{this.GetType().Name};{Side}");
    }
}
