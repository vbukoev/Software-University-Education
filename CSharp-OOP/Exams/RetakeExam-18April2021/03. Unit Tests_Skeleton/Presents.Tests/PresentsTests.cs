using System;
using System.Linq;

namespace Presents.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private const string name = "name";
        private const double magic = 10;

        private Present present;
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            present = new Present(name, magic);
            bag = new Bag();
            bag.Create(present);
        }

        [Test]
        public void PresentConstructorWorks()
        {
            Assert.AreEqual(present.Name, name);
            Assert.AreEqual(present.Magic, magic);
        }

        [Test]
        public void CreateAddsObjectToTheCollection()
        {
            Assert.AreEqual(bag.GetPresents().Count,1);
            Assert.AreSame(bag.GetPresents().First(), present);
        }

        [Test]
        public void CreateThrowsWhenNull()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void CreateThrowsForAlreadyExisting()
        {
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void RemoveRemovesCorrectly()
        {
            bag.Remove(present);
            Assert.AreEqual(bag.GetPresents().Count, 0);
            Assert.IsTrue(bag.GetPresent(present.Name)==null);
        }

        [Test]
        public void GetPresentWithLeastMagicReturnsCorrectValue()
        {
            Present present1 = new Present("name1", 20);
            bag.Create(present1);
            Assert.AreEqual(Math.Min(present.Magic, present1.Magic), bag.GetPresentWithLeastMagic().Magic);
        }

        [Test]
        public void GetPresentReturnsCorrectValue()
        {
            Assert.AreSame(bag.GetPresent(present.Name), present);
            Assert.AreSame(bag.GetPresent("present fake name"), null);
        }
    }
}