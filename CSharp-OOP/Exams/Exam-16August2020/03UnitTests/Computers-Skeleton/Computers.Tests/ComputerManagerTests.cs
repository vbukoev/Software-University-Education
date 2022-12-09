using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        private const string computerManufacturer = "manufacturer";
        private const string computerModel = "model";
        private const decimal price = 1000m;
        private Computer computer;
        private ComputerManager computerManager;
        [SetUp]
        public void Setup()
        {
            computer = new Computer(computerManufacturer, computerModel, price);
            computerManager = new ComputerManager();
            computerManager.AddComputer(computer);
        }

        [Test]
        public void ValidateNullValueTest()
        {
            Assert.Throws<ArgumentNullException>(()=> computerManager.AddComputer(null));
            Assert.Throws<ArgumentNullException>(()=> computerManager.GetComputer(null, computerModel));
            Assert.Throws<ArgumentNullException>(()=> computerManager.GetComputer(computerManufacturer, null));
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void AddComputerAddsObjectsCorrectly()
        {
            Assert.AreEqual(computerManager.Count,1 );
            Assert.AreEqual(computerManager.Computers.Count,1 );
            Assert.AreEqual(computerManager.Computers.First(), computer);
        }

        [Test]
        public void AddComputerThrowsForAlreadyAddedComputer()
        {
            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
        }

        [Test]
        public void RemoveComputerRemovesCorrectly()
        {
            Computer computerToBeRemoved = computerManager.RemoveComputer(computerManufacturer, computerModel);
            Assert.AreEqual(computer, computerToBeRemoved);
            Assert.AreEqual(computerManager.Count, 0);
            Assert.AreEqual(computerManager.Computers.Count, 0);
        }

        [Test]
        public void RemoveComputerThrowsWhenThereIsNotAComputerParameter()
        {
            Assert.Throws<ArgumentException>(()=>computerManager.RemoveComputer(computerManufacturer, "testModel"));
            Assert.Throws<ArgumentException>(()=>computerManager.RemoveComputer("name1", computerModel));
        }

        [Test]
        public void GetComputerReturnsCorrectObject()
        {
            Assert.AreEqual(computerManager.GetComputer(computerManufacturer, computerModel), computer);
        }

        [Test]
        public void GetComputerThrowsWhenNotExistingComputer()
        {
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("no manufacturer", "no model"));
        }

        [Test]
        public void GetComputersByManufacturerReturnsCorrectly()
        {
            var computer2 = new Computer(computerManufacturer, "testModel", 1500);
            computerManager.AddComputer(computer2);
            List<Computer> computers = new List<Computer>(){computer, computer2}; 
            Assert.AreEqual(computerManager.GetComputersByManufacturer(computerManufacturer).ToList(), computers);
        }

        [Test]
        public void GetComputersByManufacturerReturnsEmptyCollection()
        {
            computerManager.AddComputer(new Computer("new1", "model2", 1500));
            computerManager.AddComputer(new Computer("new2", "model3", 1700));
            Assert.IsEmpty(computerManager.GetComputersByManufacturer("nobody").ToList());
        }
    }
}