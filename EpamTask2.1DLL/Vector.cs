using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask02._1DLL
{

    /// <summary>
    /// Класс Вектор предназначенный для работы с трёхмерным вектором
    /// </summary>
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


        /// <summary>
        /// The sum operation
        /// </summary>
        /// <param name="vectorFirst"></param>
        /// <param name="vectorSecond"></param>
        /// <returns></returns>
        public static Vector operator +(Vector vectorFirst, Vector vectorSecond)
            => (new Vector( (vectorFirst.XValue + vectorSecond.XValue), (vectorFirst.YValue + vectorSecond.YValue) , (vectorFirst.ZValue + vectorSecond.ZValue)));


        /// <summary>
        /// Subtraction of the vectors
        /// </summary>
        /// <param name="vectorFirst"></param>
        /// <param name="vectorSecond"></param>
        /// <returns></returns>
        public static Vector operator -(Vector vectorFirst, Vector vectorSecond)
            => (new Vector((vectorFirst.XValue - vectorSecond.XValue), (vectorFirst.YValue - vectorSecond.YValue), (vectorFirst.ZValue - vectorSecond.ZValue)));

        /// <summary>
        /// Multiplication of a vector on a number
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Vector operator *(Vector vector, double number)
            => (new Vector(vector.XValue*number,vector.YValue*number,vector.ZValue*number));

        /// <summary>
        /// Operation of division of a vector on a number
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Vector operator /(Vector vector, double number)
          => (new Vector(vector.XValue / number, vector.YValue / number, vector.ZValue / number));

        /// <summary>
        /// Operation of multiplication of the vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator *(Vector a, Vector b)
           => (new Vector((a.YValue*b.ZValue - a.ZValue*b.YValue),(a.ZValue*b.XValue - a.XValue*b.ZValue), (a.XValue*b.YValue - a.YValue*b.XValue)));

        /// <summary>
        /// Overload of a static operation of comparing
        /// </summary>
        /// <param name="vFirst"></param>
        /// <param name="vSec"></param>
        /// <returns></returns>
        public static bool operator ==(Vector vFirst, Vector vSec)
            => (vFirst.XValue == vSec.XValue && vFirst.YValue == vSec.YValue && vFirst.ZValue == vFirst.ZValue);

        /// <summary>
        /// Overload of a static operation of comparing
        /// </summary>
        /// <param name="vFirst"></param>
        /// <param name="vSec"></param>
        /// <returns></returns>
        public static bool operator !=(Vector vFirst, Vector vSec)
           => (vFirst.XValue != vSec.XValue && vFirst.YValue != vSec.YValue && vFirst.ZValue != vFirst.ZValue);

        /// <summary>
        /// Override of a virtual method Equals of type Object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector vector)
                return (this == vector);
            else
                return false;
        }

        /// <summary>
        ///  Overrided method GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
            => ((XValue + YValue + ZValue).GetHashCode());

        /// <summary>
        /// Override of a virtual method ToString of type Object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override string ToString() => ($"{XValue};{YValue};{ZValue}");
    }
}
