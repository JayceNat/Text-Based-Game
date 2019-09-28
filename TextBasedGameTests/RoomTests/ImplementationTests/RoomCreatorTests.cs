using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextBasedGame.Item.Implementations;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Room.Implementations;
using TextBasedGame.Room.Interfaces;

namespace TextBasedGameTests.RoomTests.ImplementationTests
{
    [TestClass]
    public class RoomCreatorTests
    {
        // We need these to construct our dependencies
        public static readonly IItemTraitCreator ItemTraitCreator = new ItemTraitCreator();
        public static readonly IItemCreator ItemCreator = new ItemCreator();
        public static readonly IRoomCreator RoomCreator = new RoomCreator();

        [TestMethod]
        public void RoomCreator_ShouldUpdateExitsOfRooms()
        {
            var yourBedroomExit = RoomCreator.YourBedroom.AvailableExits;

            Assert.IsTrue(
                yourBedroomExit?.NorthRoom != null
                || yourBedroomExit?.EastRoom != null
                || yourBedroomExit?.SouthRoom != null
                || yourBedroomExit?.WestRoom != null);
        }
    }
}