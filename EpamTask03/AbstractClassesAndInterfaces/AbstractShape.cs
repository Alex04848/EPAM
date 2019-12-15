using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ExceptionClasses;

namespace EpamTask03
{

    /// <summary>
    /// The Main class for all Shapes
    /// The class contains two virtual methods:
    /// 1) GetPerimeter() for perimeter
    /// 2) GetSquare for square
    /// </summary>
    public abstract class AbstractShape
    {
        public abstract double GetPerimeter();
        public abstract double GetSquare();

        /// <summary>
        /// This method compare an object obj with a current shape.
        /// The method returns true if:
        /// 1) Obj is a shape
        /// 2) The types of the shapes are equal
        /// 3) If The shapes created from paper, they should have an equal color
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
              => ((obj is AbstractShape shape) && (this.GetType() == obj.GetType()) 
            && (this.GetSquare() == shape.GetSquare()) 
            &&  ((this as IColor)?.Color == (obj as IColor)?.Color));

        /// <summary>
        /// The method gets HashCode from the square of the shape
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
              => (GetSquare().GetHashCode());
    }
}
