using System;
using NUnit.Framework;

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
            Assert.DoesNotThrow(() => new Car("bmw", "z3", 1, 1));
            Car car = new Car("b","s",150.8d,2.094d);
            Assert.That(car.Make == "b");
            Assert.That(car.Model == "s");
            Assert.That(car.FuelConsumption == 150.8d);
            Assert.That(car.FuelCapacity == 2.094d);
            Assert.That(car.FuelAmount ==0);
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

        [Test]
        public void TestForNegativeFuelCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Car("b", "z", 1, 0));
        }

        [Test]
        public void TestRefillAbilities()
        {
            Car car = new Car("b", "s", 1d, 30d);
            car.Refuel(20.5d);
            Assert.That(car.FuelAmount == 20.5d);
            Assert.That(car.FuelCapacity == 30d);
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
            Assert.Throws<ArgumentException>(() => car.Refuel(-1));
            car.Refuel(40.8d);
            Assert.That(car.FuelAmount == 30d);
        }

        [Test]
        public void TestDriveAbilities()
        {
            Car car = new Car("b", "s", 2, 20);
            car.Refuel(3);
            car.Drive(100);
            Assert.That(car.FuelAmount ==1);
            Assert.Throws<InvalidOperationException>(() => car.Drive((100)));
        }
    }
}