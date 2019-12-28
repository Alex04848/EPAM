using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05
{
    public class TreePrinter<T> : ITreePrinter<T>
    {
        public void PrintTree(TreeNode<T> root)
            => PrintTree(root, 0);

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
