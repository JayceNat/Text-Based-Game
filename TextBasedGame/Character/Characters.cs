using TextBasedGame.Character.Constants;
using TextBasedGame.Character.Implementations;
using TextBasedGame.Character.Interfaces;
using TextBasedGame.Item.Game_Items;

namespace TextBasedGame.Character
{
    public class Characters
    {
        private static readonly IAttributeCreator AttributeCreator = new AttributeCreator();

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
            WeaponItem = Weapons.GhoulClaws
        };
    }
}