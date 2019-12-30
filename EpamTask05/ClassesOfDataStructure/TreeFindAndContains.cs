using EpamTask05.ExceptionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05.ClassesOfDataStructure
{
    /// <summary>
    /// The part of class which perfroms comparing between nodes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class Tree<T> where T : new()
    {
        /// <summary>
        /// The method which checks is binary tree contain the element or not.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Contains(T data)
                => Contains(new TreeNode<T>(data));

        /// <summary>
        /// The method which checks is binary tree contain the node or not.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Contains(TreeNode<T> treeNode)
                => Contains(Root, treeNode);

        /// <summary>
        /// Private Contains method
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="nodeForSearch"></param>
        /// <returns></returns>
        bool Contains(TreeNode<T> startNode, TreeNode<T> nodeForSearch)
        {
            if (startNode != null)
            {
                if (nodeForSearch > startNode)
                    return Contains(startNode.Right, nodeForSearch);
                else if (nodeForSearch < startNode)
                    return Contains(startNode.Left, nodeForSearch);
                else
                    return nodeForSearch.Equals(startNode);
            }

            return false;
        }

        /// <summary>
        /// The method which perfroms the searching of Previouns node for Current element
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public TreeNode<T> FindPrev(T data)
           => FindPrev(new TreeNode<T>(data));

        /// <summary>
        /// The method which perfroms the searching of Previouns node for Current node
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public TreeNode<T> FindPrev(TreeNode<T> treeNode)
            => FindPrev(Root, treeNode);

        /// <summary>
        /// Private Method FindPrev
        /// </summary>
        /// <param name="nodeForStart"></param>
        /// <param name="nodeForSearch"></param>
        /// <returns></returns>
        TreeNode<T> FindPrev(TreeNode<T> nodeForStart, TreeNode<T> nodeForSearch)
        {
            if (nodeForStart != null)
            {
                if (nodeForSearch.Equals(nodeForStart?.Right) || nodeForSearch.Equals(nodeForStart?.Left))
                    return nodeForStart;
                else if (nodeForSearch.Equals(Root))
                    throw new TreeException("You can't find Prev Node For Root!!!");
                else
                {
                    if (nodeForSearch > nodeForStart)
                        return FindPrev(nodeForStart.Right, nodeForSearch);
                    else
                        return FindPrev(nodeForStart.Left, nodeForSearch);
                }
            }

            throw new TreeException("The node doesn't exist");
        }

        /// <summary>
        /// The Method which performs the searching of element in a tree
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public TreeNode<T> FindNode(T value)
                   => (FindNode(new TreeNode<T>(value)));

        /// <summary>
        /// The Method which performs the searching of node in a tree
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TreeNode<T> FindNode(TreeNode<T> treeNode)
                    => (FindNode(Root, treeNode));

        /// <summary>
        /// Private Method FindNode
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        TreeNode<T> FindNode(TreeNode<T> startNode, TreeNode<T> treeNode)
        {
            if (startNode != null)
            {
                if (treeNode > startNode)
                    return FindNode(startNode.Right, treeNode);
                else if (treeNode < startNode)
                    return FindNode(startNode.Left, treeNode);
            }
            
            return startNode;
        }

    }
}