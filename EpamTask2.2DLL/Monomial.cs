using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask2._2DLL
{

    /// <summary>
    /// Класс который описывает тип одночлена
    /// </summary>
    public class Monomial : ICloneable
    {
        /// <summary>
        /// Коэффициент на который умножается переменная
        /// </summary>
        public double Coefficient { get; set; }
        /// <summary>
        /// Степень переменной
        /// </summary>
        public double Degree { get; set; }

        public Monomial(double coef,double degree)
        {
            Coefficient = coef;
            Degree = degree;
        }

        public Monomial() : this(default, default)
        {
        }

        /// <summary>
        /// Умножение одночлена на число
        /// </summary>
        /// <param name="monomial"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Monomial operator *(Monomial monomial, double number)
            => (new Monomial(monomial.Coefficient*number,monomial.Degree));

        /// <summary>
        /// Умножение одночлена на другой одночлен
        /// </summary>
        /// <param name="monomial"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Monomial operator *(Monomial mFirst, Monomial mSecond)
           => (new Monomial( (mFirst.Coefficient * mSecond.Coefficient) , (mFirst.Degree + mSecond.Degree) ));

        /// <summary>
        /// Деление одночлена на число
        /// </summary>
        /// <param name="monomial"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Monomial operator /(Monomial monomial, double number)
          => (new Monomial(monomial.Coefficient / number, monomial.Degree));

        /// <summary>
        /// Деление одночлена на другой одночлен
        /// </summary>
        /// <param name="mFirst"></param>
        /// <param name="mSec"></param>
        /// <returns></returns>
        public static Monomial operator /(Monomial mFirst, Monomial mSec)
            => (new Monomial( (mFirst.Coefficient / mSec.Coefficient),(mFirst.Degree - mSec.Degree)));

        /// <summary>
        /// Переопределение метода Equals() типа object
        /// </summary>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Monomial mono)
                return (this.Degree == mono.Degree && this.Coefficient == mono.Coefficient);
            else
                return false;
        }

        /// <summary>
        /// Обычно рекомендуется переопределять GetHashCode при переопределении Equals()
        /// В данном случае берётся метод от св-ва Degree
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
            => (Degree.GetHashCode());

        /// <summary>
        /// Данный метод выполняет клонирование объект с помощью метода MemberwiseClone типа object
        /// данный метод выполняет неглубокое копирование, но в данном случае он подходит
        /// </summary>
        /// <returns></returns>
        public object Clone() 
            => this.MemberwiseClone();
        
        /// <summary>
        /// Переопределение метода ToString() типа object
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ($"({Coefficient})*x^({Degree})");
    }
}
