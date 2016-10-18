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
        public int Depth => NodeDepth();

        public BinaryTreeNode()
        {
        }

        public BinaryTreeNode(T item)
        {
            Value = item;
        }

        private int NodeDepth()
        {
            int depth = 0;
            var node = this;

            while (!node.IsRootNode)
            {
                depth++;
                node = node.Parent;
            }

            return depth;
        }
    }
}
