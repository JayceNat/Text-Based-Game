using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextBasedGame.Character.Handlers;
using TextBasedGameTests.TestConstants;

namespace TextBasedGameTests.CharacterTests.HandlerTests
{
    [TestClass]
    public class AttributeHandlerTests
    {
        [TestMethod]
        public void UpdatePlayerAttributesFromInventoryItem_ShouldAddTraitPointToPlayer()
        {
            var player = MockCharacters.MockPlayerAlbert;
            player.Attributes = MockAttributes.MockPlayerAttrBeforeUpdate;
            MockAttributes.MockPlayerAttrBeforeUpdate.Luck = 7;

            var expectedOutput = MockAttributes.MockPlayerAttrAfterAddLuck;

            AttributeHandler.UpdatePlayerAttributesFromInventoryItem(player, MockItems.MockItemRabbitsFoot);

            Assert.AreEqual(expectedOutput.Luck, player.Attributes.Luck);
        }

        [TestMethod]
        public void UpdatePlayerAttributesFromInventoryItem_ShouldRemoveTraitPointToPlayer()
        {
            var player = MockCharacters.MockPlayerAlbert;
            player.Attributes = MockAttributes.MockPlayerAttrBeforeUpdate;
            MockAttributes.MockPlayerAttrBeforeUpdate.Luck = 7;

            var expectedOutput = MockAttributes.MockPlayerAttrAfterRemoveLuck;

            AttributeHandler.UpdatePlayerAttributesFromInventoryItem(player, MockItems.MockItemRabbitsFoot, true);

            Assert.AreEqual(expectedOutput.Luck, player.Attributes.Luck);
        }


        [TestMethod]
        public void UpdatePlayerAttributesFromWeaponItem_ShouldAddTraitPointToPlayer()
        {
            var player = MockCharacters.MockPlayerAlbert;
            player.Attributes = MockAttributes.MockPlayerAttrBeforeUpdate;
            MockAttributes.MockPlayerAttrBeforeUpdate.Dexterity = 6;

            var expectedOutput = MockAttributes.MockPlayerAttrAfterAddDexterity;

            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, MockItems.MockItemKatana);

            Assert.AreEqual(expectedOutput.Dexterity, player.Attributes.Dexterity);

        }

        [TestMethod]
        public void UpdatePlayerAttributesFromWeaponItem_ShouldRemoveTraitPointToPlayer()
        {
            var player = MockCharacters.MockPlayerAlbert;
            player.Attributes = MockAttributes.MockPlayerAttrBeforeUpdate;
            MockAttributes.MockPlayerAttrBeforeUpdate.Dexterity = 6;

            var expectedOutput = MockAttributes.MockPlayerAttrAfterRemoveDexterity;

            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, MockItems.MockItemKatana, true);

            Assert.AreEqual(expectedOutput.Dexterity, player.Attributes.Dexterity);

        }

    }
}