using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Test1()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints == 9, "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void Test2()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 0);
            try
            {
                axe.Attack(dummy);
            }
            catch
            { }

            Assert.That(axe.DurabilityPoints == 0, "Weapon isn't broken");
        }
    }
}