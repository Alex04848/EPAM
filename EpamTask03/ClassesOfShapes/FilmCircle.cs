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
    /// The circle from film material
    /// </summary>
    public class FilmCircle : AbstractCircle
    {
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public FilmCircle()
        {
        }

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        public FilmCircle(double radius) : base(radius)
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public FilmCircle(double radius,AbstractShape shape) : base(radius, shape)
        {
        }

    }
}
