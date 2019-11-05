using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask2._2DLL
{
    /// <summary>
    /// Данный тип является типом многочлена и описывает перегруженные для него операции
    /// </summary>
    public class Polynomial : ICloneable
    {
        /// <summary>
        /// Данный список представляет одночлены сумма которых равна исходному многочлену
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
        /// Данный метод складывает одночлены у которых переменные одинаковой степени
        /// и возвращает упорядоченную последовательность
        /// </summary>
        /// <returns></returns>
        List<Monomial> GetWithoutTheSameMonomials()
        {
            Polynomial polynomial = new Polynomial();

            Monomials.ForEach(monomialValue => polynomial += monomialValue);

            return (polynomial.Monomials.OrderByDescending(monomialValue => monomialValue.Degree).ToList());
        }

        /// <summary>
        /// Данный метод складывает многочлен и одночлен 
        /// и возвращает упорядоченную последовательность
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
        /// Данный метод вычитает многочлен и одночлен 
        /// и возвращает упорядоченную последовательность
        /// </summary>
        /// <returns></returns>
        public static Polynomial operator -(Polynomial polynomial, Monomial monomial)
            => (polynomial + monomial * (-1));

        /// <summary>
        /// Сумма многочленов
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
        /// Разность многочленов
        /// </summary>
        /// <param name="first"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        public static Polynomial operator -(Polynomial first, Polynomial sec)
            => (first + sec * (-1.0));

        /// <summary>
        /// Умножение Многочлена на одночлен
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
        /// Умножение Многочлена на многочлен
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
        /// Умножение многочлена на константное значение
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
        /// Данный метод выполняет клонирование объект с помощью метода MemberwiseClone типа object
        /// данный метод выполняет неглубокое копирование, но в данном случае он подходит
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
        /// Данный метод выполняет преобразование всего многочлена в строку типа StringBuilder.
        /// StringBuilder используется так как операция Append используется довольно часто, и тип string здесь не сильно подойдёт
        /// так как он представляет неизменяемую последовательность символов.
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
        /// В данном методе выполняется сравнение многолченов,
        /// они считаются равными если содержат одинаковое кол-во одночленов и
        /// каждому одночлену в одном многочлене соответствует такой же в другом многочлене
        /// </summary>
        /// <param name="obj"></param>
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
        /// Обычно рекомендуется переопределять GetHashCode при переопределении Equals()
        /// В данном случае берётся метод от св-ва Degree
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => (Monomials.Count.GetHashCode());

        /// <summary>
        /// Переопределение метода ToString() типа object
        /// </summary>
        /// <returns></returns>
        public override string ToString() => (GetAllPolynomial().ToString());      
    }
}
