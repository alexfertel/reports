using System;
using System.Runtime.CompilerServices;

namespace Seminario9 {
    public class BinaryTree<T> : IBinaryTreeIterator<T>, IBinaryTreeHeigth<T> where T : IComparable<T> {
        public T Value { get; set; }
        public IBinaryTree<T> Left { get; set; }
        public IBinaryTree<T> Right { get; set; }

        public BinaryTree(T value) {
            Value = value;
        }

        public virtual void Insert(T value) {
            if (value.CompareTo(Value) == -1) {
                if (Left == null) {
                    Left = new BinaryTree<T>(value);
                }
                else {
                    Left.Insert(value);
                }
            }
            else {
                if (Right == null) {
                    Right = new BinaryTree<T>(value);
                }
                else {
                    Right.Insert(value);
                }
            }
        }
    }
}