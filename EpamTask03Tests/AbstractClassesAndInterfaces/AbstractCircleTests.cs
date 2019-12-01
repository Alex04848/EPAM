using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask03.AbstractClassesAndInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ClassesOfShapes;

namespace EpamTask03.AbstractClassesAndInterfaces.Tests
{
    [TestClass()]
    public class AbstractCircleTests
    {
        public TestContext TestContext { get; set; }

        [DataTestMethod()]
        [DataRow(5, 31)]
        [DataRow(2, 13)]
        [DataRow(8,50)]
        public void TestForPerimeter(double value,double result)
        {
            //arrange
            AbstractCircle abstractCircle = new FilmCircle(value);
            double expected = result;

            //act
            double outValue = Math.Round(abstractCircle.GetPerimeter());


            //assert
            Assert.AreEqual(expected, outValue);
        }

        [DataTestMethod()]
        [DataRow(5, 79)]
        [DataRow(2, 13)]
        [DataRow(8, 201)]
        public void TestForSquare(double value,double result)
        {
            //arrange
            AbstractCircle abstractCircle = new FilmCircle(value);
            double expected = result;

            //act
            double outValue = Math.Round(abstractCircle.GetSquare());


            //assert
            Assert.AreEqual(expected, outValue);
        }



    }
}