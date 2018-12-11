using System;
using ExtendedDatabase;
using ExtendedDatabase.Contracts;
using NUnit.Framework;

namespace ExtendedDatabaseTests
{
    [TestFixture]
    public class ExtendedDbTests
    {
        private const int Id = 1;
        private const string Name = "Ivan";
        private const int Id2 = 2;
        private const string Name2 = "Goshko";

        private IPerson[] people = new Person[]
        {
            new Person(Id, Name),
            new Person(Id2, Name2),
        };

        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(this.people);
        }

        [Test]
        public void ConstructorInitializedCorrectly()
        {
            Assert.DoesNotThrow(() => this.database = new Database(this.people), "Constructor should not throw an exception!");

            Assert.Pass();
        }

        [Test]
        public void CheckDataBaseSize()
        {
            Assert.AreEqual(this.people.Length, this.database.Size, "Invalid size!");
        }

        [Test]
        public void AddPeople_WithDifferentNames_ShouldWorkCorrect()
        {
            int expectedResult = 3;
            IPerson person = new Person(12, "Stoyan");
            Assert.DoesNotThrow(() => this.database.Add(person), "Adding people doesn't work as well!");
            Assert.AreEqual(this.database.Size, expectedResult, "Adding people doesn't work");
        }

        [Test]
        public void AddPeople_WithSameName_ExpectedException()
        {
            IPerson person = new Person(3, Name);
            Assert.Throws<InvalidOperationException>(() => this.database.Add(person),
                "Exception has not be thrown, when adding people with same names!");
        }

        [Test]
        public void AddPeople_WithSameId_ExpectedException()
        {
            IPerson person = new Person(Id, "Misho");
            Assert.Throws<InvalidOperationException>(() => this.database.Add(person),
                "Exception has not be thrown, when adding people with same Ids!");
        }

        [Test]
        public void AddPerson_ExistingNameCaseSensitiveTest_ExpectedException()
        {
            var expectedValue = 3;
            IPerson person = new Person(14, Name2.ToLower());
            Assert.DoesNotThrow(() => this.database.Add(person), "Adding person does not work fine!");
            Assert.AreEqual(expectedValue, this.database.Size, "Invalid database size");
        }

        [Test]
        public void RemoveExistingPersonAndAddPerson_WithSameName_ShouldWork()
        {
            IPerson person = new Person(Id2, Name2);

            this.database.Remove();
            this.database.Remove();
            Assert.AreEqual(0, this.database.Size);
            this.database.Add(person);
            Assert.AreEqual(1, this.database.Size);
        }

        [Test]
        public void FindByUsername_PassNullArgument_ExpectedException()
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null), "Searching with null does not throw exception!");
        }

        [Test]
        public void FindByUsername_NameNotExistInCollection_ExpectedException()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("Stoyancho"), "Searching with not existing name does not throw exception!");
        }

        [Test]
        public void FindByUsername_StringExists_ExpectedObjectPerson()
        {
            this.database.Add(new Person(6, "Shinka"));

            var person = this.database.FindByUsername("Shinka");

            Assert.AreEqual(typeof(Person).Name, person.GetType().Name, "Unmatching types!");
            Assert.AreEqual("Shinka", person.Username, "Username does not match!");
            Assert.AreEqual(6, person.ID, "Id does not match!");
        }

        [Test]
        public void FindById_PassNegativeNumber_ExpectedException()
        {
            int negativeNumber = -1;

            Assert.Throws<ArgumentNullException>(() => this.database.FindById(negativeNumber), "Searching with negative number does not throw exception!");
        }

        [Test]
        public void FindById_IdNotExistInCollection_ExpectedException()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(81), "Searching with non existing number does not throw exception!");
        }

        [Test]
        public void FindById_ExistingIdNumber_ExpectedPersonObject()
        {
            var person = this.database.FindById(2);

            Assert.AreEqual(typeof(Person).Name, person.GetType().Name, "Unmatching types!");
            Assert.AreEqual(Name2, person.Username, "Username does not match!");
            Assert.AreEqual(2, person.ID, "Id does not match!");
        }
    }
}