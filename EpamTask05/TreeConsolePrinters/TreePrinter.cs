using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask05.ClassesOfDataStructure;

namespace EpamTask05.TreeConsolePrinters
{
    /// <summary>
    /// The class which implements ITreePrinter Interface and print tree to console 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreePrinter<T> : ITreePrinter<T> where T : new()
    {
        /// <summary>
        /// The method of an interface
        /// </summary>
        /// <param name="tree"></param>
        public void PrintTree(Tree<T> tree)  
             => PrintTree(tree.Root, 0);
        
        /// <summary>
        /// Private Print Tree Method
        /// </summary>
        /// <param name="root"></param>
        /// <param name="step"></param>
        void PrintTree(TreeNode<T> root,int step)
        {
            if (root != null)
            {
                PrintTree(root.Right, (step + 1));             
                Console.WriteLine($"{new string('\t',step)}{root}");
                PrintTree(root.Left, (step + 1));
            }
        }

    }
}
