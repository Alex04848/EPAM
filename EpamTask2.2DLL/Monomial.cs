using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask2._2DLL
{

    /// <summary>
    ///The type describe monimial
    /// </summary>
    public class Monomial : ICloneable
    {
        /// <summary>
        /// Coefficient for multiplication on a current variable
        /// </summary>
        public double Coefficient { get; set; }

        /// <summary>
        /// Degree of a variable
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
        /// Multiplication on a number
        /// </summary>
        /// <param name="monomial"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Monomial operator *(Monomial monomial, double number)
            => (new Monomial(monomial.Coefficient*number,monomial.Degree));

        /// <summary>
        /// Multiplication on a monomial
        /// </summary>
        /// <param name="monomial"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Monomial operator *(Monomial mFirst, Monomial mSecond)
           => (new Monomial( (mFirst.Coefficient * mSecond.Coefficient) , (mFirst.Degree + mSecond.Degree) ));

        /// <summary>
        /// Division of a monomial on a number
        /// </summary>
        /// <param name="monomial"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Monomial operator /(Monomial monomial, double number)
          => (new Monomial(monomial.Coefficient / number, monomial.Degree));

        /// <summary>
        /// Division of a monomial on an other monomial
        /// </summary>
        /// <param name="mFirst"></param>
        /// <param name="mSec"></param>
        /// <returns></returns>
        public static Monomial operator /(Monomial mFirst, Monomial mSec)
            => (new Monomial( (mFirst.Coefficient / mSec.Coefficient),(mFirst.Degree - mSec.Degree)));

        /// <summary>
        /// Override of a method Equals of type object
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
        /// Usually recommended override GetHashCode if Equals already overrided
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
            => (Degree.GetHashCode());

        /// <summary>
        /// A method that performs a copy of an object
        /// </summary>
        /// <returns></returns>
        public object Clone() 
            => this.MemberwiseClone();
        
        /// <summary>
        /// Override of a method ToString() of type object
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ($"({Coefficient})*x^({Degree})");
    }
}
