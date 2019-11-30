using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SetUpValidCtor()
        {
            Assert.DoesNotThrow(() => new Warrior("a", 1, 0));
            Assert.DoesNotThrow(() => new Warrior("a", 10, 10));
            var warrior = new Warrior("a", 10, 10);
            Assert.That(warrior.Name == "a");
            Assert.That(warrior.HP == 10);
            Assert.That(warrior.Damage == 10);
        }

        [Test]
        public void SetUpWithEmptyName()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("", 1, 0));
        }

        [Test]
        public void SetUpWithEmptyDamage()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("a", 0, 1));
        }

        [Test]
        public void SetUpWithNegativeHP()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("a", 1, -1));
        }

        [Test]
        public void AttackWithLowHP()
        {
            var warrior = new Warrior("a", 10, 29);
            var attackedWarrior= new Warrior("b", 10, 10);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(attackedWarrior));
        }

        [Test]
        public void AttackOtherWithLowHP()
        {
            var warrior = new Warrior("a", 10, 31);
            var attackedWarrior = new Warrior("b", 10, 10);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(attackedWarrior));
        }

        [Test]
        public void AttackStrongerWarrior()
        {
            var warrior = new Warrior("a", 10, 31);
            var attackedWarrior = new Warrior("b", 32, 31);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(attackedWarrior));
        }

        [Test]
        public void AttackLogic()
        {
            var warrior = new Warrior("a", 32, 51);
            var attackedWarrior = new Warrior("b", 15, 63);
            warrior.Attack(attackedWarrior);
            Assert.That(warrior.HP == 36);
            Assert.That(attackedWarrior.HP == 31);
            warrior.Attack(attackedWarrior);
            Assert.That(attackedWarrior.HP == 0);
        }
    }
}