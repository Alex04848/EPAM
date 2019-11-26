using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03.ClassesOfShapes
{
    public class PaperCircle : AbstractCircle, IColor
    {
        public ConsoleColor Color { get; }

        public PaperCircle(double radius,ConsoleColor color) : base(radius)
        {
            Color = color;
        }

        public PaperCircle(double radius) : base(radius)
        {
        }

        public PaperCircle() : base(default)
        {
        }

        public override string ToString() => ($"{base.ToString()};{Color}");
    }
}
