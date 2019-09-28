using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextBasedGame.Item.Handlers;
using TextBasedGame.Item.Models;
using TextBasedGameTests.TestConstants;

namespace TextBasedGameTests.ItemTests.HandlerTests
{
    [TestClass]
    public class InventoryHandlerTests
    {
        [TestMethod]
        public void DropItemInRoom_ShouldRemoveItemFromPlayerAndAddToRoom()
        {
            var mockItem = MockItems.MockItemFlare;
            MockCharacters.MockPlayerAlbert.CarriedItems = new List<InventoryItem>()
            {
                mockItem
            };

            InventoryHandler.DropItemInRoom(MockCharacters.MockPlayerAlbert, MockRooms.MockRoomNursery, mockItem);

            Assert.IsTrue(MockCharacters.MockPlayerAlbert.CarriedItems.Count == 0);
            Assert.IsTrue(MockRooms.MockRoomNursery.RoomItems.InventoryItems.Contains(mockItem));
        }

        [TestMethod]
        public void DropWeaponInRoom_ShouldRemoveWeaponFromPlayerAndAddToRoom()
        {
            var mockDroppedWeapon = MockCharacters.MockPlayerAlbert.WeaponItem;

            InventoryHandler.DropWeaponInRoom(MockCharacters.MockPlayerAlbert, MockRooms.MockRoomNursery);

            Assert.IsTrue(MockCharacters.MockPlayerAlbert.WeaponItem?.WeaponName == null);
            Assert.IsTrue(MockRooms.MockRoomNursery.RoomItems.WeaponItems.Contains(mockDroppedWeapon));
        }

        [TestMethod]
        public void DropWeaponAndPickupNew_ShouldSwapPlayerWeaponWithRoomWeapon()
        {
            var playerWeaponBefore = MockCharacters.MockPlayerAlbert.WeaponItem;
            var roomWeaponBefore = MockRooms.MockRoomObservatory.RoomItems.WeaponItems.First();

            InventoryHandler.DropWeaponAndPickupNew(MockCharacters.MockPlayerAlbert, MockRooms.MockRoomObservatory, roomWeaponBefore);

            Assert.AreEqual(playerWeaponBefore, MockRooms.MockRoomObservatory.RoomItems.WeaponItems.First());
            Assert.AreEqual(roomWeaponBefore, MockCharacters.MockPlayerAlbert.WeaponItem);
        }

        [TestMethod]
        public void FindAnyMatchingItemsByKeywords_ShouldReturnMatchingItem()
        {
            const string inputKeyword = "revolver";

            var inventoryItemsToSearch = new List<InventoryItem>()
            {
                MockItems.MockItemFlare
            };

            var weaponItemsToSearch = new List<WeaponItem>()
            {
                MockItems.MockItemGun
            };

            var keywordsToSearch = MockItems.MockItemGun.KeywordsForPickup;
            keywordsToSearch.AddRange(MockItems.MockItemFlare.KeywordsForPickup);

            var expectedOutput = new Items
            {
                InventoryItems = new List<InventoryItem>(),
                WeaponItems = new List<WeaponItem>()
                {
                    MockItems.MockItemGun
                }
            };

            var returnedItem = InventoryHandler.FindAnyMatchingItemsByKeywords(inputKeyword, keywordsToSearch,
                inventoryItemsToSearch, weaponItemsToSearch);

            Assert.IsTrue(expectedOutput.WeaponItems.SequenceEqual(returnedItem.WeaponItems));
        }

        [TestMethod]
        public void GetAllInventoryItemKeywords_ShouldReturnAnItemsKeywords()
        {
            var expectedKeywords = MockItems.MockItemFlare.KeywordsForPickup;
            expectedKeywords.AddRange(MockItems.MockItemRabbitsFoot.KeywordsForPickup);

            MockCharacters.MockPlayerAlbert.CarriedItems = new List<InventoryItem>()
            {
                MockItems.MockItemRabbitsFoot,
                MockItems.MockItemFlare
            };

            var returnedKeywords = InventoryHandler.GetAllInventoryItemKeywords(MockCharacters.MockPlayerAlbert);

            Assert.AreEqual(expectedKeywords.ToString(), returnedKeywords.ToString());
        }
    }
}