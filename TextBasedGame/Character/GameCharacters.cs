using TextBasedGame.Character.Constants;
using TextBasedGame.Character.Implementations;
using TextBasedGame.Character.Interfaces;
using TextBasedGame.Item.Interfaces;

namespace TextBasedGame.Character
{
    public class GameCharacters
    {
        private static readonly IAttributeCreator AttributeCreator = new AttributeCreator();
        private static readonly IItemCreator ItemCreator = new Item.Implementations.ItemCreator();

        public static Models.Character Player = new Models.Character
        {
            Name = null,
            Attributes = AttributeCreator.PlayerAttributes
        };

        public static Models.Character Ghoul = new Models.Character
        {
            Name = "The Ghoul",
            MaximumHealthPoints = CharacterDefaults.DefaultMaximumHealthPoints 
                                  + (CharacterAttributes.StaminaPerPointIncrease * AttributeCreator.GhoulAttributes.Stamina - CharacterAttributes.DefaultValueForAllAttributes),
            HealthPoints = CharacterDefaults.DefaultMaximumHealthPoints
                           + (CharacterAttributes.StaminaPerPointIncrease * AttributeCreator.GhoulAttributes.Stamina - CharacterAttributes.DefaultValueForAllAttributes),
            Attributes = AttributeCreator.GhoulAttributes,
            MaximumCarryingCapacity = 0,
            WeaponItem = ItemCreator.GhoulClaws
        };
    }
}