using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask02._1
{
    public class Vector
    {
        public double XValue { get; set; }
        public double YValue{ get; set; }
        public double ZValue { get; set; }


        public Vector(double x,double y, double z)
        {
            XValue = x;
            YValue = y;
            ZValue = z;
        }

        public Vector() : this(default, default, default)
        {
        }

        public static Vector operator +(Vector vectorFirst, Vector vectorSecond)
            => (new Vector( (vectorFirst.XValue + vectorSecond.XValue), (vectorFirst.YValue + vectorSecond.YValue) , (vectorFirst.ZValue + vectorSecond.ZValue)));

        public static Vector operator -(Vector vectorFirst, Vector vectorSecond)
            => (new Vector((vectorFirst.XValue - vectorSecond.XValue), (vectorFirst.YValue - vectorSecond.YValue), (vectorFirst.ZValue - vectorSecond.ZValue)));

        public static Vector operator *(Vector vector, double number)
            => (new Vector(vector.XValue*number,vector.YValue*number,vector.ZValue*number));

        public static Vector operator /(Vector vector, double number)
          => (new Vector(vector.XValue / number, vector.YValue / number, vector.ZValue / number));

        public static Vector operator *(Vector a, Vector b)
           => (new Vector((a.YValue*b.ZValue - a.ZValue*b.YValue),(a.ZValue*b.XValue - a.XValue*b.ZValue), (a.XValue*b.YValue - a.YValue*b.XValue)));



        public override string ToString() => ($"{XValue};{YValue};{ZValue}");
    }
}
