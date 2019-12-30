using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using EpamTask05.ClassesOfDataStructure;

namespace EpamTask05
{
    /// <summary>
    /// The Tree Serializer which implements ITreePrinter and perform serialize of Binary Tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeSerializer<T> : ITreePrinter<T> where T : new()
    { 
        /// <summary>
        /// The path for Serialize
        /// </summary>
        public readonly string Path;

        public TreeSerializer(string path)
        {
            this.Path = path;
        }

        public TreeSerializer() : this(@"..\..\treeInXml.xml")
        {
        }

        /// <summary>
        /// The method of an interface
        /// </summary>
        /// <param name="tree"></param>
        public void PrintTree(Tree<T> tree)
               => SerializeToXmlFile(tree);

        /// <summary>
        /// Serialize method
        /// </summary>
        /// <param name="tree"></param>
        public void SerializeToXmlFile(Tree<T> tree) 
        {
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Tree<T>));
                xmlSerializer.Serialize(fs, tree);
            }
        }

        /// <summary>
        /// Deserialize method
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Tree<T> DeserializeFromXmlFile(string path)
        {
            Tree<T> tree;

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Tree<T>));        
                tree = xmlSerializer.Deserialize(fs) as Tree<T>;
            }

            return tree;
        }

    }
}
