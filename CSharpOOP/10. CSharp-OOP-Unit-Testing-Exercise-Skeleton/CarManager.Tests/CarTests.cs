using System;
using NUnit.Framework;
using  CarManager;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestValidCtor()
        {
            Assert.DoesNotThrow( () => new Car("bmw", "z3", 10.3d, 55.8d));
        }

        [Test]
        public void TestEmptyMake()
        {
            Assert.Throws<ArgumentException>(()=>new Car("","1",1,1));
        }

        [Test]

        public void TestEmptyModel()
        {
            Assert.Throws<ArgumentException>(() => new Car("b", "", 1, 1));
        }

        [Test]

        public void TestZeroConsumptionInstance()
        {
            Assert.Throws<ArgumentException>(() =>new Car("b", "z", 0, 8));
        }

    }
}