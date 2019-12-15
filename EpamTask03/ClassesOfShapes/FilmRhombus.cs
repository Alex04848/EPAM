using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03.ClassesOfShapes
{
    /// <summary>
    /// The rhombus from film material
    /// </summary>
    public class FilmRhombus : AbstractRhombus
    {
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public FilmRhombus()
        {
        }

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        public FilmRhombus(double side) : base(side)
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public FilmRhombus(double side, AbstractRhombus shape) : base(side,shape)
        {
        }
    }
}
