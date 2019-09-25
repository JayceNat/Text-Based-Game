using TextBasedGame.Character.Interfaces;
using TextBasedGame.Character.Models;

namespace TextBasedGame.Character.Implementations
{
    public class AttributeCreator : IAttributeCreator
    {
        public CharacterAttribute PlayerAttributes { get; }
        public CharacterAttribute GhoulAttributes { get; }

        public AttributeCreator()
        {
            PlayerAttributes = Attributes.PlayerAttributes;
            GhoulAttributes = Attributes.GhoulAttributes;
        }

        public CharacterAttribute UpdateCharacterAttributes(CharacterAttribute characterAttributes,
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