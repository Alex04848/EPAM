using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03.ClassesOfShapes
{
    public class FilmIsoscelesTriangle : AbstractIsoscelesTriangle
    {
        public FilmIsoscelesTriangle(double sideA, double sideB) : base(sideA,sideB)
        {
        }

        public FilmIsoscelesTriangle()
        {
        }

        public FilmIsoscelesTriangle(double sideA, double sideB,AbstractShape shape) : base(sideA, sideB, shape)
        {
        }

    }
}
