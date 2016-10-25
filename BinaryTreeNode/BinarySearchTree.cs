using System;

namespace BinaryTreeNode
{
    public class BinarySearchTree<T> : IMyCollection<T> where T : IComparable<T>
    {
        protected BinaryTreeNode<T> RootNode { get; set; }
        public int Count { get; protected set; }
        public int Depth => (int) Math.Log(Count, 2);  // TODO: stop lying
        public int Size { get; private set; }
        public bool IsBalanced { get; private set; }

        public BinarySearchTree()
        {
            RootNode = new BinaryTreeNode<T>();
        }

        public virtual void Add(T item)
        {
            Console.WriteLine($"Inserting value {item}");
            Insert(RootNode, item);
        }

        protected void Insert(BinaryTreeNode<T> node, T item)
        {
            // TODO: Handle inserting same value twice?

            // If node is empty, insert value
            if (node.Value == null)
            {
                node.Value = item;
                Count++;
                Console.WriteLine($"Inserted new node at depth {node.Depth}\n");

                return;
            }

            int comp = item.CompareTo(node.Value);
            switch (comp)
            {
                case 1:
                    Console.WriteLine($"Value at depth {node.Depth} is larger: Checking right side");

                    if (node.Right == null)
                    {
                        Console.WriteLine("Creating new node on right side");
                        node.Right = new BinaryTreeNode<T> { Parent = node };
                    }
                    Insert(node.Right, item);
                    break;
                case -1:
                    Console.WriteLine($"Value at depth {node.Depth} is smaller: Checking left side");

                    if (node.Left == null)
                    {
                        Console.WriteLine("Creating new node on left side");
                        node.Left = new BinaryTreeNode<T> { Parent = node };
                    }

                    Insert(node.Left, item);
                    break;
            }
        }

        public void Clear()
        {
            RootNode = new BinaryTreeNode<T>();
            Count = 0;
        }

        public bool Contains(T value)
        {
            BinaryTreeNode<T> result = FindNodeByValue(RootNode, value);
            return result != null;
        }

        public T Get()
        {
            throw new NotImplementedException();
        }

        public T GetAndRemove()
        {
            throw new NotImplementedException();
        }

        private BinaryTreeNode<T> FindNodeByValue(BinaryTreeNode<T> node, T value)
        {
            if (node == null || node.Value == null) return null;

            int comp = value.CompareTo(node.Value);
            switch (comp)
            {
                case 0:
                    return node;
                case -1:
                    return FindNodeByValue(node.Left, value);
                case 1:
                    return FindNodeByValue(node.Right, value);
            }

            // Nothing found
            return null;
        }

        protected virtual void InorderTraversal(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node == null) return;

            InorderTraversal(node.Left, action);
            action(node.Value);
            InorderTraversal(node.Right, action);
        }

        public void TraverseTree()
        {
            InorderTraversal(RootNode, v => Console.WriteLine(v));
        }
    }
}
