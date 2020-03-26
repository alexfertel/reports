using System;
using System.Collections.Generic;

namespace Seminario9 {
    public static class Metrics {
        public static int Heigth<T>(this IBinaryTreeHeigth<T> tree) where T : IComparable<T> {
            if (tree == null)
                return 0;
            return 1 + Math.Max(Heigth((IBinaryTreeHeigth<T>) tree.Left), Heigth((IBinaryTreeHeigth<T>) tree.Right));
        }
    }

    public static class Iterators {
        public static IEnumerable<T> PreOrder<T>(this IBinaryTreeIterator<T> tree) where T : IComparable<T> {
            yield return tree.Value;

            if (tree.Left != null) {
                foreach (var item in PreOrder<T>((IBinaryTreeIterator<T>) tree.Left)) {
                    yield return item;
                }
            }

            if (tree.Right != null) {
                foreach (var item in PreOrder<T>((IBinaryTreeIterator<T>) tree.Right)) {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> InOrder<T>(this IBinaryTreeIterator<T> tree) where T : IComparable<T> {
            if (tree.Left != null) {
                foreach (var item in InOrder<T>((IBinaryTreeIterator<T>) tree.Left)) {
                    yield return item;
                }
            }

            yield return tree.Value;

            if (tree.Right != null) {
                foreach (var item in InOrder<T>((IBinaryTreeIterator<T>) tree.Right)) {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> PostOrder<T>(this IBinaryTreeIterator<T> tree) where T : IComparable<T> {
            if (tree.Left != null) {
                foreach (var item in PostOrder<T>((IBinaryTreeIterator<T>) tree.Left)) {
                    yield return item;
                }
            }


            if (tree.Right != null) {
                foreach (var item in PostOrder<T>((IBinaryTreeIterator<T>) tree.Right)) {
                    yield return item;
                }
            }

            yield return tree.Value;
        }
    }
}