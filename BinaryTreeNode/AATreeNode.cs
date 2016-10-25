using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeNode
{
    public class AATreeNode<T> : BinaryTreeNode<T>
    {
        public new AATreeNode<T> Parent { get; set; }
        public new AATreeNode<T> Left { get; set; }
        public new AATreeNode<T> Right { get; set; }
        public int Level { get; set; } = 1;
    }
}
