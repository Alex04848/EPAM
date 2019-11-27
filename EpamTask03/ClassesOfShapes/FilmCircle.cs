using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.ClassesOfShapes
{
    public class FilmCircle : AbstractCircle
    {
        public FilmCircle(double radius) : base(radius)
        {
        }

        public FilmCircle() : base()
        {
        }

        public FilmCircle(double radius,AbstractShape shape) : base(radius, shape)
        {
        }

    }
}
