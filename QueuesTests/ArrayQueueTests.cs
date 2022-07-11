using NUnit.Framework;
using Queues;
using System;

namespace QueuesTests
{
    [TestFixture]
    public class ArrayQueueTests
    {

        [Test]
        public void Capacity_EnqueManyItems_DoubleCapacity()
        {
            var queue = new ArrayQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual(8, queue.Capacity);
        }

        [Test]
        public void IsEmpty_EmptyQueue_ReturnsTrue()
        {
            var queue = new ArrayQueue<int>();
            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void Countr_EnqueueOneItem_ReturnsOne()
        {
            var queue = new ArrayQueue<int>();
            queue.Enqueue(1);

            Assert.AreEqual(1, queue.Count);
            Assert.IsFalse(queue.IsEmpty);

        }


        [Test]
        public void Peek_EnqueuTwoElement_ReturnHeadElement()
        {
            var queue = new ArrayQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);


            Assert.AreEqual(1, queue.Peek());
        }

        [Test]
        public void Peek_EnqueuTwoElementsAndDequeue_Return_HeadElement()
        {
            var queue = new ArrayQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            queue.Dequeue();

            Assert.AreEqual(2, queue.Peek());
        }


        [Test]
        public void Peek_EmptyStack_ThrowsException()
        {
            var queue = new ArrayQueue<int>();
            Assert.Throws<InvalidOperationException>(() =>
            {
                queue.Dequeue();
            });
        }
    }
}
