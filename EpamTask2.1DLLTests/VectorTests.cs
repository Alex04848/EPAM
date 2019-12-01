using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask02._1DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask02._1DLL.Tests
{
    [TestClass()]
    public class VectorTests
    {
        /// <summary>
        /// Vector's mult test
        /// </summary>
        [TestMethod()]
        public void VectorTestMult()
        {
            //arrange
            Vector vector = new Vector(1, 2, 3);
            double num = 5;
            Vector expected = new Vector(5, 10, 15);

            //act
            Vector result = (vector * num);


            //assert
            Assert.AreEqual(expected,result);
        }

        /// <summary>
        /// Vector's sum test
        /// </summary>
        [TestMethod()]
        public void VectorTestSum()
        {
            //arrange
            Vector vFirst = new Vector(1, 2, 3);
            Vector vSec = new Vector(9, 5, 12);
            Vector expected = new Vector(10, 7, 15);

            //act
            Vector result = vFirst + vSec;


            //assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Vector's sub test
        /// </summary>
        [TestMethod()]
        public void VectorTestSub()
        {
            //arrange
            Vector vFirst = new Vector(1, 2, 3);
            Vector vSec = new Vector(9, 5, 12);
            Vector expected = new Vector(-8, -3, -9);

            //act
            Vector result = vFirst - vSec;


            //assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// vector's divison test
        /// </summary>
        [TestMethod()]
        public void VectorTestDiv()
        {
            //arrange
            Vector vector = new Vector(5, 10, 15);
            double num = 5;
            Vector expected = new Vector(1, 2, 3);

            //act
            Vector result = (vector / num);


            //assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Vector's multiplication
        /// </summary>
        [TestMethod()]
        public void VectorTestMultBetweenVectors()
        {
            //arrange
            Vector vFirst = new Vector(5, 10, 15);
            Vector vSec = new Vector(2, 9, 17);
            Vector expected = new Vector(35, -55, 25);

            //act
            Vector result = (vFirst * vSec);


            //assert
            Assert.AreEqual(expected, result);
        }




    }
}