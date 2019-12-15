using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03.ClassesOfShapes
{
    /// <summary>
    /// The isosceles triangle from film material
    /// </summary>
    public class FilmIsoscelesTriangle : AbstractIsoscelesTriangle
    {
        /// <summary>
        /// Constructor without parameters
        /// </summary> 
        public FilmIsoscelesTriangle()
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary> 
        public FilmIsoscelesTriangle(double sideA, double sideB) : base(sideA,sideB)
        {
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary> 
        public FilmIsoscelesTriangle(double sideA, double sideB,AbstractShape shape) : base(sideA, sideB, shape)
        {
        }

    }
}
