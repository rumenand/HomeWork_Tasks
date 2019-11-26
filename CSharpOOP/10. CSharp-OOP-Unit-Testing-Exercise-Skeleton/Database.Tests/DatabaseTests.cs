using NUnit.Framework;
using System;

namespace DatabaseTests
{
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void Setup()
        {
            database = new Database(new int[] { 1, 2, 3 });
            
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
            for (int i = 0; i < maxCapacity-3; i++)
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
            database.Add(1);
            database.Remove();
            Assert.That(database.Count == 3);
        }      

        [Test]
        public void TestFetch()
        {
            var copy = database.Fetch();
            Assert.AreEqual(new int[3] {1,2,3}, copy);            
        }
    }
}