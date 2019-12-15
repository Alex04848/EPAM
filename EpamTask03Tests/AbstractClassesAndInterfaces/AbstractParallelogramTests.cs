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
    public class AbstractParallelogramTests
    {

        /// <summary>
        /// Test Method For AbstractParallelogram.GetPerimeter()
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [DataTestMethod()]
        [DataRow(2,4,12)]
        [DataRow(5,4,18)]
        [DataRow(4,8,24)]
        public void TestForPerimeter(double leftAndRightSide,double bottomAndTopSide,double expected)
        {
            //arrange 
            AbstractParallelogram parallelogram = new FilmParallelogram(leftAndRightSide,bottomAndTopSide);

            //act
            double result = parallelogram.GetPerimeter();

            //assert
            Assert.AreEqual(Math.Round(expected), Math.Round(result));
        }


        /// <summary>
        /// Test Method For AbstractParallelogram.GetSquare()
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        [DataTestMethod()]
        [DataRow(2, 4, 4)]
        [DataRow(5, 4, 10)]
        [DataRow(4, 8, 16)]
        public void TestForSquare(double leftAndRightSide, double bottomAndTopSide, double expected)
        {
            //arrange 
            AbstractParallelogram parallelogram = new FilmParallelogram(leftAndRightSide, bottomAndTopSide);

            //act
            double result = parallelogram.GetSquare();

            //assert
            Assert.AreEqual(Math.Round(expected), Math.Round(result));
        }

    }
}