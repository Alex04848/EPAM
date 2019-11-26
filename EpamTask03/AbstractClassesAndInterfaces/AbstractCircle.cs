using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask03.AbstractClassesAndInterfaces
{
    public abstract class AbstractCircle : AbstractShape
    {
        public double Radius
        {
            get => radius;

            set
            {
                if (value >= 0)
                    radius = value;
                else
                    throw new ArgumentException("Invalid argument");
            }

        }

        double radius;

        
        public AbstractCircle(double radius)
        {
            Radius = radius;
        }

        public AbstractCircle() : this(default)
        {
        }

        public override double GetPerimeter() => (2*Math.PI*Radius);

        public override double GetSquare() => (Math.PI*Math.Pow(Radius,2));


        public override string ToString() => ($"{Radius};{GetType().Name}");
    }
}
