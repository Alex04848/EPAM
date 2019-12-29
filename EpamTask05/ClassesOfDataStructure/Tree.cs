using EpamTask05.ExceptionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05
{
    /// <summary>
    /// The class which descibes Binary Tree, 
    /// This Data structure is very comfortable for searching of elements, 
    /// easy to add node and get min or max node 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public partial class Tree<T> where T : new()
    {
        /// <summary>
        /// The root of the tree
        /// </summary>
        public TreeNode<T> Root { get; set; }

        public Tree(T data) : this(new TreeNode<T>(data))
        {

        }

        public Tree(TreeNode<T> treeNode)
        {
            Root = treeNode;
        }

        public Tree() : this(new T())
        {
        }


        /// <summary>
        /// AddNode Method
        /// </summary>
        /// <param name="data"></param>
        public void AddNode(T data)
            => AddNode(new TreeNode<T>(data));

        /// <summary>
        /// AddNode Method
        /// </summary>
        /// <param name="data"></param>
        public void AddNode(TreeNode<T> nodeForAdd)
           => AddNode(Root, nodeForAdd);

        /// <summary>
        /// Private AddNode Method
        /// </summary>
        /// <param name="data"></param>
        void AddNode(TreeNode<T> nodeOfTree,TreeNode<T> nodeForAdd)
        {
            if (nodeForAdd > nodeOfTree)
            {
                if (nodeOfTree.Right == null)
                    nodeOfTree.Right = nodeForAdd;
                else
                    AddNode(nodeOfTree.Right, nodeForAdd);
            }
            else if (nodeForAdd < nodeOfTree)
            {
                if (nodeOfTree.Left == null)
                    nodeOfTree.Left = nodeForAdd;
                else
                    AddNode(nodeOfTree.Left, nodeForAdd);
            }
            else
                throw new TreeException("The element already exists in a Tree");
                
        }

        /// <summary>
        /// GetMaxNode Method
        /// </summary>
        /// <returns></returns>
        public TreeNode<T> GetMaxNode()
            => (GetMaxNode(Root));

        /// <summary>
        /// Private GetMaxNode Method
        /// </summary>
        /// <returns></returns>
        TreeNode<T> GetMaxNode(TreeNode<T> startNode)
           => ((startNode.Right == null) ? startNode : GetMaxNode(startNode.Right));

        /// <summary>
        /// GetMinNode Method
        /// </summary>
        /// <returns></returns>
        public TreeNode<T> GetMinNode()
         => (GetMinNode(Root));

        /// <summary>
        /// Private GetMinNode Method
        /// </summary>
        /// <returns></returns>
        TreeNode<T> GetMinNode(TreeNode<T> startNode)
           => ((startNode.Left == null) ? startNode : GetMinNode(startNode.Left));


        /// <summary>
        /// The Method Which print tree!!! But the method print tree by other method of an interface.
        /// It's like Open/Closed SOLID principle, the method more universal,
        /// because you can print tree in Console or File or maybe other place.
        /// </summary>
        /// <param name="treePrinter"></param>
        public void View(ITreePrinter<T> treePrinter)
            => treePrinter.PrintTree(this);
    }
}
