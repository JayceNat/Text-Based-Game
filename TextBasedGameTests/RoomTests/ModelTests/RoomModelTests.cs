using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Models;

namespace TextBasedGameTests.RoomTests.ModelTests
{
    [TestClass]
    public class RoomModelTests
    {
        [TestMethod]
        public void RoomModel_HasRoomNameProperty()
        {
            const string roomName = "Funny Room Name";

            var roomModel = new Room
            {
                RoomName = roomName
            };

            Assert.AreEqual(roomName, roomModel.RoomName);
        }

        [TestMethod]
        public void RoomModel_HasRoomEnteredProperty()
        {
            const bool roomEntered = true;

            var roomModel = new Room
            {
                RoomEntered = roomEntered
            };

            Assert.AreEqual(roomEntered, roomModel.RoomEntered);
        }

        [TestMethod]
        public void RoomModel_RoomEntered_DefaultsToFalse()
        {
            var roomModel = new Room();
            Assert.AreEqual(false, roomModel.RoomEntered);
        }

        [TestMethod]
        public void RoomModel_HasInitialRoomDescriptionProperty()
        {
            const string initialRoomDescription = "I'm the original, but only seen once.";

            var roomModel = new Room()
            {
                InitialRoomDescription = initialRoomDescription
            };

            Assert.AreEqual(initialRoomDescription, roomModel.InitialRoomDescription);
        }

        [TestMethod]
        public void RoomModel_HasGenericRoomDescriptionProperty()
        {
            const string genericRoomDescription = "I'm seen anytime after your first visit to a room.";

            var roomModel = new Room()
            {
                GenericRoomDescription = genericRoomDescription
            };

            Assert.AreEqual(genericRoomDescription, roomModel.GenericRoomDescription);
        }

        [TestMethod]
        public void RoomModel_HasAsExitDescriptionProperty()
        {
            const string asExitDescription = "I'm seen from a connected room you're already in.";

            var roomModel = new Room()
            {
                AsExitDescription = asExitDescription
            };

            Assert.AreEqual(asExitDescription, roomModel.AsExitDescription);
        }


        [TestMethod]
        public void RoomModel_HasAvailableExitsProperty()
        {
            var availableExits = new RoomExit()
            {
                EastRoom = new Room()
            };

            var roomModel = new Room()
            {
                AvailableExits = availableExits
            };

            Assert.AreEqual(availableExits.EastRoom, roomModel.AvailableExits.EastRoom);
        }

        [TestMethod]
        public void RoomModel_HasRoomItemsProperty()
        {
            var roomItems = new Items
            {
                InventoryItems = new List<InventoryItem>(),
                WeaponItems = new List<WeaponItem>()
            };

            var roomModel = new Room()
            {
                RoomItems = roomItems
            };

            Assert.AreEqual(roomItems.InventoryItems, roomModel.RoomItems.InventoryItems);
            Assert.AreEqual(roomItems.WeaponItems, roomModel.RoomItems.WeaponItems);
        }

        [TestMethod]
        public void RoomModel_RoomItems_DefaultsToNewItem()
        {
            var roomModel = new Room();
            var emptyItems = new Items();

            Assert.IsTrue( emptyItems?.InventoryItems == roomModel.RoomItems?.InventoryItems);
            Assert.IsTrue(emptyItems?.WeaponItems == roomModel.RoomItems?.WeaponItems);
        }

        [TestMethod]
        public void RoomModel_HasKeywordsToEnterProperty()
        {
            var keywordsToEnter = new List<string>()
            {
                "test!"
            };

            var roomModel = new Room
            {
                KeywordsToEnter = keywordsToEnter
            };

            Assert.AreEqual(keywordsToEnter[0], roomModel.KeywordsToEnter[0]);
        }

        [TestMethod]
        public void RoomModel_KeywordsToEnter_DefaultsToList()
        {
            var roomModel = new Room();
            
            Assert.IsTrue(new List<string>().SequenceEqual(roomModel.KeywordsToEnter));
        }
    }
}