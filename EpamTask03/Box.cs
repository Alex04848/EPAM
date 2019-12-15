using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;
using EpamTask03.InputOutputClasses;

namespace EpamTask03
{
    /// <summary>
    /// The box class
    /// </summary>
    public class Box
    {
        /// <summary>
        /// List with shapes
        /// </summary>
        public List<AbstractShape> Shapes { get; private set; }


        /// <summary>
        /// Constructor which has a one parameter.
        /// This parameter is IEnumerable interface because
        ///  'Module of higher level should not be addicted from module of lower level. 
        ///     They should be addicted from abstraction'
        ///     
        /// It's Dependency Inversion Principle.
        /// </summary>
        /// <param name="shapes"></param>
        public Box(IEnumerable<AbstractShape> shapes)
        {
            Shapes = shapes.ToList();
        }

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public Box() : this(new List<AbstractShape>())
        {
        }

        /// <summary>
        /// Method for adding a shape.
        /// </summary>
        /// <param name="shape"></param>
        public void AddShape(AbstractShape shape)
        {
            if (Shapes.Any(t => t.GetType() == shape.GetType()))
                throw new BoxException("The shape of this type already in the box!!!");
            else if (Shapes.Count == 20)
                throw new BoxException("There is not empty space in the box!!!");

            Shapes.Add(shape);
        }

        /// <summary>
        /// Method for viewing a shape
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public AbstractShape ViewForIndex(int index)
        {
            if (index >= 0 && index < Shapes.Count)
                return Shapes[index];
            else
                throw new BoxException("Invalid number of shape in the box");
        }

        /// <summary>
        /// Indexator that just uses ViewForIndex Method
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public AbstractShape this[int index] => (ViewForIndex(index));

        /// <summary>
        /// Method get by index returns AbstractShape and delete this shape from list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public AbstractShape GetByIndex(int index)
        {
            var shape = ViewForIndex(index);

            Shapes.RemoveAt(index);

            return shape;
        }

        /// <summary>
        /// This method swaps current shape by index into a new shape
        /// </summary>
        /// <param name="index"></param>
        /// <param name="shape"></param>
        public void ChangeByIndex(int index, AbstractShape shape)
        {
            var shapeForChange = GetByIndex(index);
            Shapes.Insert(index, shape);
        }

        /// <summary>
        /// The count of all shapes
        /// </summary>
        public int CurrentCount => (Shapes.Count);

        /// <summary>
        /// If Any shape equals with a parameter's shape then method returns true,
        /// in other case method returns false
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public bool ContainsShape(AbstractShape shape)
            => (Shapes.Any(t => t.Equals(shape)));
        
        /// <summary>
        /// Method will find and return equal shape or return default value
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public AbstractShape FindByEqualShape(AbstractShape shape) 
            => (Shapes.FirstOrDefault(t => t.Equals(shape)));

        /// <summary>
        /// Sum of Perimeters
        /// </summary>
        /// <returns></returns>
        public double SumOfPerimeters() => (Shapes.Sum(shape => shape.GetPerimeter()));

        /// <summary>
        /// Sum of Squares
        /// </summary>
        /// <returns></returns>
        public double SumOfSquares() => (Shapes.Sum(shape => shape.GetSquare()));

        /// <summary>
        /// Method gets all circle shapes
        /// </summary>
        /// <returns></returns>
        public List<AbstractCircle> AllCircles() => (Shapes
            .Where(shape => shape is AbstractCircle)
            .Select(shape => shape as AbstractCircle).ToList());

        /// <summary>
        /// Method gets all paper shapes
        /// </summary>
        /// <returns></returns>
        public List<AbstractShape> AllPaperShapes() => (Shapes.Where(shape => shape is IColor).ToList());

        /// <summary>
        /// Method gets all film shapes
        /// </summary>
        /// <returns></returns>
        public List<AbstractShape> AllFilmShapes() => (Shapes.Except(AllPaperShapes()).ToList());

        /// <summary>
        /// Method Writes all shapes to XML file
        /// </summary>
        /// <param name="path"></param>
        public void AllShapesToXmlFile(string path)
        {
            IOXml.InputInXmlFile(this, path);
        }

        /// <summary>
        /// Method Writes all shapes to XML file by StreamWriter
        /// </summary>
        /// <param name="path"></param>
        public void AllShapesToXmlFileByStream(string path)
        {
            IOStreams.InputInXmlFile(this, path);
        }

        /// <summary>
        /// Method Writes paper shapes to XML file
        /// </summary>
        /// <param name="path"></param>
        public void PaperShapesToXmlFile(string path)
        {
            IOXml.InputInXmlFile((new Box(AllPaperShapes())), path);
        }

        /// <summary>
        /// Method Writes film shapes to XML file
        /// </summary>
        /// <param name="path"></param>
        public void FilmShapesToXmlFile(string path)
        {
            IOXml.InputInXmlFile((new Box(AllFilmShapes())), path);
        }

        /// <summary>
        /// Method Writes paper shapes to XML file by StreamWriter
        /// </summary>
        /// <param name="path"></param>
        public void PaperShapesToXmlFileByStream(string path)
        {
            IOStreams.InputInXmlFile((new Box(AllPaperShapes())), path);
        }

        /// <summary>
        /// Method Writes film shapes to XML file by StreamWriter
        /// </summary>
        /// <param name="path"></param>
        public void FilmShapesToXmlFileByStream(string path)
        {
            IOStreams.InputInXmlFile((new Box(AllFilmShapes())), path);
        }

        /// <summary>
        /// Method loads all shapes from XML file
        /// </summary>
        /// <param name="path"></param>
        public void LoadShapesFromXml(string path)
        {
            Shapes = IOXml.OutputInList(path);
        }

        /// <summary>
        /// Method loads all shapes from XML file by StreamReader
        /// </summary>
        /// <param name="path"></param>
        public void LoadShapesFromXmlByStream(string path)
        {
            Shapes = IOStreams.OutputInList(path);
        }

    }
}
