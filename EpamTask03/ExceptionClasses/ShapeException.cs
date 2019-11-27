using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask03.ExceptionClasses
{
    public class ShapeException : Exception
    {
        public ShapeException(string message) : base(message)
        {
        }

        public ShapeException()
        {
        }


        public static void CatchSquareException(AbstractShape firstShape,AbstractShape secShape)
        {
            if (firstShape.GetSquare() >= secShape.GetSquare())
                throw new ShapeException($"Impossible to cut new {firstShape.GetType().Name} from {secShape.GetType().Name} because of size");
        }

        public static void CatchTypeException(AbstractShape firstShape,AbstractShape secShape)
        {
            if ((firstShape is IColor) != (secShape is IColor))
                throw new ShapeException($"Impossible to cun new {firstShape.GetType().Name} from {secShape.GetType().Name} becase of types");
        }

        public static void CatchArgumentException(double argument)
        {
            if (argument <= 0)
                throw new ShapeException("Invalid value for shape");
        }

    }
}
