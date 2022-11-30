using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;
    [TestFixture]
    public class AquariumsTests
    {
        private const string fishName = "fishname";
        private const string aquariumName = "aquariumname";
        private const int capacity = 2;
        private Fish fish;
        private Aquarium aquarium;
        [SetUp]
        public void SetUp()
        {
            fish = new Fish(fishName);
            aquarium = new Aquarium(aquariumName, capacity);
            aquarium.Add(fish);
        }

        [Test]
        public void FishConstructorWorksProperly()
        {
            Assert.AreEqual(fish.Name, fishName);
            Assert.AreEqual(fish.Available, true);
        }

        [Test]
        public void AquariumConstructorWorksProperly()
        {
            aquarium = new Aquarium(aquariumName, capacity);
            Assert.AreEqual(aquarium.Name, aquariumName);
            Assert.AreEqual(aquarium.Capacity, capacity);
            Assert.AreEqual(aquarium.Count, 0);
        }

        [TestCase (null)]
        [TestCase ("")]
        public void NameThrowsForNullOrEmpty(string value)
        {
            Assert.Throws<ArgumentNullException>(()=> aquarium = new Aquarium(value, capacity));
        }

        [Test]
        public void CapacityThrowsWhenNegative()
        {
            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium(aquariumName, -1));
        }

        [Test]
        public void AddIncreasesCountProperly()
        {
            Assert.AreEqual(aquarium.Count, 1);
        }

        [Test]
        public void AddThrowsWhenFull()
        {
            Assert.Throws<InvalidOperationException>(() => new Aquarium(aquariumName, 0).Add(fish));
        }

        [Test]
        public void RemoveDecreasesCount()
        {
            aquarium.RemoveFish(fish.Name);
            Assert.AreEqual(aquarium.Count, 0);
        }

        [Test]
        public void RemoveThrowsForNull()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("fake"));
        }

        [Test]
        public void SellFishThrowsForNull()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("fake"));
        }

       [Test]
        public void SellFishSetIsAvailableToFalse()
        {
            Fish soldFish = aquarium.SellFish(fish.Name);
            Assert.AreEqual(fish.Available, false);
            Assert.AreEqual(fish, soldFish); // may not work properly
        }

        [Test]
        public void ReportCorrectlyReports()
        {
            Fish fish1 = new Fish("nam2");
            aquarium.Add(fish1);

            List<Fish> fishes = new List<Fish>() {fish, fish1};

            Assert.AreEqual(aquarium.Report(), $"Fish available at {this.aquarium.Name}: {(string.Join(", ", fishes.Select(x=>x.Name)))}");
        }
       
    }
}
