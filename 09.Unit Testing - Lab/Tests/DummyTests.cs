using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private const int dummyHealth = 100;
        private const int dummyXP = 10;

        [SetUp]
        public void SetUp()
        {
            this.dummy = new Dummy(dummyHealth, dummyXP);
        }

        [Test]
        public void LosesHealthIfAttacked()
        {
            this.dummy.TakeAttack(9);

            const int expectedResult = 91;

            Assert.That(this.dummy.Health, Is.EqualTo(expectedResult), "Dummy Health doesn't change after taking damage");
        }

        [Test]
        public void DummyThrowsAnExceptionIfAttacked()
        {
            this.dummy.TakeAttack(140);

            const int expectedResult = -40;

            Assert.That(dummy.Health, Is.EqualTo(expectedResult));
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1), "Dummy must throw exception when attacked!");
        }

        [Test]
        public void DeadDummyCanGiveXp()
        {
            this.dummy.TakeAttack(120);

            const int expectedResult = 10;

            Assert.That(dummy.GiveExperience(), Is.EqualTo(expectedResult));
        }

        [Test]
        public void AliveDummyCanGiveXp()
        {
            Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience(), "Alive dummy must throw exception when try to give XP");
        }
    }
}