using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace EpamTask03.HelpClasses
{
    /// <summary>
    /// The shape parser which uses reflection for parse values
    /// </summary>
    public static class ReflectionShapeParser
    {
        /// <summary>
        /// Public method for parse
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static AbstractShape Parse(string pattern)
        {
            var listWithStringValues = pattern.Split(';');
         
            object[] paramsForCtor = GetParameters(listWithStringValues.Skip(1)).ToArray();
   
            object shape = CreateShape($"EpamTask03.ClassesOfShapes.{listWithStringValues.First()}", paramsForCtor);



            return (shape as AbstractShape);
        }

        /// <summary>
        /// The method which creates a shape and use for for this a constructor with parameters
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        static object CreateShape(string pattern,object[] parameters)
        {
            object shapeValue = null;

            Type typeOfShape = Type.GetType(pattern);

            var ctors = typeOfShape?.GetConstructors().Where(ctorMethod => ctorMethod.GetParameters().Length == parameters.Length).ToList();

            var ctor = FindCtor(ctors, parameters);

            shapeValue = ctor?.Invoke(parameters);



            return shapeValue;
        }

        /// <summary>
        /// The method gets collection of constructors and parameters for searching.
        /// Returns first ctor with parameters which equals with parameters from arguments.
        /// </summary>
        /// <param name="ctors"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        static ConstructorInfo FindCtor(IEnumerable<ConstructorInfo> ctors,IEnumerable<object> parameters)
        {
            ConstructorInfo ctorInf = null;

            ctors.ToList().ForEach(ctor =>
            {
                if (ctorInf == null)
                {
                    bool expressionForSearch = ctor.GetParameters().Zip(parameters, (parameterInf, param) => new { parameterInf, param })
                    .All(paramsColl => paramsColl.param.GetType() == paramsColl.parameterInf.ParameterType);

                    if (expressionForSearch)
                        ctorInf = ctor;
                }

            });

            return ctorInf;
        }

        /// <summary>
        /// The method which creates a shape and use for for this a constructor without parameters
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        static object CreateShape(string pattern)
        {
            object shapeValue = null;
            Type typeOfShape = Type.GetType(pattern);

            var ctor = typeOfShape?.GetConstructors().FirstOrDefault(ctorMethod => ctorMethod.GetParameters().Length == 0);

            shapeValue = ctor?.Invoke(new object[] { });


            return shapeValue;
        }

        /// <summary>
        /// The method which get parameters from string values
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        static IEnumerable<object> GetParameters(IEnumerable<string> values)
        {
            List<object> paramsForCtor = new List<object>();

            values.ToList().ForEach(value =>
            {
                if (value.All(symb => Char.IsDigit(symb) || symb.Equals(',')))
                    paramsForCtor.Add(Double.Parse(value));
                else
                    paramsForCtor.Add(Enum.Parse(typeof(ConsoleColor),value));
            });


            return paramsForCtor;
        }

    }
}