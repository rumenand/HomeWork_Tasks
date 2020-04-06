using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("a", 3, 4.01002)]
        [TestCase("", 2, 6)]
        [TestCase(null, 4, 3.221)]
        [TestCase(null, -1, -1)]
        public void CreateMotorcycle(string model, int horsePower, double cubicCentimeters)
        {            
            Assert.DoesNotThrow(()=> new UnitMotorcycle(model, horsePower, cubicCentimeters));
        }

        [Test]
        public void createRiderFunction()
        {
            var moto = new UnitMotorcycle("z", 2, 3);
            Assert.That(moto.Model == "z");
            Assert.That(moto.HorsePower == 2);
            Assert.That(moto.CubicCentimeters == 3);
            Assert.DoesNotThrow(() => new UnitRider("a", moto));
            Assert.Throws<ArgumentNullException>(() => new UnitRider(null, moto));            
        }

        [Test]
        public void createEmptyRace()
        {
            Assert.DoesNotThrow(() => new RaceEntry());
            var race = new RaceEntry();
            Assert.That(race.Counter == 0);
        }

        [Test]
        [TestCase("a", 3, 4.01002)]
        [TestCase("", 2, 6)]
        public void addindRidersToRaceProtectionTests(string model, int horsePower, double cubicCentimeters)
        {
            var race = new RaceEntry();
            var moto = new UnitMotorcycle(model, horsePower, cubicCentimeters);
            var rider = new UnitRider("a", moto);
            Assert.That(rider.Motorcycle == moto);
            var sameRider = new UnitRider("a", moto);
            Assert.Throws<InvalidOperationException>(() => race.AddRider(null));
            Assert.DoesNotThrow(() => race.AddRider(rider));
            Assert.Throws<InvalidOperationException>(() => race.AddRider(sameRider));
        }

        [Test]
        public void RaceEntryCalculateAverageHorsePower()
        {
            var race = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
            var moto = new UnitMotorcycle("a",4,4);
            var rider = new UnitRider("a", moto);
            var nextRider = new UnitRider("b", moto);
            race.AddRider(rider);
            race.AddRider(nextRider);
            Assert.That(race.Counter == 2);
            Assert.That(race.CalculateAverageHorsePower() == 4);
        }
    }
}