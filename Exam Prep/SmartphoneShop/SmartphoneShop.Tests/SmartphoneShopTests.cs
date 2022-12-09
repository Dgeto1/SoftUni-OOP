using System;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;
        private string modelName = "Iphone 13 Pro Max";
        private int maxCharge = 100;
        private int capacity = 3;

        [SetUp]
        public void SetUp()
        {
            smartphone = new Smartphone(modelName, maxCharge);
            shop = new Shop(capacity);
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.AreEqual(capacity, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Test_NegativeCapacity()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                shop = new Shop(-5);
            });
        }

        [Test]
        public void Test_AddSmartphone()
        {
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void Test_AddSmartphoneThatExists()
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone);
            });
        }

        [Test]
        public void Test_AddSmartphoneFullCapacity()
        {
            shop.Add(smartphone);
            shop.Add(new Smartphone("2", 1));
            shop.Add(new Smartphone("3", 1));
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("4", 1));
            });
        }

        [Test]
        public void Test_RemoveSmartphone()
        {
            shop.Add(smartphone);
            shop.Remove(smartphone.ModelName);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Test_RemoveSmartphoneWhenNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Not exist");
            });
        }

        [Test]
        public void Test_TestPhone()
        {
            shop.Add(smartphone);
            shop.TestPhone(smartphone.ModelName, 40);
            Assert.AreEqual(maxCharge-40, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void Test_TestPhoneIfNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("not exist", 20);
            });
        }

        [Test]
        public void Test_TestPhoneMoreBatteryUsage()
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(smartphone.ModelName, maxCharge+1);
            });
        }

        [Test]
        public void Test_ChargePhone()
        {
            shop.Add(smartphone);
            shop.TestPhone(smartphone.ModelName, 50);
            shop.ChargePhone(smartphone.ModelName);
            Assert.AreEqual(smartphone.CurrentBateryCharge, smartphone.MaximumBatteryCharge);
        }

        [Test]
        public void Test_ChargePhoneNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("Not exist");
            });
        }

    }
}