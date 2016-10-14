using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeNode
{
    class MyBinaryTree<T> : IMyCollection<T>
    {
        private BinaryTreeNode<T> RootNode { get; set; }
        public int Count { get; private set; }

        public void Add(T item)
        {
            if (RootNode == null)
            {
                RootNode = new BinaryTreeNode<T>(item);
            }
        }

        public void Clear()
        {
            RootNode = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (RootNode.Value.Equals(item)) return true;




            return false;
        }

        public T Get()
        {
            throw new NotImplementedException();
        }

        public T GetAndRemove()
        {
            throw new NotImplementedException();
        }
    }
}
