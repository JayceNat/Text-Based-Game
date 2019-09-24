using TextBasedGame.Character.Constants;
using TextBasedGame.Character.Interfaces;
using TextBasedGame.Item.Game_Items;

namespace TextBasedGame.Character
{
    public class Characters
    {
        private static readonly ICharacter Character = new Implementations.Character();

        public static Models.Character Ghoul = Character.CreateCharacter(
            name: "The Ghoul",
            attributes: Attributes.GhoulAttributes,
            baseHP: 100 + (CharacterAttributes.StaminaPerPointIncrease 
                           * Attributes.GhoulAttributes.Stamina - CharacterAttributes.DefaultPointsForAllAttributes),
            weapon: Weapons.GhoulClaws);
    }
}