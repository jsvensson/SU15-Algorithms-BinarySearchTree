using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeNode
{
    public class AATree<T> : BinarySearchTree<T> where T : IComparable<T>
    {
        private new AATreeNode<T> RootNode { get; set; }

        public override void Add(T item)
        {
            RootNode = Insert(RootNode, item);
        }

        protected AATreeNode<T> Insert(AATreeNode<T> node, T item)
        {
            if (node == null)
            {
                Count++;
                return new AATreeNode<T> { Value = item };
            }

            int comp = item.CompareTo(node.Value);
            switch (comp)
            {
                case -1:
                    node.Left = Insert(node.Left, item);
                    break;
                case 1:
                    node.Right = Insert(node.Right, item);
                    break;
            }

            node = Skew(node);
            node = Split(node);

            // Return node as-is if item is equal
            return node;
        }

        private AATreeNode<T> Skew(AATreeNode<T> node)
        {
            if (node == null) return null;
            if (node.Left == null) return node;

            if (node.Left.Level == node.Level)
            {
                var left = node.Left;
                node.Left = left.Right;
                left.Right = node;
                return left;
            }

            return node;
        }

        private AATreeNode<T> Split(AATreeNode<T> node)
        {
            if (node == null) return null;
            if (node.Right?.Right == null) return node;

            if (node.Level == node.Right.Right.Level)
            {
                var right = node.Right;
                node.Right = right.Left;
                right.Left = node;
                right.Level = right.Level + 1;
                return right;
            }

            return node;
        }

        protected void InorderTraversal(AATreeNode<T> node, Action<T> action)
        {
            if (node == null) return;

            InorderTraversal(node.Left, action);
            action(node.Value);
            InorderTraversal(node.Right, action);
        }

        public new void TraverseTree()
        {
            InorderTraversal(RootNode, v => Console.WriteLine(v));
        }
    }
}
