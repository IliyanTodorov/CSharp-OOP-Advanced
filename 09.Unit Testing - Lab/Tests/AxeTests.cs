using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe weapon;
        private Dummy dummy;
        private const int weaponAttack = 100;
        private const int weaponDurability = 10;
        private const int dummyHealth = 100;
        private const int dummyXP = 20;

        [SetUp]
        public void CreateWeaponBeforeEachTest()
        {
            this.weapon = new Axe(weaponAttack, weaponDurability);
            this.dummy = new Dummy(dummyHealth, dummyXP);
        }

        [Test]
        public void TestIfWeaponLosesDurabilityAfterAttack()
        {
            this.weapon.Attack(this.dummy);

            const int expectedResult = 9;
            var actualResult = this.weapon.DurabilityPoints;

            Assert.That(actualResult, Is.EqualTo(expectedResult), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void AttackingWithABrokenWeapon()
        {
            this.weapon = new Axe(100, 0);

            Assert.Throws<InvalidOperationException>(() => this.weapon.Attack(this.dummy), "Attacking with broken weapon must throw InvalidOperationException!");
        }
    }
}