using EpamTask05.ExceptionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05.ClassesOfDataStructure
{
    /// <summary>
    /// The part of tree class which performs deleting of nodes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class Tree<T> where T : new()
    {
        /// <summary>
        /// The method which delete an element from a tree
        /// </summary>
        /// <param name="data"></param>
        public void DeleteNode(T data)
          => DeleteNode(new TreeNode<T>(data));

        /// <summary>
        /// The method which delete a node from a tree
        /// </summary>
        /// <param name="data"></param>
        public void DeleteNode(TreeNode<T> treeNode)
             => DeleteNode(Root, treeNode);

        /// <summary>
        /// Private DeleteNode Method
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="nodeForRemove"></param>
        void DeleteNode(TreeNode<T> startNode, TreeNode<T> nodeForRemove)
        {
            if (startNode != null)
            {
                if (nodeForRemove > startNode)
                    DeleteNode(startNode.Right, nodeForRemove);
                else if (nodeForRemove < startNode)
                    DeleteNode(startNode.Left, nodeForRemove);
                else if (nodeForRemove.Equals(startNode))
                    RemoveFromNodeOperation(startNode);
            }
        }

        /// <summary>
        /// The method is searching for type of removing and perform it
        /// </summary>
        /// <param name="nodeForRemove"></param>
        void RemoveFromNodeOperation(TreeNode<T> nodeForRemove)
        {
            if (nodeForRemove.Left == null && nodeForRemove.Right == null)
                RemoveOperationFirstCase(FindPrev(Root, nodeForRemove), nodeForRemove);
            else if ((nodeForRemove.Left != null && nodeForRemove.Right == null) || (nodeForRemove.Left == null && nodeForRemove.Right != null))
                RemoveOperationSecondCase(FindPrev(Root, nodeForRemove), nodeForRemove);
            else if (nodeForRemove.Left != null && nodeForRemove.Right != null)
                RemoveOperationThirdCase(nodeForRemove);
        }

        /// <summary>
        /// First Case Of Removing of a node
        /// </summary>
        /// <param name="nodeForRemove"></param>
        void RemoveOperationFirstCase(TreeNode<T> prevNode, TreeNode<T> nodeForRemove, TreeNode<T> nextAfterNodeForRemove = null)
        {
            if (nodeForRemove.Equals(prevNode.Right))
                prevNode.Right = nextAfterNodeForRemove;
            else
                prevNode.Left = nextAfterNodeForRemove;
        }

        /// <summary>
        /// Second Case Of Removing of a node
        /// </summary>
        /// <param name="nodeForRemove"></param>
        void RemoveOperationSecondCase(TreeNode<T> prevNode, TreeNode<T> nodeForRemove)
        {
            TreeNode<T> nextAfterNodeForRemove = (nodeForRemove.Right == null) ? nodeForRemove.Left : nodeForRemove.Right;

            RemoveOperationFirstCase(prevNode, nodeForRemove, nextAfterNodeForRemove);
        }

        /// <summary>
        /// Third Case Of Removing of a node
        /// </summary>
        /// <param name="nodeForRemove"></param>
        void RemoveOperationThirdCase(TreeNode<T> nodeForRemove)
        {
            TreeNode<T> forSwap = nodeForRemove.Left;

            while (forSwap.Right != null)
                forSwap = forSwap.Right;

            DeleteNode(Root, forSwap);

            forSwap.Left = nodeForRemove.Left;
            forSwap.Right = nodeForRemove.Right;

            if (!nodeForRemove.Equals(Root))
            {
                TreeNode<T> prevNode = FindPrev(Root, nodeForRemove);

                if (nodeForRemove.Equals(prevNode.Right))
                    prevNode.Right = forSwap;
                else if (nodeForRemove.Equals(prevNode.Left))
                    prevNode.Left = forSwap;
            }
            else
                Root = forSwap;

        }

    }
}