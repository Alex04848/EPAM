using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03
{
    public class FilmRectangle : AbstractRectangle
    {

        public FilmRectangle(double width,double height) : base(width,height)
        {
        }

        public FilmRectangle() : base()
        {
        }

        public FilmRectangle(AbstractEquilateralTriangle triangle) : base(triangle)
        {
        }

    }
}
