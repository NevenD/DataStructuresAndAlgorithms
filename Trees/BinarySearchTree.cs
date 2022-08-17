using System;
using System.Collections.Generic;
using System.Linq;

namespace Trees
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> _root;


        public void Remove(T value)
        {
            _root = Remove(_root, value);
        }

        public TreeNode<T> Remove(TreeNode<T> subtreeRoot, T value)
        {
            if (subtreeRoot is null)
            {
                return null;
            }

            int compareTo = value.CompareTo(subtreeRoot.Value);

            if (compareTo < 0)
            {
                subtreeRoot.Left = Remove(subtreeRoot.Left, value);
            }
            else if (compareTo > 0)
            {
                subtreeRoot.Right = Remove(subtreeRoot.Right, value);
            }
            else
            {
                if (subtreeRoot.Left is null)
                {
                    return subtreeRoot.Right;
                }

                if (subtreeRoot.Right is null)
                {
                    return subtreeRoot.Left;
                }

                subtreeRoot.Value = subtreeRoot.Right.MinimumValueTreeNode();

                subtreeRoot.Right = Remove(subtreeRoot.Right, subtreeRoot.Value);
            }

            return subtreeRoot;
        }

        public TreeNode<T> Get(T value)
        {
            return _root?.Get(value);
        }

        public T MinimumValue()
        {
            if (_root is null)
            {
                throw new InvalidOperationException();
            }

            return _root.MinimumValueTreeNode();
        }

        public T MaximumValue()
        {
            if (_root is null)
            {
                throw new InvalidOperationException();
            }

            return _root.MaximumValueTreeNode();
        }

        public void Insert(T value)
        {
            if (_root is null)
            {
                _root = new TreeNode<T>(value);
            }
            else
            {
                _root.Insert(value);
            }
        }

        public IEnumerable<T> TraverseInOrder()
        {
            if (_root != null)
            {
                return _root.TraverseInOrder();
            }

            return Enumerable.Empty<T>();
        }

    }
}
