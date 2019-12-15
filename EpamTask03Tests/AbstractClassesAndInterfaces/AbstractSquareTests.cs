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
    public class AbstractSquareTests
    {
        /// <summary>
        /// Test Method For AbstractSquare.GetPerimeter()
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [DataTestMethod()]
        [DataRow(5,20)]
        [DataRow(10,40)]
        [DataRow(8,32)]
        public void TestForPerimeter(double side,double expected)
        {
            //arrange
            AbstractSquare square = new FilmSquare(side);

            //act
            double result = square.GetPerimeter();


            //assert
            Assert.AreEqual(Math.Round(expected), Math.Round(result));
        }

        /// <summary>
        /// Test Method For AbstractSquare.GetSquare()
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [DataTestMethod()]
        [DataRow(5, 25)]
        [DataRow(10, 100)]
        [DataRow(8, 64)]
        public void TestForSquare(double side, double expected)
        {
            //arrange
            AbstractSquare square = new FilmSquare(side);

            //act
            double result = square.GetSquare();


            //assert
            Assert.AreEqual(Math.Round(expected), Math.Round(result));
        }


    }
}