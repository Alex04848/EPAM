using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03.ClassesOfShapes
{
    /// <summary>
    /// The square from film material
    /// </summary>
    public class FilmSquare : AbstractSquare
    {
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public FilmSquare()
        {
        }

        /// <summary>
        /// Constructor witho one parameter
        /// </summary>
        public FilmSquare(double side) : base(side)
        {
        }

        /// <summary>
        /// Constructor witho two parameters
        /// </summary>
        public FilmSquare(double side,AbstractShape shape) : base(side,shape)
        {
        }
    }
}
