using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask2._2DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask2._2DLL.Tests
{
    [TestClass()]
    public class PolynomialTests
    {

        /// <summary>
        /// A method that performs sum of a polynomial and a monomial
        /// </summary>
        [TestMethod()]
        public void PolynomialTestSumWithMonomial()
        {
            //arrange
            Polynomial polynomial = new Polynomial(new List<Monomial>()
            {
                new Monomial(5.0,3),
                new Monomial(2.0,2),
                new Monomial(2.0,1)
            });

            Monomial monomial = new Monomial(2, 2);

            Polynomial expected = new Polynomial(new List<Monomial>()
            {
                new Monomial(5.0,3),
                new Monomial(4.0,2),
                new Monomial(2.0,1)
            });

            //act
            Polynomial resultOfMult = polynomial + monomial;


            //assert
            Assert.AreEqual(expected, resultOfMult);
        }

        /// <summary>
        /// A method that performs subtraction of a polynomial and a monomial
        /// </summary>
        [TestMethod()]
        public void PolynomialTestSubWithMonomial()
        {
            //arrange
            Polynomial polynomial = new Polynomial(new List<Monomial>()
            {
                new Monomial(5.0,3),
                new Monomial(2.0,2),
                new Monomial(2.0,1)
            });

            Monomial monomial = new Monomial(2, 2);

            Polynomial expected = new Polynomial(new List<Monomial>()
            {
                new Monomial(5.0,3),
                new Monomial(2.0,1)
            });

            //act
            Polynomial resultOfMult = polynomial - monomial;


            //assert
            Assert.AreEqual(expected, resultOfMult);
        }


        /// <summary>
        /// A method that performs sum of the polynomials
        /// </summary>
        [TestMethod()]
        public void PolynomialTestSum()
        {
            //arrange
            Polynomial polynomial = new Polynomial(new List<Monomial>()
            {
                new Monomial(5.0,3),
                new Monomial(2.0,2),
                new Monomial(2.0,1)
            });

            Polynomial polynomialSec = new Polynomial(new List<Monomial>()
            {
                new Monomial(2.0,3),
                new Monomial(1.0,2)
            });

            Polynomial expected = new Polynomial(new List<Monomial>()
            {
                new Monomial(7.0,3),
                new Monomial(3.0,2),
                new Monomial(2.0,1)
            });

            //act
            Polynomial resultOfMult = polynomial + polynomialSec;


            //assert
            Assert.AreEqual(expected, resultOfMult);
        }

        /// <summary>
        /// A method that performs subtraction of the polynomials
        /// </summary>
        [TestMethod()]
        public void PolynomialTestSub()
        {
            //arrange
            Polynomial polynomial = new Polynomial(new List<Monomial>()
            {
                new Monomial(5.0,3),
                new Monomial(2.0,2),
                new Monomial(2.0,1)
            });

            Polynomial polynomialSec = new Polynomial(new List<Monomial>()
            {
                new Monomial(2.0,3),
                new Monomial(1.0,2)
            });

            Polynomial expected = new Polynomial(new List<Monomial>()
            {
                new Monomial(3.0,3),
                new Monomial(1.0,2),
                new Monomial(2.0,1)
            });

            //act
            Polynomial resultOfMult = polynomial - polynomialSec;


            //assert
            Assert.AreEqual(expected, resultOfMult);
        }


        /// <summary>
        /// A method that performs multiplication of a polynomial and a monomial
        /// </summary>
        [TestMethod()]
        public void PolynomialTestMulOnMonomial()
        {
            //arrange
            Polynomial polynomial = new Polynomial(new List<Monomial>()
            {
                new Monomial(5.0,3),
                new Monomial(2.0,2),
                new Monomial(2.0,1)
            });

            Monomial mono = new Monomial(2.0, 2.0);


            Polynomial expected = new Polynomial(new List<Monomial>()
            {
                new Monomial(10.0,5),
                new Monomial(4.0,4),
                new Monomial(4.0,3)
            });

            //act
            Polynomial resultOfMult = polynomial * mono;


            //assert
            Assert.AreEqual(expected, resultOfMult);
        }

        /// <summary>
        /// A method that performs sum of a polynomial and a number
        /// </summary>
        [TestMethod()]
        public void PolynomialTestMulOnNumber()
        {
            //arrange
            Polynomial polynomial = new Polynomial(new List<Monomial>()
            {
                new Monomial(5.0,3),
                new Monomial(2.0,2),
                new Monomial(2.0,1)
            });

            double number = 5.0;

            Polynomial expected = new Polynomial(new List<Monomial>()
            {
                new Monomial(25.0,3),
                new Monomial(10.0,2),
                new Monomial(10.0,1)
            });

            //act
            Polynomial resultOfMult = polynomial * number;


            //assert
            Assert.AreEqual(expected, resultOfMult);
        }

        /// <summary>
        /// A method that performs division of a polynomial and a number
        /// </summary>
        [TestMethod()]
        public void PolynomialTestDivOnNumber()
        {
            //arrange
            Polynomial polynomial = new Polynomial(new List<Monomial>()
            {
                new Monomial(5.0,3),
                new Monomial(2.0,2),
                new Monomial(2.0,1)
            });

            double number = 5.0;

            Polynomial expected = new Polynomial(new List<Monomial>()
            {
                new Monomial(1.0,3),
                new Monomial(0.4,2),
                new Monomial(0.4,1)
            });

            //act
            Polynomial resultOfMult = polynomial / number;


            //assert
            Assert.AreEqual(expected, resultOfMult);
        }

        /// <summary>
        /// A method that performs multiplication of the polynomials
        /// </summary>
        [TestMethod()]
        public void PolynomialTestMulOnPolinomial()
        {
            //arrange
            Polynomial polynomial = new Polynomial(new List<Monomial>()
            {
                new Monomial(5.0,3),
                new Monomial(2.0,2),
                new Monomial(2.0,1)
            });

            Polynomial polynomialSec = new Polynomial(new List<Monomial>()
            {
                new Monomial(2.0,3),
                new Monomial(1.0,2)
            });


            Polynomial expected = new Polynomial(new List<Monomial>()
            {
                new Monomial(10.0,6),
                new Monomial(9.0,5),
                new Monomial(6.0,4),
                new Monomial(2.0,3)
            });

            //act
            Polynomial resultOfMult = polynomial * polynomialSec;


            //assert
            Assert.AreEqual(expected, resultOfMult);
        }


        /// <summary>
        /// A method that performs comparision of the polynomials
        /// </summary>
        [TestMethod()]
        public void PolynomialTestEquals()
        {
            //arrange
            Polynomial polynomial = new Polynomial(new List<Monomial>()
            {
                new Monomial(5.0,3),
                new Monomial(2.0,2),
                new Monomial(2.0,1)
            });

            Polynomial polynomialSec = new Polynomial(new List<Monomial>()
            {
                new Monomial(2.0,2),
                new Monomial(5.0,3),
                new Monomial(2.0,1)
            });

            bool expected = true;

         
            //act
            bool boolValue = polynomial.Equals(polynomialSec);


            //assert
            Assert.AreEqual(expected, boolValue);
        }


    }
}