using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.ClassesOfShapes;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;
using EpamTask03.InputOutputClasses;
using EpamTask03.HelpClasses;

namespace EpamTask03
{
    class Program
    {
        static Box box = new Box(new List<AbstractShape>() {
            new FilmRectangle(8.0,5.0),
            new FilmParallelogram(4.0,7.0),
            new PaperCircle(2.5,"Green"),
            new FilmSquare(5.0),
            new PaperSquare(4.0,ConsoleColor.Cyan),
            new FilmIsoscelesTriangle(2.0, 3.0),
            new FilmCircle(5.0),
            new FilmRhombus(2.5),
            new PaperSquare(5.5,ConsoleColor.DarkMagenta),
            new PaperTriangle(2.0,3.0,4.0,"Magenta")
        });

        static int indexForView = 5;

        static int indexForGet = 4;

        static int indexForChange = 3;

        static string firstPath = @"..\..\..\AllShapes.xml";

        static string secondPath = @"..\..\..\AllShapesSecondFile.xml";


        static void Main(string[] args)
        {
            //Test value for method AddShape of Box class, 
            //there are no shapes of equal Types, because the method controls all inputed data
            box.AddShape(new FilmTriangle(2.0, 3.0, 4.0));

            //View For All Shapes
           // box.Shapes.ForEach(shape => shape.Display());

            //View For Index
            Console.WriteLine($"box[{indexForView}] = {box[indexForView]}");

            //Get by index, after this action the shape will be deleted from the box
            Console.WriteLine($"box[{indexForGet}] = {box.GetByIndex(indexForGet)}");

            //The method will delete current shape and add another instead current shape
            box.ChangeByIndex(indexForChange, new PaperParallelogram(4.0, 7.0));

            AbstractShape forSearch = new PaperParallelogram(4.0, 7.0);

            //The method searching for equal shape and will return true if the box contains the shape,
            //in other case method will return false
            Console.WriteLine($"Contains({forSearch}) = {box.ContainsShape(forSearch)}");

            //Current Count of all shapes
            Console.WriteLine($"AllShapes:\t{box.CurrentCount}\n");

            //Sum of Squares
            Console.WriteLine($"Summary Square: {box.SumOfSquares()}\n");

            //Sum of Perimeters
            Console.WriteLine($"Summary Perimeter: {box.SumOfPerimeters()}\n");

            Console.WriteLine("\nAll Circles:\n");

            //All Circles
            box.AllCircles().ForEach(circle => {
                circle.Display();
                Console.WriteLine();
            });

            Console.WriteLine("\nAll FilmShapes:\n");

            //All FilmShapes
            box.AllFilmShapes().ForEach(filmShape => {
                filmShape.Display();
                Console.WriteLine();
            });

            //Write All Shapes to XML File
            box.AllShapesToXmlFile(firstPath);

            //Write All Shapes to Another XML File
            box.AllShapesToXmlFileByStream(secondPath);

            //new box for load shapes
            Box newBoxForLoad = new Box();

            //Load shapes from first file by XMLReader
            newBoxForLoad.LoadShapesFromXml(firstPath);

            //Load shapes by StreamReader
            newBoxForLoad.LoadShapesFromXmlByStream(secondPath);

            //View loaded shapes
            Console.WriteLine();

            newBoxForLoad.Shapes.ForEach(shape => shape.Display());



            Console.ReadKey();
        }
    }
}
