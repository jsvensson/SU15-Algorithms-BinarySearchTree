using System;

namespace BinaryTreeNode
{
    public class MyBinaryTree<T> : IMyCollection<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> RootNode { get; set; }
        public int Count { get; private set; }
        public int Depth => (int) Math.Log(Count, 2);  // TODO: stop lying
        public int Size { get; private set; }
        public bool IsBalanced { get; private set; }

        public MyBinaryTree()
        {
            RootNode = new BinaryTreeNode<T>();
        }

        public void Add(T item)
        {
            RecursiveAdd(RootNode, null, item);
        }

        private void RecursiveAdd(BinaryTreeNode<T> node, BinaryTreeNode<T> parent, T item)
        {
            // TODO: Handle inserting same value twice?

            // If node is empty, insert value
            if (node.Value == null)
            {
                node.Value = item;
                node.Parent = parent;
                Count++;
                Console.WriteLine($"Inserted new node at depth {node.Depth}, value {item}\n");

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
                        node.Right = new BinaryTreeNode<T>();
                    }
                    RecursiveAdd(node.Right, node, item);
                    break;
                case -1:
                    Console.WriteLine($"Value at depth {node.Depth} is smaller: Checking left side");

                    if (node.Left == null)
                    {
                        Console.WriteLine("Creating new node on left side");
                        node.Left = new BinaryTreeNode<T>();
                    }

                    RecursiveAdd(node.Left, node, item);
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

    }
}
