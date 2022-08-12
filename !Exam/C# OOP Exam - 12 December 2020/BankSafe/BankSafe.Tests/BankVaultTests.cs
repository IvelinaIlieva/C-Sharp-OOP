namespace BankSafe.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item1;
        private Item item2;

        [SetUp]
        public void Setup()
        {
            this.bankVault = new BankVault();

            this.item1 = new Item("Ivan", "1234");
            this.item2 = new Item("Petar", "8965");
        }

        [Test]
        public void AddItemMethodShouldAddItemToCellCorrectly()
        {
            //Act
            string result = this.bankVault.AddItem("A1", this.item1);
            
            //Assert
            Assert.AreEqual(1, this.bankVault.VaultCells.Values.Count(v => v != null));
            Assert.AreEqual(item1.Owner, this.bankVault.VaultCells["A1"].Owner);
            Assert.AreEqual(item1.ItemId, this.bankVault.VaultCells["A1"].ItemId);
            Assert.AreEqual(item1.ItemId, this.bankVault.VaultCells["A1"].ItemId);
            Assert.AreEqual($"Item:{this.item1.ItemId} saved successfully!", result);
        }

        [Test]
        public void AddItemMethodShouldThrowAnExceptionWhenCellDoesNotExist()
        {
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.AddItem("A10", this.item1);
            }, "Cell doesn't exists!");
        }

        [Test]
        public void AddItemMethodShouldThrowAnExceptionWhenCellIsNotNull()
        {
            //Act
            this.bankVault.AddItem("A1", this.item1);

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.AddItem("A1", this.item2);
            }, "Cell is already taken!");
        }

        [Test]
        public void AddItemMethodShouldThrowAnExceptionWhenItemWithTheSameIdIsAlreadyInTheBankVault()
        {
            //Act
            this.bankVault.AddItem("A1", this.item1);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.bankVault.AddItem("A2", this.item1);
            }, "Item is already in cell!");
        }

        [Test]
        public void RemoveItemMethodShouldRemoveItemCorrectly()
        {
            //Arrange
            this.bankVault.AddItem("A1", this.item1);

            //Act
            string result = this.bankVault.RemoveItem("A1", this.item1);

            //Assert
            Assert.AreEqual(0, this.bankVault.VaultCells.Values.Count(v => v != null));
            Assert.IsNull(this.bankVault.VaultCells["A1"]);
            Assert.AreEqual($"Remove item:{this.item1.ItemId} successfully!", result);
        }

        [Test]
        public void RemoveItemMethodShouldThrowAnExceptionWhenCellDoesNotExist()
        {
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.RemoveItem("A10", this.item1);
            }, "Cell doesn't exists!");
        }

        [Test]
        public void RemoveItemMethodShouldThrowAnExceptionWhenCellIsNullOrThereIsAnotherItemInIt()
        {
            //Act
            this.bankVault.AddItem("A1", this.item1);

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.RemoveItem("A1", this.item2);
            }, "Item in that cell doesn't exists!");

            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.RemoveItem("A2", this.item2);
            }, "Item in that cell doesn't exists!");
        }
    }
}