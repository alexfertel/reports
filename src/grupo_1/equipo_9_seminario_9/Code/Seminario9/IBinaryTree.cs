using System;

namespace Seminario9 {
    public interface IBinaryTree<T> where T : IComparable<T> {
        T Value { get; set; }
        IBinaryTree<T> Left { get; set; }
        IBinaryTree<T> Right { get; set; }
        void Insert(T value);
    }

    public interface IBinaryTreeIterator<T> : IBinaryTree<T> where T : IComparable<T> { }
    
    public interface IBinaryTreeHeigth<T> : IBinaryTree<T> where T : IComparable<T> { }
}