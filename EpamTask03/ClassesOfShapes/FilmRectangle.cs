using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;

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

        public FilmRectangle(double width,double height,AbstractShape shape) : base(width, height, shape)
        {
        } 
    }
}
