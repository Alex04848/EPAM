﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.ClassesOfShapes
{
    /// <summary>
    /// The class describes paper triangle shape,
    /// The class inherits from AbstractTriangle 
    /// class and implements IColor inteface
    /// </summary>
    public class PaperTriangle : AbstractTriangle, IColor
    {
        public ConsoleColor Color
        {

            get => backFieldColor;

            set
            {
                if (isSetted)
                    throw new ColorException("The shape already painted");

                backFieldColor = value;
                isSetted = true;
            }
        }

        ConsoleColor backFieldColor = ConsoleColor.White;

        bool isSetted;


        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public PaperTriangle()
        {   
        }

        /// <summary>
        /// Constructor with three parameters
        /// </summary>
        public PaperTriangle(double sideA, double sideB, double sideC) : base(sideA, sideB, sideC)
        {
        }

        /// <summary>
        /// Constructor with four parameters
        /// </summary>
        public PaperTriangle(double sideA, double sideB, double sideC, ConsoleColor color) : base(sideA, sideB, sideC)
        {
            Color = color;
        }

        /// <summary>
        /// Constructor with four parameters
        /// </summary>
        public PaperTriangle(double sideA,double sideB,double sideC,string color) : this(sideA, sideB, sideC, ColorParser.Parse(color))
        {
        }

        /// <summary>
        /// Constructor with four parameters
        /// </summary>
        public PaperTriangle(double sideA, double sideB, double sideC, AbstractShape shape) : base(sideA, sideB, sideC, shape)
        {
            backFieldColor = (shape as IColor).Color;
        }




        /// <summary>
        /// Overrided method ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ($"{base.ToString()};{Color}");
    }
}
