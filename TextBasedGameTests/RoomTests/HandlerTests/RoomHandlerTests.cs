using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextBasedGame.Room.Handlers;
using TextBasedGameTests.TestConstants;

namespace TextBasedGameTests.RoomTests.HandlerTests
{
    [TestClass]
    public class RoomHandlerTests
    {
        [TestMethod]
        public void FindAnyMatchingRoomByKeywords_ShouldReturnMatchingRoom()
        {
            var inputKeyword = "observatory";
            MockRooms.MockRoomNursery.AvailableExits.EastRoom = MockRooms.MockRoomObservatory;
            var expectedRoom = MockRooms.MockRoomObservatory;

            var returnedRoom = RoomHandler.FindAnyMatchingRoomByKeywords(inputKeyword, MockRooms.MockRoomNursery);

            Assert.AreEqual(expectedRoom, returnedRoom);
        }

        [TestMethod]
        public void GetAllRoomItemKeywords_ShouldReturnListOfStrings()
        {
            var expectedKeywords = MockRooms.MockRoomBathroom.KeywordsToEnter;
            expectedKeywords.AddRange(MockRooms.MockRoomNursery.KeywordsToEnter);

            MockRooms.MockRoomObservatory.AvailableExits.WestRoom = MockRooms.MockRoomNursery;
            MockRooms.MockRoomObservatory.AvailableExits.NorthRoom = MockRooms.MockRoomBathroom;

            var returnedKeywords = RoomHandler.GetAllRoomItemKeywords(MockRooms.MockRoomObservatory);

            Assert.AreEqual(expectedKeywords.ToString(), returnedKeywords.ToString());
        }
    }
}