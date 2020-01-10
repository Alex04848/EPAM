using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask05.ExceptionClasses;
using EpamTask05.ClassesOfDataStructure;
using EpamTask05.GradeOfTestClasses;
using System.IO;

namespace EpamTask05.Tests
{
    [TestClass()]
    public class TreeTests
    {

        /// <summary>
        /// The Method which checks creating of a tree
        /// </summary>
        /// <param name="arr"></param>
        [DataTestMethod()]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 23  })]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 23 })]
        [DataRow(new int[] { 50, 60, 25, 2, 5, 7, 99 })]
        public void CreateTreeValidTest(params int[] arr)
        {
            //arrange
            Tree<Int32> tree = new Tree<int>(arr.First());


            //act
            arr.Skip(1).ToList().ForEach(value => tree.AddNode(value));

            //result
            Assert.IsTrue(tree != null);
        }

        /// <summary>
        /// The Method which checks exception during creating of a tree
        /// </summary>
        /// <param name="arr"></param>
        [DataTestMethod()]
        [DataRow(new int[] { 50, 30, 75, 50, 94, 87, 55 })]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 24 })]
        [DataRow(new int[] { 50, 60, 25, 2, 2, 60, 99 })]
        public void CreateTreeInvalidTest(params int[] arr)
        {
            //arrange
            Tree<Int32> tree = new Tree<int>(arr.First());


            //result
            Assert.ThrowsException<TreeException>(() =>
            {
                arr.Skip(1).ToList().ForEach(value => tree.AddNode(value));
            });
        }


        /// <summary>
        /// The Method which searching for node in a tree
        /// </summary>
        /// <param name="arr"></param>
        [DataTestMethod()]
        [DataRow(46, new int[] { 50, 24, 46, 79, 58, 32, 23 })]
        [DataRow(23, new int[] { 50, 24, 46, 79, 58, 32, 23 })]
        [DataRow(25, new int[] { 50, 60, 25, 2, 5, 7, 99 })]
        public void FindNodeTreeTest(int nodeForSearch, params int[] arr)
        {
            //arrange
            Tree<Int32> tree = new Tree<int>(arr.First());


            //act
            arr.Skip(1).ToList().ForEach(value => tree.AddNode(value));
            var node = tree.FindNode(nodeForSearch);


            //result
            Assert.IsNotNull(node);
        }


        /// <summary>
        /// The Method which deletes a node in a tree
        /// </summary>
        /// <param name="arr"></param>
        [DataTestMethod()]
        [DataRow(79, new int[] { 50, 24, 46, 79, 58, 32, 99 })]
        [DataRow(24, new int[] { 50, 24, 46, 79, 58, 32, 23 })]
        [DataRow(2, new int[] { 50, 60, 25, 2, 5, 7, 99 })]
        public void TreeDeleteNodesTest(int elementForDelete,params int[] arr)
        {
            //arrange 
            Tree<Int32> tree = new Tree<int>(arr.First());

            //act
            arr.Skip(1).ToList().ForEach(value => tree.AddNode(value));
            tree.DeleteNode(elementForDelete);


            //assert
            Assert.IsFalse(tree.Contains(elementForDelete));
        }

        /// <summary>
        /// The Method which checks contains method of a tree class
        /// </summary>
        /// <param name="arr"></param>
        [DataTestMethod()]
        [DataRow(105, new int[] { 50, 24, 46, 79, 58, 32, 99 })]
        [DataRow(58, new int[] { 50, 24, 46, 79, 58, 32, 23 })]
        [DataRow(100, new int[] { 50, 60, 25, 2, 5, 7, 100 })]
        public void TreeContainsTest(int element,params int[] arr)
        {
            //arrange 
            Tree<Int32> tree = new Tree<int>(arr.First());

            //act
            arr.Skip(1).ToList().ForEach(value => tree.AddNode(value));
            bool result = tree.Contains(element);


            //assert
            Assert.IsTrue(result == arr.Contains(element));
        }


        /// <summary>
        /// The method which searching for Max Node in a tree
        /// </summary>
        /// <param name="arr"></param>
        [DataTestMethod()]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 99 })]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 23 })]
        [DataRow(new int[] { 50, 60, 25, 2, 5, 7, 100 })]
        public void TreeGetMaxNodeTest(params int[] arr)
        {
            //arrange 
            Tree<Int32> tree = new Tree<int>(arr.First());

            //act
            arr.Skip(1).ToList().ForEach(value => tree.AddNode(value));
            int result = tree.GetMaxNode().Value;


            //assert
            Assert.IsTrue(result == arr.Max());
        }

        /// <summary>
        /// The method which searching for Min Node in a tree
        /// </summary>
        /// <param name="arr"></param>
        [DataTestMethod()]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 99 })]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 23 })]
        [DataRow(new int[] { 50, 60, 25, 2, 5, 7, 100 })]
        public void TreeGetMinNodeTest(params int[] arr)
        {
            //arrange 
            Tree<Int32> tree = new Tree<int>(arr.First());

            //act
            arr.Skip(1).ToList().ForEach(value => tree.AddNode(value));
            int result = tree.GetMinNode().Value;


            //assert
            Assert.IsTrue(result == arr.Min());
        }

        /// <summary>
        /// Test for Tree With Grades
        /// </summary>
        [DataTestMethod()]
        public void TreeWithGradesTest()
        {
            //arrange
            List<GradeOfTest> gradesOfTests = new List<GradeOfTest>()
            {
                new MathTest("Alex",8,new DateTime(2019,12,24)),
                new RussianLanguageTest("Paul",6,new DateTime(2019,12,4)),
                new PhysicsTest("Lesha",7 ,new DateTime(2019,12,4)),
                new EnglishLanguageTest("Paul",10,new DateTime(2019,5,19)),
                new GeographyTest("Alex",8, new DateTime(2019,12,28))
            };

            Tree<GradeOfTest> treeWithGrades = new Tree<GradeOfTest>(gradesOfTests.First());

            gradesOfTests.Skip(1).ToList().ForEach(grade => treeWithGrades.AddNode(grade));

            //act
            bool result = treeWithGrades != null && gradesOfTests.All(grade => treeWithGrades.Contains(grade));

            //assert
            Assert.IsTrue(result);
        }

    }
}