using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03.ClassesOfShapes
{
    /// <summary>
    /// The parallelogram from film material
    /// </summary>
    public class FilmParallelogram : AbstractParallelogram
    {
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public FilmParallelogram()
        {
        }

        /// <summary>
        /// Constructor witho two parameters
        /// </summary>

        public FilmParallelogram(double leftAndRightSide,double bottomAndTopSide) : base(leftAndRightSide,bottomAndTopSide)
        {
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        public FilmParallelogram(double leftAndRightSide, double bottomAndTopSide,AbstractShape shape) : base(leftAndRightSide, bottomAndTopSide,shape)
        {
        }

    }
}
