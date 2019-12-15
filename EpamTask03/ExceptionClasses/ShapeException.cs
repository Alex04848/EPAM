using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03.ExceptionClasses
{
    /// <summary>
    /// The class which represents exceptions class for the shapes
    /// </summary>
    public class ShapeException : Exception
    {
        /// <summary>
        /// Constructor gets a descripiton string 
        /// </summary>
        /// <param name="message"></param>
        public ShapeException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public ShapeException()
        {
        }

        /// <summary>
        /// It's impossible to cut bigger shape from current,
        /// this method compares squares of the shapes and 
        /// throws new exception if a shape for cut is bigger
        /// </summary>
        /// <param name="firstShape"></param>
        /// <param name="secShape"></param>
        public static void CatchSquareException(AbstractShape firstShape,AbstractShape secShape)
        {
            if (firstShape.GetSquare() >= secShape.GetSquare())
                throw new ShapeException($"Impossible to cut new {firstShape.GetType().Name} from {secShape.GetType().Name} because of size");
        }

        /// <summary>
        /// It's impossible to create film shape from paper shape,
        /// or maybe paper shape from film shape. This method is for comparision,
        /// if something wrong with material, the method throws exception. 
        /// </summary>
        /// <param name="firstShape"></param>
        /// <param name="secShape"></param>
        public static void CatchTypeException(AbstractShape firstShape,AbstractShape secShape)
        {
            if ((firstShape is IColor) != (secShape is IColor))
                throw new ShapeException($"Impossible to cun new {firstShape.GetType().Name} from {secShape.GetType().Name} becase of types");
        }

        /// <summary>
        /// Every argument should be bigger than zero 
        /// </summary>
        /// <param name="argument"></param>
        public static void CatchArgumentException(double argument)
        {
            if (argument <= 0)
                throw new ShapeException("Invalid value for shape");
        }

    }
}
