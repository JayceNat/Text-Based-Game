using TextBasedGame.Character.Interfaces;
using TextBasedGame.Character.Models;

namespace TextBasedGame.Character.Implementations
{
    public class Attribute : IAttribute
    {
        public CharacterAttributeModel CreateCharacterAttributes(int availablePoints = 6, int defense = 3, int dexterity = 3, int luck = 3,
            int stamina = 3, int strength = 3, int wisdom = 3)
        {
            CharacterAttributeModel characterAttributes = new CharacterAttributeModel()
            {
                AvailablePoints = availablePoints,
                Defense = defense,
                Dexterity = dexterity,
                Luck = luck,
                Stamina = stamina,
                Strength = strength,
                Wisdom = wisdom
            };

            return characterAttributes;
        }

        public CharacterAttributeModel UpdateCharacterAttributes(CharacterAttributeModel characterAttributes,
            int availablePointsToAdd = 0, int defenseToAdd = 0, int dexterityToAdd = 0, int luckToAdd = 0, int staminaToAdd = 0,
            int strengthToAdd = 0, int wisdomToAdd = 0)
        {
            if (availablePointsToAdd != 0)
            {
                characterAttributes.AvailablePoints += availablePointsToAdd;
            }

            if (defenseToAdd != 0)
            {
                characterAttributes.Defense += defenseToAdd;
            }

            if (dexterityToAdd != 0)
            {
                characterAttributes.Dexterity += dexterityToAdd;
            }

            if (luckToAdd != 0)
            {
                characterAttributes.Luck += luckToAdd;
            }

            if (staminaToAdd != 0)
            {
                characterAttributes.Stamina += staminaToAdd;
            }

            if (strengthToAdd != 0)
            {
                characterAttributes.Strength += strengthToAdd;
            }

            if (wisdomToAdd != 0)
            {
                characterAttributes.Wisdom += wisdomToAdd;
            }

            return characterAttributes;
        }
    }
}