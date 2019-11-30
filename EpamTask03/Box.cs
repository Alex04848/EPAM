using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;
using EpamTask03.ExceptionClasses;

namespace EpamTask03
{

    /*
 1.14. У коробки есть ряд функций:
     добавить фигуру, (нельзя добавить одну и ту же фигуру дважды) +
     просмотреть по номеру (при этом фигура остается в коробке) +
     извлечь по номеру (при этом фигура удаляется из коробки) +
     заменить по номеру +
     найти фигуру по образцу (эквивалентную по своим характеристикам) +
     показать наличное количество фигур +
     суммарную площадь +
     суммарный периметр +
     достать все Круги +
     достать все Пленочные фигуры +
     сохранить все фигуры / только бумажные / только плёночные из коробки в XML-файл,
    используя StreamWriter 
     сохранить все фигуры / только бумажные / только плёночные из коробки в XML-файл,
    используя XmlWriter
     загрузить все фигуры в коробку из XML-файла, используя StreamReader
     загрузить все фигуры в коробку из XML-файла, используя XmlReader      
 */


    public class Box
    {
        public List<AbstractShape> Shapes { get; private set; }

        public Box(List<AbstractShape> shapes)
        {
            Shapes = shapes;
        }

        public Box() : this(new List<AbstractShape>())
        {
        }

        public void AddShape(AbstractShape shape)
        {
            if (Shapes.Any(t => t.GetType() == shape.GetType()))
                throw new BoxException("The shape of this type already in the box!!!");
            else if (Shapes.Count == 20)
                throw new BoxException("There is not empty space in the box!!!");

            Shapes.Add(shape);
        }

        public AbstractShape ViewForIndex(int index)
        {
            if (index >= 0 && index < Shapes.Count)
                return Shapes[index];
            else
                throw new BoxException("Invalid number of shape in the box");
        }

        public AbstractShape this[int index] => (ViewForIndex(index));

        public AbstractShape GetByIndex(int index)
        {
            var shape = ViewForIndex(index);

            Shapes.RemoveAt(index);

            return shape;
        }

        public void ChangeByIndex(int index, AbstractShape shape)
        {
            var shapeForChange = GetByIndex(index);
            Shapes.Insert(index, shape);
        }

        public int CurrentCount => (Shapes.Count);

        public bool ContainsShape(AbstractShape shape)
            => (Shapes.Any(t => t.Equals(shape)));

        public AbstractShape FindByEqualShape(AbstractShape shape) 
            => (Shapes.FirstOrDefault(t => t.Equals(shape)));

        public double SumOfPerimeters() => (Shapes.Sum(shape => shape.GetPerimeter()));

        public double SumOfSquares() => (Shapes.Sum(shape => shape.GetSquare()));

        public List<AbstractCircle> AllCircles() => (Shapes
            .Where(shape => shape is AbstractCircle)
            .Select(shape => shape as AbstractCircle).ToList());


        public List<AbstractShape> AllPaperShapes() => (Shapes.Where(shape => shape is IColor).ToList());

        public List<AbstractShape> AllFilmShapes() => (Shapes.Except(AllPaperShapes()).ToList());

    }
}
