using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05
{

    /// <summary>
    /// The Class which describes the node of the binary tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class TreeNode<T>
    {
        /// <summary>
        /// Value of the node
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Left Pointer
        /// </summary>
        public TreeNode<T> Left { get; set; }
        /// <summary>
        /// Right Pointer
        /// </summary>
        public TreeNode<T> Right { get; set; }


        public TreeNode(T value)
        {
            this.Value = value;
        }

        public TreeNode() : this(default)
        {
        }


        /// <summary>
        /// Overloaded Operation for compare
        /// </summary>
        /// <param name="treeNodeFirst"></param>
        /// <param name="treeNodeSecond"></param>
        /// <returns></returns>
        public static bool operator >(TreeNode<T> treeNodeFirst, TreeNode<T> treeNodeSecond)
            => (treeNodeFirst.GetHashCode() > treeNodeSecond.GetHashCode());

        /// <summary>
        /// Overloaded Operation for compare
        /// </summary>
        /// <param name="treeNodeFirst"></param>
        /// <param name="treeNodeSecond"></param>
        /// <returns></returns>
        public static bool operator <(TreeNode<T> treeNodeFirst, TreeNode<T> treeNodeSecond)
           => (treeNodeFirst.GetHashCode() < treeNodeSecond.GetHashCode());

        /// <summary>
        /// Overloaded Operation for compare
        /// </summary>
        /// <param name="treeNodeFirst"></param>
        /// <param name="treeNodeSecond"></param>
        /// <returns></returns>
        public static bool operator >=(TreeNode<T> treeNodeFirst, TreeNode<T> treeNodeSecond)
            => (treeNodeFirst.GetHashCode() >= treeNodeSecond.GetHashCode());

        /// <summary>
        /// Overloaded Operation for compare
        /// </summary>
        /// <param name="treeNodeFirst"></param>
        /// <param name="treeNodeSecond"></param>
        /// <returns></returns>
        public static bool operator <=(TreeNode<T> treeNodeFirst, TreeNode<T> treeNodeSecond)
           => (treeNodeFirst.GetHashCode() <= treeNodeSecond.GetHashCode());


        /// <summary>
        /// Overrided method GetHashCode
        /// </summary>
        /// <param name="treeNodeFirst"></param>
        /// <param name="treeNodeSecond"></param>
        /// <returns></returns>
        public override int GetHashCode()
                => (Value.GetHashCode());

        /// <summary>
        /// Overrided method Equals
        /// </summary>
        /// <param name="treeNodeFirst"></param>
        /// <param name="treeNodeSecond"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
            => ((obj is TreeNode<T> treeNode) && (this.GetHashCode() == treeNode.GetHashCode()));

        /// <summary>
        /// Overrided method ToString
        /// </summary>
        /// <param name="treeNodeFirst"></param>
        /// <param name="treeNodeSecond"></param>
        /// <returns></returns>
        public override string ToString()
            => Value.ToString();        
    }
}
