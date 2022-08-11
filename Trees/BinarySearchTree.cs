using System;
using System.Collections.Generic;
using System.Linq;

namespace Trees
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> _root;


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
