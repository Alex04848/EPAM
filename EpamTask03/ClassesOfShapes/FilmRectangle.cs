using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;

namespace EpamTask03
{
    /// <summary>
    /// The rectangle from film material
    /// </summary>
    public class FilmRectangle : AbstractRectangle
    {
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public FilmRectangle()
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public FilmRectangle(double width,double height) : base(width,height)
        {
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        public FilmRectangle(double width,double height,AbstractShape shape) : base(width, height, shape)
        {
        } 
    }
}
