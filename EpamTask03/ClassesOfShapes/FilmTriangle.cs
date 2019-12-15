﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03.ClassesOfShapes
{
    /// <summary>
    /// The trianle from film material
    /// </summary>
    public class FilmTriangle : AbstractTriangle
    {
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public FilmTriangle()
        {
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        public FilmTriangle(double sideA,double sideB,double sideC) : base(sideA, sideB, sideC)
        {
        }

        /// <summary>
        /// Constructor with four parameters
        /// </summary>
        public FilmTriangle(double sideA,double sideB,double sideC,AbstractShape shape) : base(sideA,sideB,sideC,shape)
        { 
        }
    }
}
