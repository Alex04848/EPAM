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
    public class AbstractRhombusTests
    {
        /// <summary>
        /// Test Method For AbstractRhombus.GetPerimeter()
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [DataTestMethod()]
        [DataRow(4, 16)]
        [DataRow(5, 20)]
        [DataRow(8, 32)]
        public void TestForPerimeter(double side,double expected)
        {
            //arrange
            AbstractRhombus rhombus = new FilmRhombus(side);

            //act
            double result = rhombus.GetPerimeter();

            //assert
            Assert.AreEqual(Math.Round(expected), Math.Round(result));
        }


        /// <summary>
        /// Test Method For AbstractRhombus.GetSquare()
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [DataTestMethod()]
        [DataRow(4, 13.86)]
        [DataRow(5, 21.65)]
        [DataRow(8, 55.43)]
        public void TestForSquare(double side, double expected)
        {
            //arrange
            AbstractRhombus rhombus = new FilmRhombus(side);

            //act
            double result = rhombus.GetSquare();

            //assert
            Assert.AreEqual(Math.Round(expected), Math.Round(result));
        }

    }
}