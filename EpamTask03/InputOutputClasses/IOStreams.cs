using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ClassesOfShapes;
using EpamTask03.ExceptionClasses;
using EpamTask03.HelpClasses;
using System.Text.RegularExpressions;

namespace EpamTask03.InputOutputClasses
{
    /// <summary>
    /// The class IOStreams performs 
    /// Input of data in XML file and Output data from XML File To List 
    /// </summary>
    public static class IOStreams
    {
        /// <summary>
        /// The Method Performs input of Data in XML File
        /// </summary>
        /// <param name="box"></param>
        /// <param name="path"></param>
        public static void InputInXmlFile(Box box,string path)
        {
            if (!path.EndsWith(".xml"))
                throw new IOException("Incorrect file!!!");

            using(StreamWriter stream = new StreamWriter(path))
            {
                stream.WriteLine($"<Box>");

                box.Shapes.ForEach(shape =>
                {
                    stream.WriteLine($"\t<{shape.GetType().Name} Values=\"{shape.ToString()}\">");

                    stream.WriteLine($"\t\t<Perimeter>{shape.GetPerimeter()}</Perimeter>");
                    stream.WriteLine($"\t\t<Square>{shape.GetSquare()}</Square>");

                    stream.WriteLine($"\t</{shape.GetType().Name}>");

                });

                stream.Write($"</Box>");

                stream.Close();
            }


        }

        /// <summary>
        /// The Method Performs output of Data in List
        /// </summary>
        /// <param name="box"></param>
        /// <param name="path"></param>
        public static List<AbstractShape> OutputInList(string path)
        {
            List<AbstractShape> shapes = new List<AbstractShape>();
            Regex regex = new Regex($"(([\\w|,]+);)+\\w+");

            if (!path.EndsWith(".xml"))
                throw new IOException("Incorrect file!!!");


            using(StreamReader stream = new StreamReader(path))
            {

                while (!stream.EndOfStream)
                {
                    string currentValue = stream.ReadLine();
                    if (regex.IsMatch(currentValue) && currentValue.Contains("Values"))
                        shapes.Add(ReflectionShapeParser.Parse(regex.Match(currentValue).Value));

                }

            }


            return shapes;
        }

    }
}
