using NUnit.Framework;
using Queues;
using System;

namespace QueuesTests
{
    [TestFixture]
    public class QueueLinkedList
    {

        [Test]
        public void IsEmpty_EmptyQueue_ReturnsTrue()
        {
            var queue = new QueueLinkedList<int>();
            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void Count_EnqueueOneItem_ReturnsOne()
        {
            var queue = new QueueLinkedList<int>();
            queue.Enqueue(1);

            Assert.AreEqual(1, queue.Count);
            Assert.IsFalse(queue.IsEmpty);

        }


        [Test]
        public void Peek_EnqueuTwoElement_ReturnHeadElement()
        {
            var queue = new QueueLinkedList<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);


            Assert.AreEqual(1, queue.Peek());
        }

        [Test]
        public void Peek_EnqueuTwoElementsAndDequeue_Return_HeadElement()
        {
            var queue = new QueueLinkedList<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            queue.Dequeue();

            Assert.AreEqual(2, queue.Peek());
        }


        [Test]
        public void Peek_EmptyStack_ThrowsException()
        {
            var queue = new QueueLinkedList<int>();
            Assert.Throws<InvalidOperationException>(() =>
            {
                queue.Dequeue();
            });
        }
    }
}
