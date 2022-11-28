using System.ComponentModel;

namespace Robots.Tests
{
    
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class RobotsTests
    {
        private string name = "name";
        private int battery = 50;
        private int capacity = 2;

        private Robot robot;
        private RobotManager manager;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot(name, battery);
            manager = new RobotManager(capacity);
            manager.Add(robot);
        }

        [Test]
        public void TestRobotConstructor()
        {
            Assert.AreEqual(robot.Name, name);
            Assert.AreEqual(robot.Battery, battery);
            Assert.AreEqual(robot.MaximumBattery, battery);
        }

        [Test]
        public void TestRobotManagerConstructor()
        {
            Assert.AreEqual(manager.Capacity, capacity);
        }

        [TestCase(-1)]
        public void CapacityThrowsWhenNegative(int cap)
        {
            Assert.Throws<ArgumentException>(() => manager = new RobotManager(cap));
        }

        [Test]
        public void AddIncreasesCount()
        {
            Assert.AreEqual(manager.Count,1);
        }

        [Test]
        public void AddThrowsWhenAlreadyExistingRobot()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Add(new Robot(robot.Name, 15)));
        }

        [Test]
        public void AddThrowsWhenNotEnoughCapacity()
        {
            manager.Add(new Robot("robot2", 10));
            Assert.Throws<InvalidOperationException>(() => manager.Add(new Robot("robot3", 20)));
        }

        [Test]
        public void RemoveDecreasesCount()
        {
            manager.Remove(robot.Name);
            Assert.AreEqual(manager.Count,0);
        }

        [Test]
        public void RemoveThrowsForMissingRobot()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Remove(" name2"));
        }

        [TestCase(10)]
        public void WorkDecreaseBattery(int batteryUsage)
        {
            manager.Work(robot.Name, "working...", batteryUsage);
            Assert.AreEqual(robot.Battery, battery - batteryUsage);
        }

        [Test]
        public void WorkThrowsForNoRobot()
        {
            Assert.Throws<InvalidOperationException>(()=> manager.Work("name2", "working on myself", 10));
        }

        [Test]
        public void WorkThrowsWhenNoBattery()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Work("name", "working on myself", battery + 10));
        }

        [Test]
        public void ChargeChargesToFull()
        {
            manager.Work(robot.Name, "working", 20);
            manager.Charge(robot.Name);
            Assert.AreEqual(robot.Battery, battery);
        }

        [Test]
        public void ChargeThrowsWhenNoRobot()
        {
            Assert.Throws<InvalidOperationException>(() => manager.Charge("name12"));
        }
    }
}
