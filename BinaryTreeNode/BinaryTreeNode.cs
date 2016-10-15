using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeNode
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> Parent { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public bool IsRootNode => Parent == null;
        public bool IsLeafNode => Left == null && Right == null;

        public BinaryTreeNode()
        {           
        }

        public BinaryTreeNode(T item)
        {
            Value = item;
        }
    }
}
