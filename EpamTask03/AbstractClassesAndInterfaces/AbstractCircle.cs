﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.AbstractClassesAndInterfaces
{
    /// <summary>
    /// The Abctract Class of a circle shape 
    /// </summary>
    public abstract class AbstractCircle : AbstractShape
    {
        /// <summary>
        /// Radius of a circle
        /// </summary>
        public double Radius
        {
            get => radius;
      
            set
            {
                ShapeException.CatchArgumentException(value);
                radius = value;
            }

        }

        double radius;
        
        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        /// <param name="radius"></param>
        public AbstractCircle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public AbstractCircle()
        {
            radius = default;
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        /// <param name="radius"></param>
        public AbstractCircle(double radius,AbstractShape shape) : this(radius)
        {
            ShapeException.CatchSquareException(this, shape);
            ShapeException.CatchTypeException(this, shape);
        }

        /// <summary>
        /// Overrided method GetPerimeter
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter() => (2*Math.PI*Radius);
        /// <summary>
        /// Overrided method GetSquare
        /// </summary>
        /// <returns></returns>
        public override double GetSquare() => (Math.PI*Math.Pow(Radius,2));


        /// <summary>
        /// Overrided method ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ($"{this.GetType().Name};{Radius}");
    }
}
