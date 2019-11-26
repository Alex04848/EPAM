using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03
{
    public abstract class AbstractRectangle : AbstractShape
    {
        public double Width {

            get => width;

            set {
                if (value >= 0)
                    width = value;
                else
                    throw new ArgumentException("Invalid argument");
            }
        }

        double width;

        public double Height
        {
            get => height;

            set
            {
                if (value >= 0)
                    height = value;
                else
                    throw new ArgumentException("Invalid argument");
            }
        }

        double height;

        public AbstractRectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public AbstractRectangle() : this(default, default)
        {
        }

        public AbstractRectangle(AbstractEquilateralTriangle triangle)
        {

            Width = (triangle.Side / 2);
            Height = ((Math.Sqrt(Math.Pow(triangle.Side, 2) - Math.Pow((triangle.Side / 2), 2))) / 3);

            //triangle.Dispose();
        }



        public override double GetPerimeter() => (2*(Width+Height));

        public override double GetSquare() => (Width * Height);


        public override string ToString() => ($"{Width};{Height};{GetType().Name}");
    }
}
