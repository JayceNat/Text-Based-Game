using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextBasedGameTests.TestConstants;

namespace TextBasedGameTests.CharacterTests.HandlerTests
{
    [TestClass]
    public class PlayerSetupHandlerTests
    {
        [TestMethod]
        public void UpdatingCharacterAttributesByInput_ShouldUpdateCorrectly()
        {
            var attributeToIncrease = "wisdom";
            var newPlayerAttributes = MockAttributes.MockPlayerAttrBeforeUpdate;
            var expectedOutputAttributes = MockAttributes.MockPlayerAttrAfterUpdate;

            var actualUpdatedAttributes =
                TextBasedGame.Character.Handlers.PlayerSetupHandler.UpdateCharacterAttributesByInput(
                    newPlayerAttributes, attributeToIncrease);
            
            Assert.AreEqual(expectedOutputAttributes.AvailablePoints, actualUpdatedAttributes.AvailablePoints);
            Assert.AreEqual(expectedOutputAttributes.MaximumCarryingCapacity, actualUpdatedAttributes.MaximumCarryingCapacity);
            Assert.AreEqual(expectedOutputAttributes.CarriedItemsCount, actualUpdatedAttributes.CarriedItemsCount);
            Assert.AreEqual(expectedOutputAttributes.Defense, actualUpdatedAttributes.Defense);
            Assert.AreEqual(expectedOutputAttributes.Dexterity, actualUpdatedAttributes.Dexterity);
            Assert.AreEqual(expectedOutputAttributes.Luck, actualUpdatedAttributes.Luck);
            Assert.AreEqual(expectedOutputAttributes.Stamina, actualUpdatedAttributes.Stamina);
            Assert.AreEqual(expectedOutputAttributes.Strength, actualUpdatedAttributes.Strength);
            Assert.AreEqual(expectedOutputAttributes.Wisdom, actualUpdatedAttributes.Wisdom);
        }
    }
}