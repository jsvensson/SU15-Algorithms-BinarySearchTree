namespace BinaryTreeNode
{
    public interface IMyCollection<T>
    {
        int Count { get; }
        void Add(T item);
        T Get();
        T GetAndRemove();
        void Clear();
        bool Contains(T value);
    }
}