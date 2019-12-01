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
    public class MonomialTests
    {
        public TestContext TestContext { get; set; }

        /// <summary>
        /// A method that performs multiplication of a monomial on a number
        /// </summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"..\..\testData.xml", "MonomialTestMultOnNum",DataAccessMethod.Sequential)]
        [TestMethod()]
        public void MonomialTestMultOnNum()
        {
            //arrange 
            double coeff = Convert.ToDouble(TestContext.DataRow["coeff"]);
            double degree = Convert.ToDouble(TestContext.DataRow["degree"]);
            double num = Convert.ToDouble(TestContext.DataRow["num"]);
            double resCoeff = Convert.ToDouble(TestContext.DataRow["resCoeff"]);

            Monomial monomial = new Monomial(coeff, degree);
            double number = num;
            Monomial expected = new Monomial(resCoeff, degree);

            //act
            Monomial result = monomial * number;

            //assert
            Assert.AreEqual(expected,result);
        }

        /// <summary>
        /// A method that performs division of a monomial on a number
        /// </summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"..\..\testData.xml", "MonomialTestDivOnNum", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void MonomialTestDivOnNum()
        {
            //arrange 
            double coeff = Convert.ToDouble(TestContext.DataRow["coeff"]);
            double degree = Convert.ToDouble(TestContext.DataRow["degree"]);
            double num = Convert.ToDouble(TestContext.DataRow["num"]);
            double resCoeff = Convert.ToDouble(TestContext.DataRow["resCoeff"]);

            Monomial monomial = new Monomial(coeff, degree);
            double number = num;
            Monomial expected = new Monomial(resCoeff, degree);

            //act
            Monomial result = monomial / number;

            //assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// A method that performs multiplication of the monomials
        /// </summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"..\..\testData.xml", "MonomialTestMultOnMonomial", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void MonomialTestMultOnMonomial()
        {
            //arrange 
            double coeffFirst = Convert.ToDouble(TestContext.DataRow["coeffFirst"]);
            double degreeFirst = Convert.ToDouble(TestContext.DataRow["degreeFirst"]);
            double coeffSec = Convert.ToDouble(TestContext.DataRow["coeffSec"]);
            double degreeSec = Convert.ToDouble(TestContext.DataRow["degreeSec"]);
            double resCoeff = Convert.ToDouble(TestContext.DataRow["resCoeff"]);
            double resDegree = Convert.ToDouble(TestContext.DataRow["resDegree"]);

            Monomial mFirst = new Monomial(coeffFirst, degreeFirst), mSec = new Monomial(coeffSec,degreeSec);
            Monomial expected = new Monomial(resCoeff, resDegree);

            //act
            Monomial result = mFirst * mSec;

            //assert
            Assert.AreEqual(expected, result);
        }


        /// <summary>
        /// A method that performs comparision of the monomials
        /// </summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"..\..\testData.xml", "MonomialTestEquals", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void MonomialTestEquals()
        {
            //arrange 
            double coeffFirst = Convert.ToDouble(TestContext.DataRow["coeffFirst"]);
            double degreeFirst = Convert.ToDouble(TestContext.DataRow["degreeFirst"]);
            double coeffSec = Convert.ToDouble(TestContext.DataRow["coeffSec"]);
            double degreeSec = Convert.ToDouble(TestContext.DataRow["degreeSec"]);
            bool resBool = Convert.ToBoolean(TestContext.DataRow["resBool"]);


            Monomial mFirst = new Monomial(coeffFirst, degreeFirst), mSec = new Monomial(coeffSec, degreeSec);
            bool expected = resBool;

            //act
            bool resultBoolValue = mFirst.Equals(mSec);

            //assert
            Assert.AreEqual(expected, resultBoolValue);
        }

        /// <summary>
        /// A method that performs division of the monomials
        /// </summary>
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"..\..\testData.xml", "MonomialTestDivOnMonomial", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void MonomialTestDivOnMonomial()
        {
            //arrange 
            double coeffFirst = Convert.ToDouble(TestContext.DataRow["coeffFirst"]);
            double degreeFirst = Convert.ToDouble(TestContext.DataRow["degreeFirst"]);
            double coeffSec = Convert.ToDouble(TestContext.DataRow["coeffSec"]);
            double degreeSec = Convert.ToDouble(TestContext.DataRow["degreeSec"]);
            double resCoeff = Convert.ToDouble(TestContext.DataRow["resCoeff"]);
            double resDegree = Convert.ToDouble(TestContext.DataRow["resDegree"]);

            Monomial mFirst = new Monomial(coeffFirst, degreeFirst), mSec = new Monomial(coeffSec, degreeSec);
            Monomial expected = new Monomial(resCoeff, resDegree);

            //act
            Monomial result = mFirst / mSec;

            //assert
            Assert.AreEqual(expected, result);
        }

    }
}