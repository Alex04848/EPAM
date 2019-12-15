using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;

namespace EpamTask03.ClassesOfShapes
{

    /// <summary>
    /// The class describes paper circle shape,
    /// The class inherits from AbsctractCircle 
    /// class and implements IColor inteface
    /// </summary>
    public class PaperCircle : AbstractCircle, IColor
    {
        public ConsoleColor Color {

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
        public PaperCircle()
        {
        }

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        public PaperCircle(double radius) : base(radius)
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public PaperCircle(double radius, ConsoleColor color) : base(radius)
        {
            Color = color;
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public PaperCircle(double radius, string color) : this(radius, ColorParser.Parse(color))
        {
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        public PaperCircle(double radius,AbstractShape shape) : base(radius,shape)
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
