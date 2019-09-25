using TextBasedGame.Character.Constants;
using TextBasedGame.Item.Game_Items;

namespace TextBasedGame.Character
{
    public class Characters
    {
        public static Models.Character Player = new Models.Character
        {
            Name = null,
            Attributes = Attributes.PlayerAttributes
        };

        public static Models.Character Ghoul = new Models.Character
        {
            Name = "The Ghoul",
            MaximumHealthPoints = CharacterDefaults.DefaultMaximumHealthPoints 
                                  + (CharacterAttributes.StaminaPerPointIncrease * Attributes.GhoulAttributes.Stamina - CharacterAttributes.DefaultValueForAllAttributes),
            HealthPoints = CharacterDefaults.DefaultMaximumHealthPoints
                           + (CharacterAttributes.StaminaPerPointIncrease * Attributes.GhoulAttributes.Stamina - CharacterAttributes.DefaultValueForAllAttributes),
            Attributes = Attributes.GhoulAttributes,
            MaximumCarryingCapacity = 0,
            WeaponItem = Weapons.GhoulClaws
        };
    }
}