using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private const string itemOwner = "Owner";
        private const string itemID = "itemId";
        private const string cellID = "A2";

        private Item item;
        private BankVault bankVault;
        private string addItemString;

        [SetUp]
        public void Setup()
        {
            item = new Item(itemOwner, itemID);
            bankVault = new BankVault();
            addItemString = bankVault.AddItem(cellID, item);
        }

        [Test]
        public void AddItemWorksCorrectly()
        {
            Assert.AreSame(bankVault.VaultCells[cellID], item);

            Assert.AreEqual($"Item:{item.ItemId} saved successfully!", addItemString);
        }

        [Test]
        public void AddItemThrowsForNull()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A115", new Item("name of Owner", " id")));
        }

        [Test]
        public void AddItemThrowsForAlreadyAddedCell()
        {
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("B4", item));
        }

        [Test]
        public void RemoveItemRemovesCellFromTheDictionaryCorrectly()
        {
            Assert.AreEqual($"Remove item:{item.ItemId} successfully!", bankVault.RemoveItem(cellID, item));

            Assert.AreEqual(bankVault.VaultCells[cellID], null);
        }

        [Test]
        public void RemoveItemThrowsForNull()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A115", new Item("name of Owner", " id")));
        }

        [Test]
        public void RemoveItemThrowsForAlreadyAddedCell()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("B4", item));
        }
    }
}