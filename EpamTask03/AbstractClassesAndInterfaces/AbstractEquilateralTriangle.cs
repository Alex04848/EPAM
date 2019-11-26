using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask03.AbstractClassesAndInterfaces
{
    public abstract class AbstractEquilateralTriangle : AbstractShape
    {
        public double Side {
            get => side;
            set
            {
                if (value >= 0)
                    side = value;
                else
                    throw new ArgumentException("Invalid argument");
            }
        }

        double side;

        public AbstractEquilateralTriangle(double side)
        {
            Side = side;
        }

        public AbstractEquilateralTriangle() : this(default)
        {
        }


        public override double GetPerimeter() => (3*side);

        public override double GetSquare() => ((side/2)*(Math.Sqrt(Math.Pow(side,2) - Math.Pow((side/2),2))));

        public override string ToString() => ($"{Side};{GetType().Name}");
    }
}
