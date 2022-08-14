namespace PlanetWars.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml.Linq;

    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Planet planet;
            private Weapon weapon;
            private Weapon weapon2;

            [SetUp]
            public void SetUp()
            {
                this.planet = new Planet("Earth", 1000);

                this.weapon = new Weapon("Bomb", 10, 100);
                this.weapon2 = new Weapon("Gun", 100, 200);
            }

            [TestCase("Gun", 1, 5)]
            [TestCase("", 100, 0)]
            [TestCase(" ", 0, -5)]
            public void WeaponConstructorShouldCreateAWeaponCorrectly(string name, double price, int destructionLevel)
            {
                //Act
                Weapon testWeapon = new Weapon(name, price, destructionLevel);

                //Assert
                Assert.IsNotNull(testWeapon);
                Assert.AreEqual(name, testWeapon.Name);
                Assert.AreEqual(price, testWeapon.Price);
                Assert.AreEqual(destructionLevel, testWeapon.DestructionLevel);
            }

            [TestCase("Gun", -11, 5)]
            [TestCase("", -1, 0)]
            public void WeaponPriceSetterShouldThrowAnExceptionWithNegativeValue(string name, double price, int destructionLevel)
            {
                //Act
                //Assert
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon testWeapon = new Weapon(name, price, destructionLevel);
                }, "Price cannot be negative.");
            }

            [TestCase("Gun", 11, 5)]
            [TestCase("", 1, 0)]
            public void IncreaseDestructionLevelMethodShouldWorkCorrectly(string name, double price, int destructionLevel)
            {
                //Arrange
                Weapon testWeapon = new Weapon(name, price, destructionLevel);

                //Act
                testWeapon.IncreaseDestructionLevel();

                //Assert
                Assert.AreEqual(destructionLevel + 1, testWeapon.DestructionLevel);

                //Act
                testWeapon.IncreaseDestructionLevel();

                //Assert
                Assert.AreEqual(destructionLevel + 2, testWeapon.DestructionLevel);
            }

            [TestCase("", 1, 10)]
            [TestCase("", 1, 11)]
            public void IsNuclearMethodShouldReturnTrueWhenDestructionLevelIsTenOrMore(string name, double price, int destructionLevel)
            {
                //Arrange
                Weapon testWeapon = new Weapon(name, price, destructionLevel);

                //Act
                //Assert
                Assert.IsTrue(testWeapon.IsNuclear);
            }

            [TestCase("", 1, 0)]
            [TestCase("", 1, 9)]
            [TestCase("", 1, -9)]
            public void IsNuclearMethodShouldReturnFalseWhenDestructionLevelIsLowerByTen(string name, double price, int destructionLevel)
            {
                //Arrange
                Weapon testWeapon = new Weapon(name, price, destructionLevel);

                //Act
                //Assert
                Assert.IsFalse(testWeapon.IsNuclear);
            }

            [TestCase("Mars", 10.5)]
            [TestCase("Mars", 1)]
            public void PlanetConstructorShouldWorkProperly(string name, double budget)
            {
                //Act
                Planet testPlanet = new Planet(name, budget);

                //Assert
                Assert.IsNotNull(testPlanet);
                Assert.AreEqual(name, testPlanet.Name);
                Assert.AreEqual(budget, testPlanet.Budget);
                Assert.AreEqual(0, testPlanet.Weapons.Count);
            }

            [TestCase("", 10.5)]
            [TestCase(null, 1)]
            public void NameSetterShouldThrowAnExceptionWhenNameIsNullOrEmpty(string name, double budget)
            {
                //Act
                //Assert
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet testPlanet = new Planet(name, budget);
                }, "Invalid planet Name");
            }

            [TestCase("Mars", -1)]
            [TestCase("Mars", -100)]
            public void BudgetSetterShouldThrowAnExceptionWhenBudgetIsNegative(string name, double budget)
            {
                //Act
                //Assert
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet testPlanet = new Planet(name, budget);
                }, "Budget cannot drop below Zero!");
            }

            [Test]
            public void MilitaryPowerRatioMethodShouldCalculateCorrectly()
            {
                //Arrange
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                //Act
                double power = planet.MilitaryPowerRatio;

                //Assert
                Assert.AreEqual(300, power);
            }

            [TestCase(100)]
            [TestCase(0)]
            public void ProfitMethodShouldCalculateCorrectly(double amount)
            {
                //Arrange
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                //Act
                double expectedBudget = planet.Budget + amount;
                planet.Profit(amount);
                double actualBudget = planet.Budget;

                //Assert
                Assert.AreEqual(expectedBudget, actualBudget);
            }

            [TestCase(1000)]
            [TestCase(0)]
            [TestCase(100)]
            public void SpendFundsMethodShouldCalculateCorrectlyWhenAmountIsLessOrEqualToBudget(double amount)
            {
                //Act
                double expectedBudget = planet.Budget - amount;
                planet.SpendFunds(amount);
                double actualBudget = planet.Budget;

                //Assert
                Assert.AreEqual(expectedBudget, actualBudget);
            }

            [TestCase(1001)]
            [TestCase(2000)]
            public void SpendFundsMethodShouldThrowAnExceptionWhenAmountIsMoreThanBudget(double amount)
            {
                //Act
                //Assert
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(amount);
                }, "Not enough funds to finalize the deal.");
            }

            [Test]
            public void AddWeaponMethodShouldIncreaseCountOfWeaponsOnPlanet()
            {
                //Arrange
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                //Act
                //Assert
                Assert.AreEqual(2, planet.Weapons.Count);
                CollectionAssert.AreEqual(new List<Weapon>() { weapon, weapon2 }, planet.Weapons);
            }

            [TestCase("Gun")]
            [TestCase("Bomb")]
            public void AddWeaponMethodShouldThrowAnExceptionWhenWeaponAlreadyExistOnPlanet(string name)
            {
                //Arrange
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                //Act
                //Assert
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(new Weapon(name, 0, 1));
                }, $"There is already a {name} weapon.");
            }

            [Test]
            public void RemoveWeaponMethodShouldDecreaseCountOfWeaponsOnPlanet()
            {
                //Arrange
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                //Act
                planet.RemoveWeapon(weapon.Name);
                //Assert
                Assert.AreEqual(1, planet.Weapons.Count);
                CollectionAssert.AreEqual(new List<Weapon>() { weapon2 }, planet.Weapons);

                //Act
                planet.RemoveWeapon(weapon2.Name);
                //Assert
                Assert.AreEqual(0, planet.Weapons.Count);
                CollectionAssert.AreEqual(new List<Weapon>(), planet.Weapons);
            }

            [Test]
            public void UpgradeWeaponMethodShouldIncreaseDestructionLevelOfTheWeaponIfItExistOnPlanet()
            {
                //Arrange
                planet.AddWeapon(weapon);

                //Act
                int expectedDestructionLevel = weapon.DestructionLevel + 1;
                planet.UpgradeWeapon(weapon.Name);
                int actualDestructionLevel = weapon.DestructionLevel;

                //Assert
                Assert.AreEqual(expectedDestructionLevel, actualDestructionLevel);
            }

            [Test]
            public void UpgradeWeaponMethodShouldThrowAnExceptionWhenTheWeaponDoesNotExistOnPlanet()
            {
                //Arrange
                planet.AddWeapon(weapon);

                //Act
                //Assert
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon(weapon2.Name);
                }, $"{weapon2.Name} does not exist in the weapon repository of {planet.Name}");
            }

            [Test]
            public void DestructOpponentMethodShouldWorkCorrectlyWhenMilitaryPowerRatioIsBiggerThanOpponents()
            {
                //Arrange
                Planet testPlanet = new Planet("Mars", 100);
                planet.AddWeapon(weapon2);

                //Act
                string result = planet.DestructOpponent(testPlanet);

                //Assert
                Assert.AreEqual($"{testPlanet.Name} is destructed!", result);

                //Arrange
                testPlanet.AddWeapon(weapon);

                //Act
                string result2 = planet.DestructOpponent(testPlanet);

                //Assert
                Assert.AreEqual($"{testPlanet.Name} is destructed!", result2);
            }

            [Test]
            public void DestructOpponentMethodShouldThrowAnExceptionWhenMilitaryPowerRatioIsLowerOrEqualToOpponents()
            {
                //Arrange
                Planet testPlanet = new Planet("Mars", 100);
                planet.AddWeapon(weapon);
                testPlanet.AddWeapon(weapon2);

                //Act
                //Assert
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(testPlanet);
                }, $"{testPlanet.Name} is too strong to declare war to!");
            }
        }
    }
}
