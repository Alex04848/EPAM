using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05
{

    [Serializable]
    public class TreeNode<T>
    {
        public T Value { get; private set; }


        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }


        public TreeNode(T value)
        {
            this.Value = value;
        }

        public TreeNode() : this(default)
        {
        }



        public static bool operator >(TreeNode<T> treeNodeFirst, TreeNode<T> treeNodeSecond)
            => (treeNodeFirst.GetHashCode() > treeNodeSecond.GetHashCode());

        public static bool operator <(TreeNode<T> treeNodeFirst, TreeNode<T> treeNodeSecond)
           => (treeNodeFirst.GetHashCode() < treeNodeSecond.GetHashCode());

        public static bool operator >=(TreeNode<T> treeNodeFirst, TreeNode<T> treeNodeSecond)
            => (treeNodeFirst.GetHashCode() >= treeNodeSecond.GetHashCode());

        public static bool operator <=(TreeNode<T> treeNodeFirst, TreeNode<T> treeNodeSecond)
           => (treeNodeFirst.GetHashCode() <= treeNodeSecond.GetHashCode());



        public override int GetHashCode()
                => (Value.GetHashCode());

        public override bool Equals(object obj)
            => ((obj is TreeNode<T> treeNode) && (this.GetHashCode() == treeNode.GetHashCode()));


        public override string ToString()
            => Value.ToString();        
    }
}
