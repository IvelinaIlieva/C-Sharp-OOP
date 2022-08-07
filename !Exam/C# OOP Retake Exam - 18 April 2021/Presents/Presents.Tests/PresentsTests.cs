namespace Presents.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;
        private Present present1;
        private Present present2;

        [SetUp]
        public void SetUp()
        {
            this.bag = new Bag();

            this.present1 = new Present("Doll", 25.5);
            this.present2 = new Present("Ball", 3);
        }

        [Test]
        public void ConstructorShouldCreateABagCorrectly()
        {
            //Act
            Bag bag1 = new Bag();

            //Assert
            Assert.IsNotNull(bag1);
        }

        [Test]
        public void CreateMethodShouldAddProperlyPresentsInBag()
        {
            //Act
            string actualResult = this.bag.Create(this.present1);

            int expectedCount = 1;
            int actualCount = this.bag.GetPresents().Count;

            List<Present> expectedList = new List<Present> { this.present1 };
            List<Present> actualList = this.bag.GetPresents().ToList();

            string expectedResult = $"Successfully added present {this.present1.Name}.";

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedCount, actualCount);
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [Test]
        public void CreateMethodShouldThrowAnExceptionWhenPresentIsNull()
        {
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(
                () => this.bag.Create(null));
        }

        [Test]
        public void CreateMethodShouldThrowAnExceptionWhenPresentAlreadyExistInTheBag()
        {
            //Arrange
            this.bag.Create(this.present1);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(
                () => this.bag.Create(this.present1));
        }

        [Test]
        public void RemoveMethodShouldReturnCorrectlyTrueOrFalseWhenRemoveAPresent()
        {
            //Arrange
            this.bag.Create(this.present1);

            //Assert
            Assert.IsTrue(this.bag.Remove(present1));
            Assert.AreEqual(0, this.bag.GetPresents().Count);
            Assert.IsFalse(this.bag.Remove(present2));
            Assert.IsFalse(this.bag.Remove(present1));
        }

        [Test]
        public void GetPresentWithLeastMagicMethodShouldReturnCorrectlyPresent()
        {
            //Arrange
            this.bag.Create(this.present1);
            this.bag.Create(this.present2);

            Present actualPresent = this.bag.GetPresentWithLeastMagic();
            Present expectedPresent = this.present2;

            //Assert
            Assert.AreEqual(expectedPresent.Name, actualPresent.Name);
            Assert.AreEqual(expectedPresent.Magic, actualPresent.Magic);
        }

        [TestCase("Doll")]
        public void GetPresentMethodShouldReturnCorrectlyPresentWithGivenNameIfItExists(string name)
        {
            //Arrange
            this.bag.Create(this.present1);
            this.bag.Create(this.present2);

            Present actualPresent = this.bag.GetPresent(name);
            Present expectedPresent = this.present1;

            //Assert
            Assert.AreEqual(expectedPresent.Name, actualPresent.Name);
            Assert.AreEqual(expectedPresent.Magic, actualPresent.Magic);
        }

        [TestCase("Toy")]
        public void GetPresentMethodShouldReturnNullPresentWithGivenNameIfItDoesNotExist(string name)
        {
            //Arrange
            this.bag.Create(this.present1);
            this.bag.Create(this.present2);

            Present actualPresent = this.bag.GetPresent(name);
            
            //Assert
            Assert.IsNull(actualPresent);
        }
    }
}
