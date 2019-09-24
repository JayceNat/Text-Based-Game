using TextBasedGame.Character.Constants;
using TextBasedGame.Character.Models;

namespace TextBasedGame.Character.Interfaces
{
    public interface IAttribute
    {
        CharacterAttribute CreateCharacterAttributes(int availablePoints = CharacterAttributes.DefaultPointsToSpend,
            int defense = CharacterAttributes.DefaultPointsForAllAttributes, int dexterity = CharacterAttributes.DefaultPointsForAllAttributes,
            int luck = CharacterAttributes.DefaultPointsForAllAttributes, int stamina = CharacterAttributes.DefaultPointsForAllAttributes,
            int strength = CharacterAttributes.DefaultPointsForAllAttributes, int wisdom = CharacterAttributes.DefaultPointsForAllAttributes);

        CharacterAttribute UpdateCharacterAttributes(CharacterAttribute characterAttributes, 
            int availablePointsToAdd = 0, int defenseToAdd = 0, int dexterityToAdd = 0, int luckToAdd = 0, 
            int staminaToAdd = 0, int strengthToAdd = 0, int wisdomToAdd = 0);
    }
}