using NUnit.Framework;
using System.Linq;
using System;
using FightingArena;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SetUpCtor()
        {
            var arena = new Arena();
            Assert.That(arena.Count == 0);
            Assert.That(arena.Warriors.Count ==0);
        }

        [Test]
        public void EnrollWarrior()
        {
            var arena = new Arena();
            var warrior = new Warrior("a", 10, 10);
            arena.Enroll(warrior);
            Assert.That(arena.Count == 1);
            Assert.That(arena.Warriors.FirstOrDefault().Name == "a");           
        }
        [Test]
        public void AddSameWarrior()
        {
            var arena = new Arena();
            var warrior = new Warrior("a", 10, 10);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("a",1098,129)));
            Assert.That(arena.Count == 1);
        }

        [Test]
        public void AttackFunctionallity()
        {
            var arena = new Arena();
            arena.Enroll(new Warrior("a", 10, 60));
            arena.Enroll(new Warrior("b", 10, 70));
            Assert.Throws<InvalidOperationException>(() => arena.Fight("a", "c"));
            Assert.Throws<InvalidOperationException>(() => arena.Fight("c", "a"));
            Assert.DoesNotThrow(() => arena.Fight("a", "b"));
            var firstWarrior = arena.Warriors.Where(x => x.Name == "a").FirstOrDefault();
            var secondWarrior = arena.Warriors.Where(x => x.Name == "b").FirstOrDefault();
            Assert.That(firstWarrior.HP == 50);
            Assert.That(secondWarrior.HP == 60);
            
        }
    }
}
