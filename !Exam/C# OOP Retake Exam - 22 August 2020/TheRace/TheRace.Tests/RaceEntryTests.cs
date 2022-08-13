using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver driver;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();

            this.driver = new UnitDriver("SpeedDriver", new UnitCar("Ferrari", 400, 600));
        }

        [Test]
        public void ConstructorShouldCreateRaceEntryCorrectly()
        {
            //Act
            RaceEntry raceEntryTest = new RaceEntry();

            //Assert
            Assert.IsNotNull(raceEntryTest);
            Assert.AreEqual(0, raceEntry.Counter);
        }

        [Test]
        public void AddDriverMethodShouldAddADriverToRaceEntryWhenDriverIsNotNullOrDoesNotAlreadyExistInIt()
        {
            //Act
            string result = this.raceEntry.AddDriver(this.driver);

            //Assert
            Assert.AreEqual(1, raceEntry.Counter);
            Assert.AreEqual($"Driver {this.driver.Name} added in race.", result);
        }

        [Test]
        public void AddDriverMethodShouldThrowAnExceptionWhenDriverIsNull()
        {
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.AddDriver(null);
            }, "Driver cannot be null.");
        }

        [Test]
        public void AddDriverMethodShouldThrowAnExceptionWhenDriverAlreadyExistInRaceEntry()
        {
            //Arrange
            this.raceEntry.AddDriver(this.driver);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.AddDriver(this.driver);
            }, $"Driver {this.driver.Name} is already added.");
        }

        [Test]
        public void CalculateAverageHorsePowerMethodShouldCalculateCorrectlyWhenThereAreMoreThanTwoDrivers()
        {
            //Arrange
            this.raceEntry.AddDriver(this.driver);
            this.raceEntry.AddDriver(new UnitDriver("PowerDriver", new UnitCar("Mercedes", 500, 600)));
            this.raceEntry.AddDriver(new UnitDriver("StopDriver", new UnitCar("Alfa Romeo", 300, 400)));
           
            //Act
            double result = this.raceEntry.CalculateAverageHorsePower();

            //Assert
            Assert.AreEqual(400, result);
            Assert.AreEqual(3, this.raceEntry.Counter);
        }

        [Test]
        public void CalculateAverageHorsePowerMethodShouldThrowAnExceptionWhenThereAreLessThanTwoDrivers()
        {
            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.CalculateAverageHorsePower();
            }, "The race cannot start with less than 2 participants.");

            //Arrange
            this.raceEntry.AddDriver(this.driver);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.CalculateAverageHorsePower();
            }, "The race cannot start with less than 2 participants.");
        }
    }
}