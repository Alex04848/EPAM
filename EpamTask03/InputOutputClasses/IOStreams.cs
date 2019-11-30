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


namespace EpamTask03.InputOutputClasses
{
    public static class IOStreams
    {

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


    }
}
