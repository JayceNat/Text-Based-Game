using TextBasedGame.Character.Models;

namespace TextBasedGame.Character.Interfaces
{
    public interface IAttribute
    {
        CharacterAttributeModel CreateCharacterAttributes(int availablePoints = 6, int defense = 3, int dexterity = 3, int luck = 3,
            int stamina = 3, int strength = 3, int wisdom = 3);

        CharacterAttributeModel UpdateCharacterAttributes(CharacterAttributeModel characterAttributes, 
            int availablePointsToAdd = 0, int defenseToAdd = 0, int dexterityToAdd = 0, int luckToAdd = 0, 
            int staminaToAdd = 0, int strengthToAdd = 0, int wisdomToAdd = 0);
    }
}