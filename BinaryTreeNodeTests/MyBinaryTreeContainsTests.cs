using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTreeNode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeNodeTests
{
    [TestClass]
    public class MyBinaryTreeContainsTests
    {
        private MyBinaryTree tree;

        [TestInitialize]
        public void Initialize()
        {
            tree = new MyBinaryTree();

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
        }

        [TestMethod]
        public void Contains__Item_Exists()
        {
            bool actual = tree.Contains("August");

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Contains__Item_Does_Not_Exist()
        {
            bool actual = tree.Contains("Borktember");

            Assert.IsFalse(actual);
        }
    }
}
