namespace DatabaseTests
{
    using Database;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class DbTests
    {
        private Type type;
        private const int ArraySize = 16;
        private const int InitArrayIndex = -1;

        [SetUp]
        public void Setup()
        {
            this.type = typeof(Database);
        }

        [Test]
        public void EmptyConstructorShouldInitData()
        {
            var db = new Database();

            var field = (int[])this.type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "data")
                .GetValue(db);

            var length = field.Length;

            Assert.AreEqual(length, ArraySize, "Internal Array is null");
        }

        [Test]
        public void EmptyConstructorShouldInitIndexToMinusOne()
        {
            var db = new Database();

            var indexValue = (int)this.type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "index")
                .GetValue(db);

            Assert.AreEqual(indexValue, InitArrayIndex, "Internal Array is null");
        }

        [Test]
        public void CtorShouldThrowInvalidOperationExceptionWithLargerArray()
        {
            int[] arr = new int[ArraySize + 13];

            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(arr);
            }, "Doesn't throw Invalid Operation Exception with more elements than ArraySize");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 78, 21 })]
        [TestCase(new int[] { 12, 32, 93 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CtorShouldSetIndexCorrectly(int[] values)
        {
            var db = new Database(values);

            int expectedResult = values.Length - 1;

            var actualResult = (int)this.type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "index")
                .GetValue(db);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 13, 31 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void AddShouldIncreaseIndex(int[] values)
        {
            var db = new Database(values);

            db.Add(132);

            var actualResult = (int)this.type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "index")
                .GetValue(db);

            var expectedResult = values.Length;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddInFullArrayShouldThrowInvalidOperationException(int[] values)
        {
            var db = new Database(values);

            Assert.Throws<InvalidOperationException>(() => db.Add(17));
        }

        [Test]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 13, 31 })]
        [TestCase(new int[] { 1, 13, 31, 41, 3, 5, 71 })]
        public void RemoveShouldDecreaseIndex(int[] values)
        {
            var db = new Database(values);

            db.Remove();

            var actualResult = (int)this.type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "index")
                .GetValue(db);

            var expectedResult = values.Length - 2;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(new int[] { })]
        public void RemoveInEmptyArrayShouldThrowInvalidOperationException(int[] values)
        {
            var db = new Database(values);

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 13, 31 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void FetchShouldReturnAllItems(int[] values)
        {
            var db = new Database(values);

            var expectedResult = values.Length;

            var actualResult = db.Fetch().Length;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}