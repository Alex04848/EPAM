using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05.ClassesOfDataStructure
{
    /// <summary>
    /// The part of class which perfoms Balance Method
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class Tree<T> where T : new()
    {
        /// <summary>
        /// The method gets the heights node and return the number of his level
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        int GetHeight(TreeNode<T> treeNode)
        {
            int maxHeight = default;

            GetHeight(treeNode, 0, ref maxHeight);

            return maxHeight;
        }

        /// <summary>
        /// The method gets the heights node and return the number of his level
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        void GetHeight(TreeNode<T> node,int heightOfNode,ref int maxHeight)
        {
            if(node != null)
            {
                GetHeight(node.Right,(heightOfNode + 1),ref maxHeight);

                if (heightOfNode > maxHeight)
                    maxHeight = heightOfNode;

                GetHeight(node.Left, (heightOfNode + 1), ref maxHeight);
            }
        }

        /// <summary>
        /// RotateToLeft Method
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        TreeNode<T> RotateLeft(TreeNode<T> treeNode)
        {
            if(treeNode != null && treeNode.Left != null && treeNode.Right != null)
            {
                TreeNode<T> rightNode = treeNode.Right;
                treeNode.Right = rightNode.Left;
                rightNode.Left = treeNode;

                return rightNode;
            }

            return treeNode;
        }

        /// <summary>
        /// RotateToRight Method
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        TreeNode<T> RotateRight(TreeNode<T> treeNode)
        {
            if (treeNode != null && treeNode.Left != null && treeNode.Right != null)
            {
                TreeNode<T> leftNode = treeNode.Left;
                treeNode.Left = leftNode.Right;
                leftNode.Right = treeNode;

                return leftNode;
            }

            return treeNode;
        }

        /// <summary>
        /// The Method which finds balance factor
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        int BFactor(TreeNode<T> treeNode)
            => (GetHeight(treeNode.Right) - GetHeight(treeNode.Left));

        /// <summary>
        /// Balance Method which helps to Create AVL Binary Tree
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        TreeNode<T> Balance(TreeNode<T> treeNode)
        {
            if(BFactor(treeNode) == 2)
            {
                if (BFactor(treeNode.Right) < 0)
                    treeNode.Right = RotateRight(treeNode.Right);

                return RotateLeft(treeNode);
            }
            else if(BFactor(treeNode) == -2)
            {
                if (BFactor(treeNode.Left) > 0)
                    treeNode.Left = RotateLeft(treeNode.Left);

                return RotateRight(treeNode);
            }

            return treeNode;
        }

    }
}
