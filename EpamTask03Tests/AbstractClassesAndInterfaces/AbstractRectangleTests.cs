using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask03.Tests
{
    [TestClass()]
    public class AbstractRectangleTests
    {

        [DataTestMethod()]
        [DataRow(2,4,12)]
        [DataRow(5,5,20)]
        [DataRow(7,8,30)]
        public void TestForPerimeter(double width,double height,double result)
        {
            //arrange
            AbstractRectangle rect = new FilmRectangle(width, height);
            double expected = result;

            //act
            double outValue = rect.GetPerimeter();

            //assert
            Assert.AreEqual(expected, outValue);
        }


        [DataTestMethod()]
        [DataRow(2, 4, 8)]
        [DataRow(5, 5, 25)]
        [DataRow(7, 8, 56)]
        public void TestForSquare(double width, double height, double result)
        {
            //arrange
            AbstractRectangle rect = new FilmRectangle(width,height);
            double expected = result;

            //act
            double outValue = Math.Round(rect.GetSquare());

            //assert
            Assert.AreEqual(expected, outValue);
        }


    }
}