using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.AbstractClassesAndInterfaces
{
    public abstract class AbstractCircle : AbstractShape
    {
        public double Radius
        {
            get => radius;

            set
            {
                ShapeException.CatchArgumentException(value);
                radius = value;
            }

        }

        double radius;
        
        public AbstractCircle(double radius)
        {
            Radius = radius;
        }

        public AbstractCircle()
        {
            radius = default;
        }

        public AbstractCircle(double radius,AbstractShape shape) : this(radius)
        {
            ShapeException.CatchSquareException(this, shape);
            ShapeException.CatchTypeException(this, shape);
        }

        public override double GetPerimeter() => (2*Math.PI*Radius);

        public override double GetSquare() => (Math.PI*Math.Pow(Radius,2));


        public override string ToString() => ($"{Radius};{this.GetType().Name}");
    }
}
