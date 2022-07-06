using Lists;
using NUnit.Framework;
using System;

namespace ListsTests
{
    [TestFixture]
    public class ListTests
    {
        private SingleLinkedList<int> _list;

        [SetUp]
        public void Init()
        {
            _list = new SingleLinkedList<int>();
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

        private void CheckStateWithSingleNode(SingleLinkedList<int> list)
        {
            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(list.IsEmpty);
            Assert.AreSame(list.Head, list.Tail);
        }
    }
}