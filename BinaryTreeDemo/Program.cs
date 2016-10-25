using System;
using BinaryTreeNode;

namespace BinaryTreeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new AATree<string>();

            tree.Add("January");
            tree.Add("February");
            tree.Add("March");
            tree.Add("April");
            tree.Add("May");
            tree.Add("June");
            tree.Add("July");
            tree.Add("August");
            tree.Add("September");
            tree.Add("October");
            tree.Add("November");
            tree.Add("December");

            //for (int i = 1; i <= 1303; i++)
            //{
            //    tree.Add(i.ToString());
            //}

            Console.WriteLine();
            Console.WriteLine($"Tree has {tree.Count} nodes, depth {tree.Depth}");

            Console.WriteLine($"Tree contains \"August\": {tree.Contains("August")}");
            Console.WriteLine($"Tree contains \"Borktember\": {tree.Contains("Borktember")}");

            Console.WriteLine("Ordered tree traversal:");
            tree.TraverseTree();

        }
    }
}
