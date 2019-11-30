using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;

namespace EpamTask03
{
    public abstract class AbstractRectangle : AbstractShape
    {
        public double Width {

            get => width;

            set {
                ShapeException.CatchArgumentException(value);
                width = value;
            }
        }

        double width;

        public double Height
        {
            get => height;

            set
            {
                ShapeException.CatchArgumentException(value);
                height = value;
            }
        }

        double height;

        public AbstractRectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public AbstractRectangle()
        {
            width = default;
            height = default;
        }

        public AbstractRectangle(double width,double height,AbstractShape shape) : this(width,height)
        {
            ShapeException.CatchSquareException(this, shape);
            ShapeException.CatchTypeException(this, shape);
        }


        public override double GetPerimeter() => (2*(Width+Height));

        public override double GetSquare() => (Width * Height);


        public override string ToString() => ($"{this.GetType().Name};{Width};{Height}");
    }
}
