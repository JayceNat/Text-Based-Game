using TextBasedGame.Character.Constants;
using TextBasedGame.Character.Implementations;
using TextBasedGame.Character.Interfaces;
using TextBasedGame.Item.Interfaces;

namespace TextBasedGame.Character
{
    public class GameCharacters
    {
        // This is where all Characters for the game are defined/instantiated
        // Note: These should only ever be referenced by the CharacterCreator

        public static Models.Character Player = new Models.Character
        {
            Name = null,
            Attributes = Program.AttributeCreator.PlayerAttributes
        };

        public static Models.Character Ghoul = new Models.Character
        {
            Name = "The Ghoul",
            MaximumHealthPoints = CharacterDefaults.DefaultMaximumHealthPoints 
                                  + (CharacterAttributes.StaminaPerPointIncrease * Program.AttributeCreator.GhoulAttributes.Stamina - CharacterAttributes.DefaultValueForAllAttributes),
            HealthPoints = CharacterDefaults.DefaultMaximumHealthPoints
                           + (CharacterAttributes.StaminaPerPointIncrease * Program.AttributeCreator.GhoulAttributes.Stamina - CharacterAttributes.DefaultValueForAllAttributes),
            Attributes = Program.AttributeCreator.GhoulAttributes,
            MaximumCarryingCapacity = 0,
            WeaponItem = Program.ItemCreator.GhoulClaws
        };
    }
}