using System;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private const string DefaultSmartPhoneName = "Test";
        private const int DefaultBatteryMaxPercentage = 100;
        private const int DefaultShopCapacity = 2;

        private Smartphone smartphone;
        private Shop shop;

        [SetUp]
        public void SetUp()
        {
            smartphone = new Smartphone(DefaultSmartPhoneName, DefaultBatteryMaxPercentage);
            shop = new Shop(DefaultShopCapacity);
        }

        [Test]
        public void SmartPhoneConstructorWorks()
        {
            Assert.True(smartphone.ModelName == DefaultSmartPhoneName &&
                        smartphone.MaximumBatteryCharge == DefaultBatteryMaxPercentage &&
                        smartphone.CurrentBateryCharge == DefaultBatteryMaxPercentage);
        }

        [Test]
        public void ShopConstructorWorks()
        {
            Assert.True(shop.Capacity == DefaultShopCapacity);
        }

        [Test]
        public void ShopCapacityThrowsForNegativeValue()
        {
            Assert.Throws<ArgumentException>(() => shop = new Shop(-1));
        }

        [Test]
        public void ShopAddIncreasesCount()
        {
            shop.Add(smartphone);
            Assert.AreEqual(shop.Count,1);
        }

        [Test]
        public void ShopAddThrowsWhenAlreadyExistsSmartPhone()
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone(DefaultSmartPhoneName, 0)));
        }

        [Test]
        public void ShopAddThrowsWhenFullCapacity()//
        {
            Smartphone smartphone1 = new Smartphone("Test", DefaultBatteryMaxPercentage);
            Smartphone smartphone2 = new Smartphone("Test2", DefaultBatteryMaxPercentage);
            shop.Add(smartphone1);
            shop.Add(smartphone2);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone2));
        }

        [Test]
        public void ShopRemoveDecreaseCount()
        {
            shop.Add(smartphone);
            shop.Remove(smartphone.ModelName);
            Assert.AreEqual(shop.Count, 0);
        }

        [Test]
        public void ShopRemoveDecreaseBattery()
        {
            shop.Add(smartphone);
            shop.TestPhone(DefaultSmartPhoneName, 40);
            Assert.AreEqual(smartphone.CurrentBateryCharge, DefaultBatteryMaxPercentage - 40);
        }

        [Test]
        public void FakePhoneTest()
        {
            Assert.Throws<InvalidOperationException>(() => shop.Remove("fake phone"));
        }

        [Test]
        public void ShopTestPhoneThrowsWhenThereIsNoExisting()
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("no model", 40));
        }

        [Test]
        public void ShopTestPhoneThrowsWhenLowBattery()
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(DefaultSmartPhoneName, DefaultBatteryMaxPercentage + 10));
        }

        [Test]
        public void ChargeRefillsBattery()
        {
            shop.Add(smartphone);
            shop.TestPhone(DefaultSmartPhoneName, 20);
            shop.ChargePhone(DefaultSmartPhoneName);
            Assert.AreEqual(smartphone.CurrentBateryCharge, DefaultBatteryMaxPercentage);
        }

        [Test]
        public void ChargePhoneThrowsExceptionWhenThereIsNoModel()
        {
            Assert.Throws<InvalidOperationException>(()=>shop.ChargePhone("no model"));
        }
    }
}