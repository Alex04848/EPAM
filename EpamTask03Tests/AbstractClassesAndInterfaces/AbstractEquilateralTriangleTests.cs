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
    public class AbstractEquilateralTriangleTests
    {
        [DataTestMethod()]
        [DataRow(5, 15)]
        [DataRow(7, 21)]
        [DataRow(15, 45)]
        public void TestForPerimeter(double value, double result)
        {
            //arrange
            AbstractEquilateralTriangle abstractTriangle = new FilmEquilateralTriangle(value);
            double expected = result;

            //act
            double outValue = abstractTriangle.GetPerimeter();


            //assert
            Assert.AreEqual(expected, outValue);
        }


        [DataTestMethod()]
        [DataRow(5, 11)]
        [DataRow(7, 21)]
        [DataRow(15, 97)]
        public void TestForSquare(double value, double result)
        {
            //arrange
            AbstractEquilateralTriangle abstractTriangle = new FilmEquilateralTriangle(value);
            double expected = result;

            //act
            double outValue = Math.Round(abstractTriangle.GetSquare());


            //assert
            Assert.AreEqual(expected, outValue);
        }


    }
}