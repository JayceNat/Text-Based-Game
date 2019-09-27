using System.Collections.Generic;
using TextBasedGame.Character.Models;
using TextBasedGame.Item.Models;

namespace TextBasedGameTests.TestConstants
{
    public class MockCharacters
    {
        public static Character MockPlayerAlbert = new Character
        {
            Name = "Albert",
            MaximumHealthPoints = 900,
            HealthPoints = 256,
            Attributes = MockAttributes.MockPlayerAttrAfterUpdate,
            CarriedItems = new List<InventoryItem>()
            {
                MockItems.MockItemFlare
            },
            WeaponItem = MockItems.MockItemGun
        };

        public static Character mockEnemyNinja = new Character
        {
            Name = "Ninja",
            MaximumHealthPoints = 850,
            HealthPoints = 333,
            Attributes = MockAttributes.MockPlayerAttrBeforeUpdate,
            CarriedItems = new List<InventoryItem>()
            {
                MockItems.MockItemRabbitsFoot
            },
            WeaponItem = MockItems.MockItemKatana
        };
    }
}