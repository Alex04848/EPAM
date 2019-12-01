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
        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void MonomialTestMultOnNum()
        {
            //arrange 
            Monomial monomial = new Monomial(4.0,2);
            double number = 5.0;
            Monomial expected = new Monomial(20.0, 2);

            //act
            Monomial result = monomial * number;

            //assert
            Assert.AreEqual(expected,result);
        }

        [TestMethod()]
        public void MonomialTestDivOnNum()
        {
            //arrange 
            Monomial monomial = new Monomial(4.0, 2);
            double number = 5.0;
            Monomial expected = new Monomial(0.8, 2);

            //act
            Monomial result = monomial / number;

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void MonomialTestMultOnMonomial()
        {
            //arrange 
            Monomial mFirst = new Monomial(4.0, 2), mSec = new Monomial(2.0,2);
            Monomial expected = new Monomial(8.0, 4);

            //act
            Monomial result = mFirst * mSec;

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void MonomialTestEquals()
        {
            //arrange 
            Monomial mFirst = new Monomial(4.0, 2), mSec = (mFirst.Clone() as Monomial);
            bool expected = true;

            //act
            bool resultBoolValue = mFirst.Equals(mSec);

            //assert
            Assert.AreEqual(expected, resultBoolValue);
        }

        [TestMethod()]
        public void MonomialTestDivOnMonomial()
        {
            //arrange 
            Monomial mFirst = new Monomial(4.0, 2), mSec = new Monomial(2.0, 2);
            Monomial expected = new Monomial(2.0,0);

            //act
            Monomial result = mFirst / mSec;

            //assert
            Assert.AreEqual(expected, result);
        }

    }
}