using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask03
{
    public abstract class AbstractShape : IDisposable
    {
        public abstract double GetPerimeter();
        public abstract double GetSquare();


        public override bool Equals(object obj)
              => ((obj is AbstractShape shape) && (this.GetSquare() > shape.GetSquare()));

        public override int GetHashCode()
              => (GetSquare().GetHashCode());

        public void Dispose()
        {
            Dispose();
        }
    }
}
