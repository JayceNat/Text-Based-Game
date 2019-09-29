using TextBasedGame.Character.Constants;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Shared.Utilities
{
    public class PlayerAttributeComparer
    {
        public static bool ComparePlayerTraitsToAttributeRequirement(Character.Models.Character player, AttributeRequirement requirement)
        {
            switch (requirement.RelevantCharacterAttribute)
            {
                case AttributeStrings.Defense:
                    return player.Attributes.Defense >= requirement.MinimumAttributeValue;
                case AttributeStrings.Dexterity:
                    return player.Attributes.Dexterity >= requirement.MinimumAttributeValue;
                case AttributeStrings.Luck:
                    return player.Attributes.Luck >= requirement.MinimumAttributeValue;
                case AttributeStrings.Stamina:
                    return player.Attributes.Stamina >= requirement.MinimumAttributeValue;
                case AttributeStrings.Strength:
                    return player.Attributes.Strength >= requirement.MinimumAttributeValue;
                case AttributeStrings.Wisdom:
                    return player.Attributes.Wisdom >= requirement.MinimumAttributeValue;
            }

            return false;
        }
    }
}