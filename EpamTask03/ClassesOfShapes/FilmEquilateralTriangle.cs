using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.ClassesOfShapes
{
    /// <summary>
    /// The equilateral triangle from film material
    /// </summary>
    public class FilmEquilateralTriangle : AbstractEquilateralTriangle
    {
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public FilmEquilateralTriangle()
        {
        }

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        public FilmEquilateralTriangle(double side) : base(side)
        {
        }

        /// <summary>
        /// Constructor witho two parameter
        /// </summary>
        public FilmEquilateralTriangle(double side,AbstractShape shape) : base(side,shape)
        {
        } 

    }
}
