using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ExceptionClasses;

namespace EpamTask03
{
    public abstract class AbstractShape : IDisposable
    {
        public abstract double GetPerimeter();
        public abstract double GetSquare();


        public override bool Equals(object obj)
              => ((obj is AbstractShape shape) && (this.GetType() == obj.GetType()) 
            && (this.GetSquare() == shape.GetSquare()) 
            &&  ((this as IColor)?.Color == (obj as IColor)?.Color));

        public override int GetHashCode()
              => (GetSquare().GetHashCode());

        public void Dispose()
        {
            Dispose();
        }
    }
}
