using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ClassesOfShapes;
using EpamTask03.ExceptionClasses;


namespace EpamTask03.HelpClasses
{
    public static class ShapeParser
    {
        public static AbstractShape Parse(string values)
        {
            AbstractShape shape = null;
            List<string> valuesInList = values.Split(';').ToList();

            switch (valuesInList[0])
            {
                case "FilmCircle":
                    shape = new FilmCircle(Double.Parse(valuesInList[1]));
                    break;

                case "FilmEquilateralTriangle":
                    shape = new FilmEquilateralTriangle(Double.Parse(valuesInList[1]));
                    break;

                case "FilmIsoscelesTriangle":
                    shape = new FilmIsoscelesTriangle(Double.Parse(valuesInList[1]), Double.Parse(valuesInList[2]));
                    break;

                case "FilmRectangle":
                    shape = new FilmRectangle(Double.Parse(valuesInList[1]), Double.Parse(valuesInList[2]));
                    break;

                case "FilmTriangle":
                    shape = new FilmTriangle(Double.Parse(valuesInList[1]), Double.Parse(valuesInList[2]), Double.Parse(valuesInList[3]));
                    break;

                case "PaperCircle":
                    shape = new PaperCircle(Double.Parse(valuesInList[1]), ColorParser.Parse(valuesInList[2]));
                    break;

                case "PaperEquilateralTriangle":
                    shape = new PaperEquilateralTriangle(Double.Parse(valuesInList[1]),ColorParser.Parse(valuesInList[2]));
                    break;

                case "PaperIsoscelesTriangle":
                    shape = new PaperIsoscelesTriangle(Double.Parse(valuesInList[1]), Double.Parse(valuesInList[2]),ColorParser.Parse(valuesInList[3]));
                    break;

                case "PaperRectangle":
                    shape = new PaperRectangle(Double.Parse(valuesInList[1]), Double.Parse(valuesInList[2]),ColorParser.Parse(valuesInList[3]));
                    break;

                case "PaperTriangle":
                    shape = new PaperTriangle(Double.Parse(valuesInList[1]), Double.Parse(valuesInList[2]),
                                                Double.Parse(valuesInList[3]),ColorParser.Parse(valuesInList[3]));
                    break;

                default:
                        throw new ShapeException("The type doesn't exist");

            }


            return shape;
        }



    }
}
