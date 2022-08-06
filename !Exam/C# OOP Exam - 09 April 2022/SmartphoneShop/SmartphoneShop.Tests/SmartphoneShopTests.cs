namespace SmartphoneShop.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class SmartphoneShopTests
    {
        private Shop testShop;
        private Smartphone iPhone;
        private Smartphone huawei;

        [SetUp]
        public void SetUp()
        {
            this.testShop = new Shop(2);

            this.iPhone = new Smartphone("IPone", 100);
            this.huawei = new Smartphone("Huawei", 10);
        }
        
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void ConstructorShouldCreateProperlyAShop(int capacity)
        {
            //Arrange
            Shop shop = new Shop(capacity);

            //Act
            int expectedCapacity = capacity;
            int actualCapacity = shop.Capacity;

            int expectedCount = 0;
            int actualCount = shop.Count;

            //Assert
            Assert.AreEqual(expectedCapacity, actualCapacity);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void CapacitySetterShouldThrowAnExceptionWithNegativeValue(int capacity)
        {
            //Act and Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(capacity);
            }, "Invalid capacity.");
        }

        [Test]
        public void AddMethodShouldAddPhonesIfThereIsEnoughSpaceInShopAndPhonesDoesNotExist()
        {
            //Act
            this.testShop.Add(this.iPhone);
            this.testShop.Add(this.huawei);

            int expectedCount = 2;
            int actualCount = testShop.Count;
            
            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionIfThereIsNotEnoughSpaceInShop()
        {
            //Act
            this.testShop.Add(this.iPhone);
            this.testShop.Add(this.huawei);
            Smartphone samsung = new Smartphone("Samsung", 50);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testShop.Add(samsung);
            }, "The shop is full.");
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionWhenThePhoneAlreadyExist()
        {
            //Act
            this.testShop.Add(this.iPhone);
            
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testShop.Add(this.iPhone);
            }, $"The phone model {this.iPhone.ModelName} already exist.");
        }

        [Test]
        public void RemoveMethodShouldRemoveProperlyWhenThePhoneAlreadyExist()
        {
            //Arrange
            this.testShop.Add(this.iPhone);
            this.testShop.Add(this.huawei);

            //Act
            this.testShop.Remove(this.iPhone.ModelName);

            int expectedCount = 1;
            int actualCount = testShop.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveMethodShouldThrowAnExceptionWhenThePhoneDoesNotExist()
        {
            //Act
            this.testShop.Add(this.iPhone);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testShop.Remove(this.huawei.ModelName);
            }, $"The phone model {this.huawei.ModelName} doesn't exist.");
        }

        [TestCase(90)]
        [TestCase(99)]
        public void TestPhoneMethodShouldTestProperlyWhenThePhoneAlreadyExistAndBatteryUsageIsLowerThanCurrentBattery(int batteryUsage)
        {
            //Arrange
            this.testShop.Add(this.iPhone);
            
            //Act
            this.testShop.TestPhone(this.iPhone.ModelName, batteryUsage);

            int expectedBatteryCharge = this.iPhone.MaximumBatteryCharge - batteryUsage;
            int actualBatteryCharge = this.iPhone.CurrentBateryCharge;

            //Assert
            Assert.AreEqual(expectedBatteryCharge, actualBatteryCharge);
        }

        [Test]
        public void TestPhoneMethodShouldThrowAnExceptionWhenThePhoneDoesNotExist()
        {
            //Act
            this.testShop.Add(this.iPhone);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testShop.TestPhone(this.huawei.ModelName, 5);
            }, $"The phone model {this.huawei.ModelName} doesn't exist.");
        }

        [Test]
        public void TestPhoneMethodShouldThrowAnExceptionWhenTheBatteryUsageIsHigherThanCurrentBattery()
        {
            //Act
            this.testShop.Add(this.huawei);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testShop.TestPhone(this.huawei.ModelName, 25);
            }, $"The phone model {this.huawei.ModelName} is low on batery.");
        }

        [Test]
        public void ChargePhoneMethodShouldChargeProperlyWhenThePhoneAlreadyExist()
        {
            //Arrange
            this.testShop.Add(this.iPhone);

            //Act
            this.testShop.TestPhone(this.iPhone.ModelName, 40);
            this.testShop.ChargePhone(this.iPhone.ModelName);

            int expectedBattery = this.iPhone.MaximumBatteryCharge;
            int actualBattery = this.iPhone.CurrentBateryCharge;

            //Assert
            Assert.AreEqual(expectedBattery, actualBattery);
        }

        [Test]
        public void ChargePhoneMethodShouldThrowAnExceptionWhenThePhoneDoesNotExist()
        {
           //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testShop.ChargePhone(this.huawei.ModelName);
            }, $"The phone model {this.huawei.ModelName} doesn't exist.");
        }
    }
}