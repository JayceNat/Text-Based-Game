using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextBasedGame.Character.Models;
using TextBasedGame.Item.Handlers;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Models;
using TextBasedGameTests.TestConstants;

namespace TextBasedGameTests.CharacterTests.HandlerTests
{
    [TestClass]
    public class AttributeHandlerTests
    {
        public static Character MockPlayer = MockCharacters.MockPlayerAlbert;
        public static Room MockRoomNursery = MockRooms.MockRoomNursery;
        public static Room MockRoomObservatory = MockRooms.MockRoomObservatory;
        public static InventoryItem MockItem = MockPlayer.CarriedItems.First();
        public static WeaponItem MockWeapon = MockRoomObservatory.RoomItems.WeaponItems.First();

        [TestMethod]
        public void DropItemInRoom_ShouldRemoveItemFromPlayerAndAddToRoom()
        {
            InventoryHandler.DropItemInRoom(MockPlayer, MockRoomNursery, MockItem);

            Assert.IsTrue(MockPlayer.CarriedItems.Count == 0);
            Assert.IsTrue(MockRoomNursery.RoomItems.InventoryItems.Contains(MockItem));
        }

        [TestMethod]
        public void DropWeaponInRoom_ShouldRemoveWeaponFromPlayerAndAddToRoom()
        {
            var mockDroppedWeapon = MockPlayer.WeaponItem;

            InventoryHandler.DropWeaponInRoom(MockPlayer, MockRoomNursery);

            Assert.IsTrue(MockPlayer.WeaponItem?.WeaponName == null);
            Assert.IsTrue(MockRoomNursery.RoomItems.WeaponItems.Contains(mockDroppedWeapon));
        }

        [TestMethod]
        public void DropWeaponAndPickupNew_ShouldSwapPlayerWeaponWithRoomWeapon()
        {
            var playerWeaponBefore = MockPlayer.WeaponItem;
            var roomWeaponBefore = MockRoomObservatory.RoomItems.WeaponItems.First();

            InventoryHandler.DropWeaponAndPickupNew(MockPlayer, MockRoomObservatory, roomWeaponBefore);

            Assert.AreEqual(playerWeaponBefore, MockRoomObservatory.RoomItems.WeaponItems.First());
            Assert.AreEqual(roomWeaponBefore, MockPlayer.WeaponItem);
        }

        [TestMethod]
        public void FindAnyMatchingItemsByKeywords_ShouldReturnMatchingItem()
        {
            var inputKeyword = "revolver";
            var itemKeywords = MockWeapon.KeywordsForPickup;
            var expectedItem = MockWeapon;

            var returnedItem = InventoryHandler.FindAnyMatchingItemsByKeywords(inputKeyword, itemKeywords, new List<InventoryItem>(), MockRoomObservatory.RoomItems.WeaponItems);

            Assert.AreEqual(expectedItem, returnedItem.WeaponItems.First());
        }

        [TestMethod]
        public void GetAllInventoryItemKeywords_ShouldReturnAnItemsKeywords()
        {
            var expectedKeywords = MockItem.KeywordsForPickup;

            var returnedKeywords = InventoryHandler.GetAllInventoryItemKeywords(MockPlayer);

            Assert.AreEqual(expectedKeywords.ToString(), returnedKeywords.ToString());
        }
    }
}