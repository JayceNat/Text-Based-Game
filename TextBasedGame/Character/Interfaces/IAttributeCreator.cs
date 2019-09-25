using TextBasedGame.Character.Models;

namespace TextBasedGame.Character.Interfaces
{
    public interface IAttributeCreator
    {
        CharacterAttribute PlayerAttributes { get; }
        CharacterAttribute GhoulAttributes { get; }

        CharacterAttribute UpdateCharacterAttributes(CharacterAttribute characterAttributes, 
            int availablePointsToAdd = 0, int defenseToAdd = 0, int dexterityToAdd = 0, int luckToAdd = 0, 
            int staminaToAdd = 0, int strengthToAdd = 0, int wisdomToAdd = 0);
    }
}