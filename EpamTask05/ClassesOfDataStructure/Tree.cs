using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05
{
    [Serializable]
    public class Tree<T> where T : new()
    {
        public TreeNode<T> Root { get; private set; }


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


        public void AddNode(T data)
            => AddNode(new TreeNode<T>(data));

        public void AddNode(TreeNode<T> nodeForAdd)
           => AddNode(Root, nodeForAdd);

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
                //I Should Create my own exception
                throw new Exception("The element already exists in a Tree");
                
        }




        public bool Contains(T data)
                => Contains(new TreeNode<T>(data));

        public bool Contains(TreeNode<T> treeNode)
                => Contains(Root,treeNode);

        bool Contains(TreeNode<T> startNode,TreeNode<T> nodeForSearch)
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



        public void DeleteNode(T data)
            => DeleteNode(new TreeNode<T>(data));

        public void DeleteNode(TreeNode<T> treeNode)
             => DeleteNode(Root, treeNode);

        void DeleteNode(TreeNode<T> startNode,TreeNode<T> nodeForRemove)
        {
            if(startNode != null)
            {
                if (nodeForRemove > startNode)
                    DeleteNode(startNode.Right, nodeForRemove);
                else if (nodeForRemove < startNode)
                    DeleteNode(startNode.Left, nodeForRemove);
                else if (nodeForRemove.Equals(startNode))
                    RemoveFromNodeOperation(startNode);
            }
        }


        public TreeNode<T> FindPrev(T data)
           => FindPrev(new TreeNode<T>(data));

        public TreeNode<T> FindPrev(TreeNode<T> treeNode)
            => FindPrev(Root, treeNode);

        TreeNode<T> FindPrev(TreeNode<T> nodeForStart, TreeNode<T> nodeForSearch)
        {
            if (nodeForStart != null)
            {
                if (nodeForSearch.Equals(nodeForStart?.Right) || nodeForSearch.Equals(nodeForStart?.Left))
                    return nodeForStart;
                else if (nodeForSearch.Equals(Root))
                    //I Should Create My Own Exception!!!
                    throw new Exception("You can't find Prev Node For Root!!!");
                else
                {
                    if (nodeForSearch > nodeForStart)
                        return FindPrev(nodeForStart.Right, nodeForSearch);
                    else
                        return FindPrev(nodeForStart.Left, nodeForSearch);
                }       
            }

            //I Should Create My Own Exception!!!
            throw new Exception("The node doesn't exist");
        }



        void RemoveFromNodeOperation(TreeNode<T> nodeForRemove)
        {
            if (nodeForRemove.Left == null && nodeForRemove.Right == null)
                RemoveOperationFirstCase(FindPrev(Root, nodeForRemove), nodeForRemove);
            else if ((nodeForRemove.Left != null && nodeForRemove.Right == null) || (nodeForRemove.Left == null && nodeForRemove.Right != null))
                RemoveOperationSecondCase(FindPrev(Root, nodeForRemove), nodeForRemove);
            else if (nodeForRemove.Left != null && nodeForRemove.Right != null)
                RemoveOperationThirdCase(nodeForRemove);

        }

        void RemoveOperationFirstCase(TreeNode<T> prevNode,TreeNode<T> nodeForRemove,TreeNode<T> nextAfterNodeForRemove = null)
        {
            if (nodeForRemove.Equals(prevNode.Right))
                prevNode.Right = nextAfterNodeForRemove;
            else
                prevNode.Left = nextAfterNodeForRemove;
        }

        void RemoveOperationSecondCase(TreeNode<T> prevNode,TreeNode<T> nodeForRemove)
        {
            TreeNode<T> nextAfterNodeForRemove = (nodeForRemove.Right == null) ? nodeForRemove.Left : nodeForRemove.Right;

            RemoveOperationFirstCase(prevNode, nodeForRemove, nextAfterNodeForRemove);
        }

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



        public void View(ITreePrinter<T> treePrinter)
            => treePrinter.PrintTree(Root);
    }
}
