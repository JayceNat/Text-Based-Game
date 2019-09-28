using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextBasedGame.Item.Implementations;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Room.Implementations;
using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;

namespace TextBasedGameTests.RoomTests
{
    [TestClass]
    public class GameRoomTests
    {
        // We need these to construct our dependencies
        public static readonly IItemTraitCreator ItemTraitCreator = new ItemTraitCreator();
        public static readonly IItemCreator ItemCreator = new ItemCreator();
        public static readonly IRoomCreator RoomCreator = new RoomCreator();

        [TestMethod]
        public void YourBedroomObject_HasPropertyValues()
        {
            Assert.IsTrue(!string.IsNullOrEmpty(RoomCreator.YourBedroom.RoomName));
            Assert.IsTrue(!string.IsNullOrEmpty(RoomCreator.YourBedroom.InitialRoomDescription));
            Assert.IsTrue(!string.IsNullOrEmpty(RoomCreator.YourBedroom.GenericRoomDescription));
            Assert.IsTrue(!string.IsNullOrEmpty(RoomCreator.YourBedroom.AsExitDescription));
            Assert.IsNotNull(RoomCreator.YourBedroom.RoomItems);
            Assert.IsNotNull(RoomCreator.YourBedroom.AvailableExits);
            Assert.IsNotNull(RoomCreator.YourBedroom.KeywordsToEnter?.First());
        }

        [TestMethod]
        public void YourBedroomObject_HasAnotherRoomConnectedAsAnExit()
        {
            Assert.IsTrue(
                RoomCreator.YourBedroom.AvailableExits?.NorthRoom != null && RoomCreator.YourBedroom.AvailableExits.NorthRoom.GetType() == typeof(Room)
                          || RoomCreator.YourBedroom.AvailableExits?.EastRoom != null && RoomCreator.YourBedroom.AvailableExits.EastRoom.GetType() == typeof(Room)
                          || RoomCreator.YourBedroom.AvailableExits?.SouthRoom != null && RoomCreator.YourBedroom.AvailableExits.SouthRoom.GetType() == typeof(Room)
                          || RoomCreator.YourBedroom.AvailableExits?.WestRoom != null && RoomCreator.YourBedroom.AvailableExits.WestRoom.GetType() == typeof(Room));
        }
    }
}