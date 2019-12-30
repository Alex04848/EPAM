using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05.ClassesOfDataStructure
{
    /// <summary>
    /// The class of printer for tree with grades
    /// </summary>
    public class TreeOfGradesOfTestsPrinter : ITreePrinter<GradeOfTest>
    {

        /// <summary>
        /// Method of an interface
        /// </summary>
        /// <param name="tree"></param>
        public void PrintTree(Tree<GradeOfTest> tree)
            => PrintTree(tree.Root,0);

        /// <summary>
        /// Method for print
        /// </summary>
        /// <param name="tree"></param>
        void PrintTree(TreeNode<GradeOfTest> treeNode,int step)
        {
            if(treeNode != null)
            {
                PrintTree(treeNode.Right, (step + 1));

                string stringForTab = new string('\t', step);

                Console.WriteLine($"\n{stringForTab};FullName:{treeNode.Value.FullName};");
                Console.WriteLine($"{stringForTab};Subject:{treeNode.Value.Subject};");
                Console.WriteLine($"{stringForTab};Grade:{treeNode.Value.Grade};");
                Console.WriteLine($"{stringForTab};Date:{treeNode.Value.Date.ToString("dd/MM/yy")};\n");


                PrintTree(treeNode.Left, (step + 1));
            }
        }


    }
}
