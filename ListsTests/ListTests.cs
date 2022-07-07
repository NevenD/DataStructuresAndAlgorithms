using Lists;
using NUnit.Framework;
using System;

namespace ListsTests
{
    [TestFixture]
    public class ListTests
    {
        private SingleLinkedList<int> _list;
        private MultipleLinkedList<int> _multiple;


        [SetUp]
        public void Init()
        {
            _list = new SingleLinkedList<int>();
            _multiple = new MultipleLinkedList<int>();

        }

        [Test]
        public void CreateMultipleEmptyList_CorrectState()
        {
            Assert.IsTrue(_multiple.IsEmpty);
            Assert.IsNull(_multiple.Head);
            Assert.IsNull(_multiple.Tail);
        }

        [Test]
        public void CreateEmptyList_CorrectState()
        {
            Assert.IsTrue(_list.IsEmpty);
            Assert.IsNull(_list.Head);
            Assert.IsNull(_list.Tail);
        }

        [Test]
        public void AddFirst_And_Last_OneItem_CorrectState()
        {
            _list.AddFirstElement(1);
            CheckStateWithSingleNode(_list);

            _list.RemoveFirstElement();
            _list.AddLastElement(1);

            CheckStateWithSingleNode(_list);
        }

        [Test]
        public void MultipleList_AddFirst_And_Last_OneItem_CorrectState()
        {
            _multiple.AddFirstElement(1);
            CheckStateWithMultipleNode(_multiple);

            _multiple.RemoveFirstElement();
            _multiple.AddLastElement(1);

            CheckStateWithMultipleNode(_multiple);
        }

        [Test]
        public void AddRemoveToGetToStateWithSingleNode_CorrectState()
        {
            _list.AddFirstElement(1);
            _list.AddFirstElement(2);
            _list.RemoveFirstElement();

            CheckStateWithSingleNode(_list);

            _list.AddFirstElement(2);
            _list.RemoveLastElement();

            CheckStateWithSingleNode(_list);
        }

        [Test]
        public void MultipleList_AddRemoveToGetToStateWithSingleNode_CorrectState()
        {
            _multiple.AddFirstElement(1);
            _multiple.AddFirstElement(2);
            _multiple.RemoveFirstElement();

            CheckStateWithMultipleNode(_multiple);

            _multiple.AddFirstElement(2);
            _multiple.RemoveLastElement();

            CheckStateWithMultipleNode(_multiple);
        }

        [Test]
        public void AddFirst_and_AddLast_AddItemsInCorrectOrder()
        {
            _list.AddFirstElement(1);
            _list.AddFirstElement(2);

            Assert.AreEqual(2, _list.Head.Value);
            Assert.AreEqual(1, _list.Tail.Value);


            _list.AddLastElement(3);
            Assert.AreEqual(3, _list.Tail.Value);
        }

        [Test]
        public void MultipleList_AddFirst_and_AddLast_AddItemsInCorrectOrder()
        {
            _multiple.AddFirstElement(1);
            _multiple.AddFirstElement(2);

            Assert.AreEqual(2, _multiple.Head.Value);
            Assert.AreEqual(1, _multiple.Tail.Value);


            _multiple.AddLastElement(3);
            Assert.AreEqual(3, _multiple.Tail.Value);
        }

        [Test]
        public void RemoveFirst_EmptyList_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => _list.RemoveFirstElement());
        }

        [Test]
        public void RemoveLast_EmptyList_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => _list.RemoveLastElement());
        }

        [Test]
        public void MultipleList_RemoveFirst_EmptyList_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => _multiple.RemoveFirstElement());
        }

        [Test]
        public void MultipleList_RemoveLast_EmptyList_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => _multiple.RemoveLastElement());
        }

        [Test]
        public void RemoveFirst_RemoveLast_CorrectState()
        {
            _list.AddFirstElement(1);
            _list.AddFirstElement(2);
            _list.AddFirstElement(3);
            _list.AddFirstElement(4);

            _list.RemoveFirstElement();
            _list.RemoveLastElement();

            Assert.AreEqual(3, _list.Head.Value);
            Assert.AreEqual(2, _list.Tail.Value);
        }

        [Test]
        public void MultipleList_RemoveFirst_RemoveLast_CorrectState()
        {
            _multiple.AddFirstElement(1);
            _multiple.AddFirstElement(2);
            _multiple.AddFirstElement(3);
            _multiple.AddFirstElement(4);

            _multiple.RemoveFirstElement();
            _multiple.RemoveLastElement();

            Assert.AreEqual(3, _multiple.Head.Value);
            Assert.AreEqual(2, _multiple.Tail.Value);
        }

        private void CheckStateWithSingleNode(SingleLinkedList<int> list)
        {
            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(list.IsEmpty);
            Assert.AreSame(list.Head, list.Tail);
        }

        private void CheckStateWithMultipleNode(MultipleLinkedList<int> multi)
        {
            Assert.AreEqual(1, multi.Count);
            Assert.IsFalse(multi.IsEmpty);
            Assert.AreSame(multi.Head, multi.Tail);
        }
    }
}