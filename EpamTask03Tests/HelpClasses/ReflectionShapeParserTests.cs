using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpamTask03.HelpClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ClassesOfShapes;
using System.Diagnostics;

namespace EpamTask03.HelpClasses.Tests
{
    [TestClass()]
    public class ReflectionShapeParserTests
    {        

        /// <summary>
        /// Method which tests method parse of ReflectionParser Class
        /// </summary>
        /// <param name="forParse"></param>
        /// <param name="square"></param>
        /// <param name="type"></param>
        [DataTestMethod()]
        [DataRow("FilmRectangle;2;5",10,typeof(FilmRectangle))]
        [DataRow("FilmRectangle;8;5", 40, typeof(FilmRectangle))]
        [DataRow("FilmParallelogram;4;7;29,845130209103", 14, typeof(FilmParallelogram))]
        [DataRow("PaperCircle;2,5;Green", 19.6349540849362, typeof(PaperCircle))]
        [DataRow("PaperParallelogram;4;7;29,845130209103;White", 14, typeof(PaperParallelogram))]
        [DataRow("FilmIsoscelesTriangle;2;3", 1.98431348329844, typeof(FilmIsoscelesTriangle))]
        [DataRow("FilmCircle;5", 78.5398163397448, typeof(FilmCircle))]
        [DataRow("FilmRhombus;2,5", 5.41265877365274, typeof(FilmRhombus))]
        [DataRow("PaperSquare;5,5;DarkMagenta", 30.25, typeof(PaperSquare))]
        [DataRow("PaperTriangle;2;3;4;Magenta", 2.90473750965556, typeof(PaperTriangle))]
        [DataRow("FilmTriangle;2;3;4", 2.90473750965556, typeof(FilmTriangle))]
        public void ParseTest(string forParse,double square,Type type)
        {
            //act
            AbstractShape shapeFromParser = ReflectionShapeParser.Parse(forParse);

            //assert
            Assert.IsTrue(shapeFromParser.GetType() == type && Math.Round(shapeFromParser.GetSquare()) == Math.Round(square));
        }

    }
}