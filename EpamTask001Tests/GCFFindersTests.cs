using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask001.Tests
{
    [TestClass()]
    public class GCFFindersTests
    {
        [TestMethod()]
        public void EvklidAlgorithmTest()
        {
            //arrange
            int firstValue = 781, secondValue = 231;
            int expected = 11;

            //act 
            int result = GCFFinders.EvklidAlgorithm(firstValue, secondValue);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void EvklidAlgorithmTest1()
        {
            //arrange
            int firstValue = 781, secondValue = 231, thirdvalue = 451;
            int expected = 11;

            //act 
            int result = GCFFinders.EvklidAlgorithm(firstValue, secondValue,thirdvalue);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void BinaryEvklidAlgorithmTest()
        {
            //arrange
            int firstValue = 781, secondValue = 231;
            int expected = 11;

            //act 
            int result = GCFFinders.EvklidAlgorithm(firstValue, secondValue);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AlgorithmWithTheTimeTest()
        {
            //arrange
            int firstValue = 781, secondValue = 231,thirdValue = 451, fourValue = 11;
            int expected = 11;

            //act 
            int result = GCFFinders.EvklidAlgorithm(firstValue, secondValue,thirdValue,fourValue);

            //assert
            Assert.AreEqual(expected, result);
        }  
    }
}