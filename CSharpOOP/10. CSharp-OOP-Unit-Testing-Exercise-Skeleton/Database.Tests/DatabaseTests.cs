using System;
using NUnit.Framework;

namespace Database.Tests
{
    public class DatabaseTests
    {
        private global::Database.Database database;
        [SetUp]
        public void Setup()
        {
            database = new global::Database.Database (new int[] { 1, 2, 3 });            
        }

        [Test]
        public void TestInitialCapacity()
        {
            Assert.That(database.Count == 3);
        }
               
        [Test]
        public void TestMaxCapacity()
        {
            int maxCapacity = 16;
            var initialCount = database.Count;
            for (int i = 0; i < maxCapacity-initialCount; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void TestAddFunctionality()
        {
            database.Add(1);
            Assert.That(database.Count == 4);
        }

        [Test]
        public void TestRemoveFunctionality()
        {
            database.Remove();
            Assert.That(database.Count == 2);
        }      

        [Test]
        public void RemovingFromEmptyCollection()
        {
            var emptyData = new global::Database.Database();
            Assert.Throws<InvalidOperationException>(() => emptyData.Remove());
        }

        [Test]
        public void TestFetch()
        {
            var copy = database.Fetch();
            Assert.AreEqual(new int[] {1,2,3}, copy);            
        }


    }
}