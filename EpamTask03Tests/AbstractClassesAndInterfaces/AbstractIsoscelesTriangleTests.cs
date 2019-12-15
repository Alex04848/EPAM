using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask03.AbstractClassesAndInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ClassesOfShapes;
using System.Diagnostics;

namespace EpamTask03.AbstractClassesAndInterfaces.Tests
{
    [TestClass()]
    public class AbstractIsoscelesTriangleTests
    {
        /// <summary>
        /// Test Method For AbstractIsoscelesTriangle.GetPerimeter()
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [DataTestMethod()]
        [DataRow(5, 8, 18)]
        [DataRow(4, 7, 15)]
        [DataRow(5, 3, 13)]
        public void TestForPerimeter(double sideA,double sideB, double result)
        {
            //arrange
            AbstractIsoscelesTriangle abstractTriangle = new FilmIsoscelesTriangle(sideA, sideB);
            double expected = result;

            //act
            double outValue = Math.Round(abstractTriangle.GetPerimeter());


            //assert
            Assert.AreEqual(expected, outValue);
        }


        /// <summary>
        /// Test Method For AbstractIsoscelesTriangle.GetSquare()
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [DataTestMethod()]
        [DataRow(15, 5, 37)]
        [DataRow(5, 8, 12)]
        [DataRow(10, 15,50)]
        public void TestForSquare(double sideA, double sideB, double result)
        {
            //arrange
            AbstractIsoscelesTriangle abstractTriangle = new FilmIsoscelesTriangle(sideA, sideB);
            double expected = result;

            //act
            double outValue = Math.Round(abstractTriangle.GetSquare());


            //assert
            Assert.AreEqual(expected, outValue);
        }


    }
}