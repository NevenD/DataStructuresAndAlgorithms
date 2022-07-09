using NUnit.Framework;
using Stacks;
using System;

namespace StacksTests
{
    [TestFixture]
    public class LinkedStackTests
    {

        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            var stack = new LinkedStack<int>();
            Assert.IsTrue(stack.IsEmpty);
        }


        [Test]
        public void Count_PushOneItem_ReturnsOne()
        {
            var stack = new LinkedStack<int>();
            stack.Push(1);

            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty);
        }

        [Test]
        public void Pop_EmptyStack_ThrowsException()
        {
            var stack = new LinkedStack<int>();
            Assert.Throws<InvalidOperationException>(() =>
            {
                stack.Pop();
            });
        }
    }
}
