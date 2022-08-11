using System;
using System.Collections.Generic;

namespace Trees
{
    /// <summary>
    /// Each node has 0,1, or 2 children
    /// Left and right child, each node in binary tree can have only 2 children
    /// BST log(n) for insertion, deletion and retrival
    /// </summary>
    public class TreeNode<T> where T : IComparable<T>
    {
        public T Value { get; private set; }
        public TreeNode<T> Left { get; private set; }
        public TreeNode<T> Right { get; private set; }

        public TreeNode(T value)
        {
            Value = value;
        }

        public void Insert(T newValue)
        {
            // Comparing current value with new value
            int compare = newValue.CompareTo(Value);
            if (compare == 0)
            {
                return;
            }

            // if it's different then
            if (compare < 0)
            {
                // if it's null, that means that we reached the end of the tree
                if (Left is null)
                {
                    Left = new TreeNode<T>(newValue);
                }
                else
                {
                    Left.Insert(newValue);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new TreeNode<T>(newValue);
                }
                else
                {
                    Right.Insert(newValue);
                }
            }
        }

        public TreeNode<T> Get(T value)
        {
            int compare = value.CompareTo(value);

            // if they are equal
            if (compare == 0)
            {
                // return the current node
                return this;
            }

            if (compare < 0)
            {
                if (Left != null)
                {
                    // recursivly going down the tree
                    return Left.Get(value);
                }
            }
            else
            {
                if (Right != null)
                {
                    return Right.Get(value);
                }
            }

            return null;
        }


        public IEnumerable<T> TraverseInOrder()
        {
            var list = new List<T>();

            InnerTraverse(list);

            return list;
        }

        private void InnerTraverse(List<T> list)
        {
            // starting from left
            if (Left != null)
            {
                Left.InnerTraverse(list);
            }

            list.Add(Value);

            if (Right != null)
            {
                Right.InnerTraverse(list);
            }
        }


        public T MinimumValueTreeNode()
        {
            if (Left != null)
            {
                return Left.MinimumValueTreeNode();
            }

            return Value;
        }

        public T MaximumValueTreeNode()
        {
            if (Right != null)
            {
                return Right.MaximumValueTreeNode();
            }

            return Value;
        }
    }
}
