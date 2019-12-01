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
    public class AbstractTriangleTests
    {
        [DataTestMethod()]
        [DataRow(2,3,4,9)]
        [DataRow(5,4,3,12)]
        [DataRow(12,15,18,45)]
        public void TestForPerimeter(double sideA,double sideB,double sideC,double result)
        {
            //arrange 
            AbstractTriangle triangle = new FilmTriangle(sideA,sideB,sideC);
            double expected = result;

            //act
            double outValue = triangle.GetPerimeter();

            //assert
            Assert.AreEqual(expected, outValue);
        }

        [DataTestMethod()]
        [DataRow(2, 3, 4, 3)]
        [DataRow(5, 4, 3, 6)]
        [DataRow(12, 15, 18, 89)]
        public void TestForSquare(double sideA, double sideB, double sideC, double result)
        {
            //arrange 
            AbstractTriangle triangle = new FilmTriangle(sideA, sideB, sideC);
            double expected = result;

            //act
            double outValue = Math.Round(triangle.GetSquare());

            //assert
            Assert.AreEqual(expected, outValue);
        }

    }
}