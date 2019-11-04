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
        /// Операция сложения векторов
        /// </summary>
        /// <param name="vectorFirst"></param>
        /// <param name="vectorSecond"></param>
        /// <returns></returns>
        public static Vector operator +(Vector vectorFirst, Vector vectorSecond)
            => (new Vector( (vectorFirst.XValue + vectorSecond.XValue), (vectorFirst.YValue + vectorSecond.YValue) , (vectorFirst.ZValue + vectorSecond.ZValue)));


        /// <summary>
        /// Операция вычитания векторов
        /// </summary>
        /// <param name="vectorFirst"></param>
        /// <param name="vectorSecond"></param>
        /// <returns></returns>
        public static Vector operator -(Vector vectorFirst, Vector vectorSecond)
            => (new Vector((vectorFirst.XValue - vectorSecond.XValue), (vectorFirst.YValue - vectorSecond.YValue), (vectorFirst.ZValue - vectorSecond.ZValue)));

        /// <summary>
        /// Операция умножения вектора на число
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Vector operator *(Vector vector, double number)
            => (new Vector(vector.XValue*number,vector.YValue*number,vector.ZValue*number));

        /// <summary>
        /// Операция деления вектора на число
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Vector operator /(Vector vector, double number)
          => (new Vector(vector.XValue / number, vector.YValue / number, vector.ZValue / number));

        /// <summary>
        /// Операция умножения векторов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator *(Vector a, Vector b)
           => (new Vector((a.YValue*b.ZValue - a.ZValue*b.YValue),(a.ZValue*b.XValue - a.XValue*b.ZValue), (a.XValue*b.YValue - a.YValue*b.XValue)));

        /// <summary>
        /// Перегрузка статической операции сравнения
        /// </summary>
        /// <param name="vFirst"></param>
        /// <param name="vSec"></param>
        /// <returns></returns>
        public static bool operator ==(Vector vFirst, Vector vSec)
            => (vFirst.XValue == vSec.XValue && vFirst.YValue == vSec.YValue && vFirst.ZValue == vFirst.ZValue);

        /// <summary>
        /// Перегрузка статической операции сравнения
        /// </summary>
        /// <param name="vFirst"></param>
        /// <param name="vSec"></param>
        /// <returns></returns>
        public static bool operator !=(Vector vFirst, Vector vSec)
           => (vFirst.XValue != vSec.XValue && vFirst.YValue != vSec.YValue && vFirst.ZValue != vFirst.ZValue);

        /// <summary>
        /// Переопределение виртуального метода Equals типа Object
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
        ///  При переопределении метода Equals рекомендуется переопределять и метода GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
            => ((XValue + YValue + ZValue).GetHashCode());

        /// <summary>
        /// Переопределение виртуального метода ToString типа Object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override string ToString() => ($"{XValue};{YValue};{ZValue}");
    }
}
