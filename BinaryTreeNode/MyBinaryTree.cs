using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeNode
{
    public class MyBinaryTree : IMyCollection<string>
    {
        private BinaryTreeNode<string> RootNode { get; set; }
        public int Count { get; private set; }
        public int Depth => (int) Math.Log(Count, 2);

        public void Add(string item)
        {
            if (RootNode == null)
            {
                RootNode = new BinaryTreeNode<string>();
            }

            RecursiveAdd(RootNode, null, item);
        }

        private void RecursiveAdd(BinaryTreeNode<string> node, BinaryTreeNode<string> parent, string item, int depth = 0)
        {
            // TODO: Handle inserting same value twice?

            // If  node is empty, insert value
            if (node.Value == null)
            {
                Console.WriteLine($"Inserting new node at depth {depth}, value {item}\n");
                node.Value = item;
                node.Parent = parent;
                Count++;
                return;
            }

            // Horrible non-generic string comparator
            int comparator = string.Compare(item, node.Value);

            switch (comparator)
            {
                case -1:
                    Console.WriteLine("Value is larger than current node: Checking right side");

                    if (node.Right == null)
                    {
                        Console.WriteLine("Creating new node on right side");
                        node.Right = new BinaryTreeNode<string>();
                    }
                    RecursiveAdd(node.Right, node, item, depth + 1);
                    break;
                case 1:
                    Console.WriteLine("Value is smaller than current node: Checking left side");

                    if (node.Left == null)
                    {
                        Console.WriteLine("Creating new node on left side");
                        node.Left = new BinaryTreeNode<string>();
                    }

                    RecursiveAdd(node.Left, node, item, depth + 1);
                    break;
            }
        }

        public void Clear()
        {
            RootNode = null;
            Count = 0;
        }

        public bool Contains(string value)
        {
            BinaryTreeNode<string> result = FindNodeByValue(RootNode, value);
            return result != null;
        }

        public string Get()
        {
            throw new NotImplementedException();
        }

        public string GetAndRemove()
        {
            throw new NotImplementedException();
        }

        private BinaryTreeNode<string> FindNodeByValue(BinaryTreeNode<string> node, string value)
        {
            if (node?.Value == null) return null;

            int comparator = string.Compare(value, node.Value);
            switch (comparator)
            {
                case 0:
                    return node;
                case -1:
                    return FindNodeByValue(node.Left, value);
                case 1:
                    return FindNodeByValue(node.Right, value);
            }

            // Nothing found in entire tree
            return null;
        }

    }
}
