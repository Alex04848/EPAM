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
    /// <summary>
    /// The class IOml performs 
    /// Input of data in XML file and Output data from XML File To List 
    /// </summary>
    public static class IOXml
    {
        /// <summary>
        /// The Method Performs input of Data in XML File
        /// </summary>
        /// <param name="box"></param>
        /// <param name="path"></param>
        public static void InputInXmlFile(Box box,string path)
        {
            if (!path.EndsWith(".xml"))
                throw new IOException();

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
            };

            FileStream fileStream = new FileStream(path, FileMode.Create);
            using (XmlWriter xmlWriter = XmlWriter.Create(fileStream, xmlWriterSettings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement(box.GetType().Name);


                box.Shapes.ForEach(shape =>
                {
                    xmlWriter.WriteStartElement(shape.GetType().Name);

                    xmlWriter.WriteAttributeString("Values", shape.ToString());

                    //--------------------------------------------------------

                    xmlWriter.WriteStartElement("Perimeter");

                    xmlWriter.WriteValue(shape.GetPerimeter());

                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Square");

                    xmlWriter.WriteValue(shape.GetSquare());

                    xmlWriter.WriteEndElement();

                    //--------------------------------------------------------

                    xmlWriter.WriteEndElement();

                });

                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();

               xmlWriter.Close();
               fileStream.Close();
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

            if (!path.EndsWith(".xml"))
                throw new IOException();

            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            using (XmlReader xmlReader = XmlReader.Create(fileStream))
            {
                
                while (xmlReader.Read())                
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.HasAttributes)
                        shapes.Add(ReflectionShapeParser.Parse(xmlReader.GetAttribute("Values")));

                
                xmlReader.Close();
                fileStream.Close();
            }



            return shapes;
        }

    }
}
