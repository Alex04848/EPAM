using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask001.Tests
{
    /// <summary>
    /// Данный класс предназначен для хранения тестов для класса GCFFinders.
    /// Все тесты разделены на три блока
    /// arrange - Инициализация входных данных и ожидаемого результата
    /// act - Вызов тестируемого метода с входными данными
    /// assert - Проверка результата с помощью класса Assert
    /// </summary>
    [TestClass()]
    public class GCFFindersTests
    {
        /// <summary>
        /// Тестирование стандартного метода Евклида с двумя значениями
        /// </summary>
        [TestMethod()]
        public void EvklidAlgorithmTest()
        {
            //arrange
            int firstValue = 781, secondValue = 231;
            int expected = 11;

            //act 
            int result = GCFFinders.EvklidAlgorithm(firstValue, secondValue);

            //assert
            Assert.AreEqual(expected, result);
        }


        /// <summary>
        /// Тестирование стандартного метода Евклида с тремя значениями
        /// </summary>
        [TestMethod()]
        public void EvklidAlgorithmTestWithThreeValues()
        {
            //arrange
            int firstValue = 371, secondValue = 56, thirdvalue = 560;
            int expected = 7;

            //act 
            int result = GCFFinders.EvklidAlgorithm(firstValue, secondValue,thirdvalue);

            //assert
            Assert.AreEqual(expected, result);
        }


        /// <summary>
        /// Тестирование стандартного метода Евклида с четырьмя значениями
        /// </summary>
        [TestMethod()]
        public void EvklidAlgorithmTestWithFourValues()
        {
            //arrange
            int firstValue = 154, secondValue = 682, thirdvalue = 286, fourValue = 726;
            int expected = 22;

            //act 
            int result = GCFFinders.EvklidAlgorithm(firstValue, secondValue, thirdvalue,fourValue);

            //assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Тестирование стандартного метода Евклида с пятью значениями
        /// </summary>
        [TestMethod()]
        public void EvklidAlgorithmTestWithFiveValues()
        {
            //arrange
            int firstValue = 115, secondValue = 0, thirdvalue = 500, fourValue = 715,fiveValue = 0;
            int expected = 5;

            //act 
            int result = GCFFinders.EvklidAlgorithm(firstValue, secondValue, thirdvalue, fourValue, fiveValue);

            //assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Тестирование Бинарного метода Евклида с двумя значениями
        /// </summary>
        [TestMethod()]
        public void BinaryEvklidAlgorithmTest()
        {
            //arrange
            int firstValue = 781, secondValue = 231;
            int expected = 11;

            //act 
            int result = GCFFinders.BinaryEvklidAlgorithm(firstValue, secondValue);

            //assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Тестирование метода Евклида использующего время
        /// </summary>
        [TestMethod()]
        public void MethodWithTheTimeForEvklidAlgorithmTest()
        {
            //arrange
            int firstValue = 910, secondValue = 260;
            int expected = 130;

            //act 
            int result = GCFFinders.AlgorithmWithTheTime(GCFFinders.EvklidAlgorithm, firstValue,secondValue,out TimeSpan timeSpan);

            //assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Тестирование Бинарного метода Евклида использующего время
        /// </summary>
        [TestMethod()]
        public void MethodWithTheTimeForBinaryEvklidAlgorithmTest()
        {
            //arrange
            int firstValue = 396, secondValue = 522;
            int expected = 18;

            //act 
            int result = GCFFinders.AlgorithmWithTheTime(GCFFinders.BinaryEvklidAlgorithm, firstValue, secondValue, out TimeSpan timeSpan);

            //assert
            Assert.AreEqual(expected, result);
        }

    }
}