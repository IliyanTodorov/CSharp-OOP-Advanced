using System;
using CustomLinkedList;
using NUnit.Framework;

namespace CustomLinkedListTests
{
    public class CustomLinkedListTests
    {
        private const int InitialCount = 0;
        private DynamicList<int> list;

        [SetUp]
        public void Setup()
        {
           this.list = new DynamicList<int>();
        }

        [Test]
        public void CtorShouldSetCountToZero()
        {
            Assert.AreEqual(list.Count, InitialCount);
        }

        [Test]
        public void IndexOperatorShouldReturnValue()
        {
            this.list.Add(10);
            Assert.That(this.list[0], Is.EqualTo(10));
        }
        
        [Test]
        public void IndexOperatorShouldSetValue()
        {
            this.list.Add(10);
            this.list[0] = 11;
            Assert.That(this.list[0], Is.EqualTo(11));
        }
        
        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        public void IndexOperatorShouldThrowExceptionWhenGettingInvalidIndex(int index)
        {
            FillWithDataList(this.list);
            var returnValue = 0;
            Assert.Throws<ArgumentOutOfRangeException>(() => returnValue = this.list[index]);
        }
        
        [Test]
        public void CannotCallElementWithIndexAboveTheRange()
        {
            var incorrectIndex = 1;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var test = this.list[incorrectIndex];
            }
                , "Provided index is greater than the range of the collection");
        }
        
        [Test]
        [TestCase(3, 1)]
        [TestCase(10, 1)]
        [TestCase(10, 0)]
        [TestCase(10, 7)]
        public void RemoveShouldDeleteElement(int numAdd, int numRemove)
        {
            //Arrange
            this.AddElementsInTheList(numAdd);
            //Act
            this.list.Remove(numRemove);
            //Assert
            Assert.That(-1, Is.EqualTo(this.list.IndexOf(numRemove)));
        }
        //
        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        public void IndexOperatorShouldThrowExceptionWhenSettingInvalidIndex(int index)
        {
            var list = DynamicList();
            FillWithDataList(list);
            Assert.Throws<ArgumentOutOfRangeException>(() => list[index] = 69);
        }

        [Test]
        [TestCase(3, 1)]
        [TestCase(5, 4)]
        [TestCase(10, 7)]
        public void RemoveShouldReturnTheIndexOfTheRemovedElement(int numberOfAdditions, int elementToRemove)
        {
            // Arrange 
            this.AddElementsInTheList(numberOfAdditions);
            var expectedIndex = elementToRemove;

            // Act
            var returnedIndex = this.list.Remove(elementToRemove);

            // Assert
            Assert.AreEqual(expectedIndex, returnedIndex, "Remove returns wrong index");
        }

        [Test]
        [TestCase(3, 3)]
        [TestCase(3, -1)]
        [TestCase(3, 10)]
        public void RemoveUnexistingElementShouldReturnNegativeInteger(int numberOfAdditions, int elementToRemove)
        {
            // Arrange
            this.AddElementsInTheList(numberOfAdditions);

            // Act
            var isRemovingResultLesThanZero = this.list.Remove(elementToRemove) < 0;

            // Assert
            Assert.IsTrue(isRemovingResultLesThanZero, "Attempting to remove an unxistint element returns positive integer");
        }

        [Test]
        [TestCase(3, 1)]
        [TestCase(5, 4)]
        [TestCase(10, 7)]
        public void ShouldReturnTrueIfElementExists(int numToAdd, int keyElement)
        {
            this.AddElementsInTheList(numToAdd);

            Assert.IsTrue(this.list.Contains(keyElement), "Contains returns false for existing element");
        }
        [Test]
        [TestCase(3, 3)]
        [TestCase(5, 6)]
        [TestCase(10, 159)]
        public void ShouldReturnFalseIfElementDoesNotExists(int numToAdd, int keyElement)
        {
            this.AddElementsInTheList(numToAdd);

            Assert.IsFalse(this.list.Contains(keyElement), "Contains returns true for element that doesn't existing");
        }

        private DynamicList<int> DynamicList()
        {
            DynamicList<int> list = new DynamicList<int>();
            return list;
        }

        private void FillWithDataList(DynamicList<int> list)
        {
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }
        }

        private void AddElementsInTheList(int numberOfAdditions)
        {
            for (int i = 0; i < numberOfAdditions; i++)
            {
                this.list.Add(i);
            }
        }
    }
}