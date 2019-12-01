using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask2._2DLL
{
    /// <summary>
    /// The type describe polynomial
    /// </summary>
    public class Polynomial : ICloneable
    {
        /// <summary>
        /// The list which contains all monomials. Polynomial is the sum of these monomials.
        /// </summary>
        public List<Monomial> Monomials { get; private set; }

        public Polynomial() : this(new List<Monomial>())
        {
        }

        public Polynomial(List<Monomial> monomials)
        {
            Monomials = monomials;
        }

        /// <summary>
        /// The sum of the monomials with equal degrees
        /// </summary>
        /// <returns></returns>
        List<Monomial> GetWithoutTheSameMonomials()
        {
            Polynomial polynomial = new Polynomial();

            Monomials.ForEach(monomialValue => polynomial += monomialValue);

            return (polynomial.Monomials.OrderByDescending(monomialValue => monomialValue.Degree).ToList());
        }

        /// <summary>
        /// The sum of a polynomial and a monomial
        /// </summary>
        /// <returns></returns>
        public static Polynomial operator +(Polynomial polynomial,Monomial monomial)
        {
            Polynomial polynomialResult = (polynomial.Clone() as Polynomial);

            if (polynomialResult.Monomials.Any(monomialValue => monomialValue.Degree == monomial.Degree))
                polynomialResult.Monomials.First(monomialValue => monomialValue.Degree == monomial.Degree).Coefficient += monomial.Coefficient;
            else
                polynomialResult.Monomials.Add(monomial);


            polynomialResult.Monomials = polynomialResult.Monomials.Where(monomialValue => monomialValue.Coefficient != 0)
                .OrderByDescending(monomialValue => monomialValue.Degree).ToList();

            return polynomialResult;
        }

        /// <summary>
        /// The subtraction of a polynomial and a monomial
        /// </summary>
        /// <returns></returns>
        public static Polynomial operator -(Polynomial polynomial, Monomial monomial)
            => (polynomial + monomial * (-1));

        /// <summary>
        /// The sum of the polynomials
        /// </summary>
        /// <param name="first"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        public static Polynomial operator +(Polynomial first, Polynomial sec)
        {
            Polynomial polynomial = (first.Clone() as Polynomial);
            sec.Monomials.ForEach(monomialValue => polynomial += monomialValue);


            return polynomial;
        }

        /// <summary>
        /// The subtraction of the polynomials
        /// </summary>
        /// <param name="first"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        public static Polynomial operator -(Polynomial first, Polynomial sec)
            => (first + sec * (-1.0));

        /// <summary>
        /// The multiplication of a polynomial on a monomial
        /// </summary>
        /// <param name="polynomial"></param>
        /// <param name="monomial"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial polynomial, Monomial monomial)
        {
            Polynomial polynomialResult = (polynomial.Clone() as Polynomial);
            polynomialResult.Monomials = polynomialResult.Monomials.Select(monomialValue => monomialValue *= monomial).ToList();
            polynomial.Monomials = polynomial.GetWithoutTheSameMonomials();

            return polynomialResult;
        }

        /// <summary>
        /// The multiplication of the polynomials
        /// </summary>
        /// <param name="polynomial"></param>
        /// <param name="monomial"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial first, Polynomial sec)
        {
            Polynomial polynomial = new Polynomial();
            first.Monomials.ForEach(monomialValue
                => polynomial += (sec * monomialValue));

            return polynomial;
        }

        /// <summary>
        /// The multiplication of a polynomial on a number
        /// </summary>
        /// <param name="polynomial"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Polynomial operator*(Polynomial polynomial,double number)
        {
            Polynomial resultPolynomial = (polynomial.Clone() as Polynomial);
            resultPolynomial.Monomials = resultPolynomial.Monomials.Select(monomialValue => monomialValue *= number).ToList();
            return resultPolynomial;
        }

        /// <summary>
        /// Деление многочлена на константное значение
        /// </summary>
        /// <param name="polynomial"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Polynomial operator /(Polynomial polynomial, double number)
        {
            Polynomial resultPolynomial = (polynomial.Clone() as Polynomial);
            resultPolynomial.Monomials = resultPolynomial.Monomials.Select(monomialValue => monomialValue /= number).ToList();
            return resultPolynomial;
        }

        /// <summary>
        /// A method that performs a copy of an object
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            List<Monomial> monomialsForCopy = new List<Monomial>();
            Monomials
                .ForEach(monomialValue => monomialsForCopy.Add(monomialValue.Clone() as Monomial));

            return (new Polynomial(monomialsForCopy));
        }

        /// <summary>
        /// A method that performs conversation of current polynomial to string
        /// </summary>
        /// <returns></returns>
        StringBuilder GetAllPolynomial()
        {
            StringBuilder polynomialString = new StringBuilder();

            Monomials.ForEach(monomialValue =>
            {
                if (polynomialString.Length != 0)
                    polynomialString.Append($"+{monomialValue}");
                else
                    polynomialString.Append(monomialValue.ToString());

            });

            return polynomialString;
        }

        /// <summary>
        /// Override of a method Equals of type object
        /// </summary>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Polynomial polynom && polynom.Monomials.Count == Monomials.Count)
            {
                bool resultOfComparing = true;
                Monomials
                    .Select(monomialValue => polynom.Monomials.Any(monomialValSec => monomialValSec.Equals(monomialValue))).ToList()
                    .ForEach(boolValue => resultOfComparing = (resultOfComparing && boolValue));

                return resultOfComparing;
            }
            else
                return false;

        }

        /// <summary>
        /// Usually recommended override GetHashCode if Equals already overrided
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => (Monomials.Count.GetHashCode());

        /// <summary>
        /// Override of a method ToString() ob type object
        /// </summary>
        /// <returns></returns>
        public override string ToString() => (GetAllPolynomial().ToString());      
    }
}
