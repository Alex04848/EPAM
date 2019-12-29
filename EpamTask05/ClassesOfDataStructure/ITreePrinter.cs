using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05
{
    /// <summary>
    /// The Interface which contains method for printing a tree.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITreePrinter<T> where T : new()
    {
        /// <summary>
        /// Print tree method
        /// </summary>
        /// <param name="root"></param>
        void PrintTree(Tree<T> root);
    }
}
