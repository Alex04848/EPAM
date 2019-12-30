using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EpamTask05.ClassesOfDataStructure;

namespace EpamTask05.Tests
{
    [TestClass()]
    public class TreeSerializerTests
    {
        /// <summary>
        /// The path for xml File.
        /// </summary>
        static string path = @"..\..\SerializationTreeTest.xml";

        /// <summary>
        /// The Method which performs serialization
        /// </summary>
        /// <param name="arr"></param>
        [DataTestMethod()]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 23,2,5, 7, 99, 104 })]
        public void TreeSerializationTest(params int[] arr)
        {
            //arrange
            Tree<Int32> tree = new Tree<int>(arr.First());

            //act
            arr.Skip(1).ToList().ForEach(value => tree.AddNode(value));
            tree.View(new TreeSerializer<Int32>(path));

            //assert
            Assert.IsTrue(File.Exists(path));
        }

        /// <summary>
        /// The Method which performs deserialization
        /// </summary>
        /// <param name="arr"></param>
        [DataTestMethod()]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 23, 2, 5, 7, 99, 104 })]
        public void TreeDeserializationTest(params int[] arr)
        {
            //assert
            Tree<Int32> tree = (new TreeSerializer<Int32>()).DeserializeFromXmlFile(path);

            //act
            bool result = true;
            arr.ToList().ForEach(value =>
            {
                result = result && tree.Contains(value);
            });


            //assert
            Assert.IsTrue(result);
        }

    }
}