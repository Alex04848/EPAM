using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03.ClassesOfShapes
{
    public class FilmTriangle : AbstractTriangle
    {
        public FilmTriangle()
        {
        }

        public FilmTriangle(double sideA,double sideB,double sideC) : base(sideA, sideB, sideC)
        {
        }

        public FilmTriangle(double sideA,double sideB,double sideC,AbstractShape shape) : base(sideA,sideB,sideC,shape)
        { 
        }
    }
}
