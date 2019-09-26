using TextBasedGame.Character.Constants;
using TextBasedGame.Character.Interfaces;
using TextBasedGame.Character.Models;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Handlers
{
    public class AttributeHandler
    {
        private static readonly ICharacterCreator CharacterCreator = new Character.Implementations.CharacterCreator();

        // When a user picks up or drops an inventory item, adjusts their attributes accordingly
        public static Models.Character UpdatePlayerAttributesFromInventoryItem(Models.Character player,
            InventoryItem newInventoryItem, bool removeAttributes = false)
        {
            var newAttributes = player.Attributes;
            if (newInventoryItem?.ItemTraits == null) return player;
            foreach (var trait in newInventoryItem.ItemTraits)
            {
                if (!removeAttributes)
                {
                    AddCharacterAttributesByTrait(player, trait, newAttributes);
                }
                else
                {
                    RemoveCharacterAttributesByTrait(player, trait, newAttributes);
                }
            }

            return player;
        }

        // When a user picks up or drops a weapon item, adjusts their attributes accordingly
        public static Models.Character UpdatePlayerAttributesFromWeaponItem(Models.Character player, WeaponItem newWeaponItem, bool removeAttributes = false)
        {
            var newAttributes = player.Attributes;
            if (newWeaponItem?.WeaponTraits == null) return player;
            foreach (var trait in newWeaponItem.WeaponTraits)
            {
                if (!removeAttributes)
                {
                    AddCharacterAttributesByTrait(player, trait, newAttributes);
                }
                else
                {
                    RemoveCharacterAttributesByTrait(player, trait, newAttributes);
                }
            }

            return player;
        }

        // Helper used by the two methods above
        public static void AddCharacterAttributesByTrait(Models.Character player, ItemTrait trait,
            CharacterAttribute newAttributes)
        {
            switch (trait.RelevantCharacterAttribute)
            {
                case CharacterAttributes.Defense:
                    newAttributes.Defense += trait.TraitValue;
                    CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Dexterity:
                    newAttributes.Dexterity += trait.TraitValue;
                    CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Luck:
                    newAttributes.Luck += trait.TraitValue;
                    CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Stamina:
                    newAttributes.Stamina += trait.TraitValue;
                    CharacterCreator.UpdateCharacter(player, attributes: newAttributes,
                        increaseMaximumHealth: CharacterAttributes.StaminaPerPointIncrease * trait.TraitValue);
                    break;
                case CharacterAttributes.Strength:
                    newAttributes.Strength += trait.TraitValue;
                    CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Wisdom:
                    newAttributes.Wisdom += trait.TraitValue;
                    CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
            }
        }

        // Helper used by the two methods above
        public static void RemoveCharacterAttributesByTrait(Models.Character player, ItemTrait trait,
            CharacterAttribute newAttributes)
        {
            switch (trait.RelevantCharacterAttribute)
            {
                case CharacterAttributes.Defense:
                    newAttributes.Defense -= trait.TraitValue;
                    CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Dexterity:
                    newAttributes.Dexterity -= trait.TraitValue;
                    CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Luck:
                    newAttributes.Luck -= trait.TraitValue;
                    CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Stamina:
                    newAttributes.Stamina -= trait.TraitValue;
                    CharacterCreator.UpdateCharacter(player, attributes: newAttributes,
                        increaseMaximumHealth: -(CharacterAttributes.StaminaPerPointIncrease * trait.TraitValue));
                    break;
                case CharacterAttributes.Strength:
                    newAttributes.Strength -= trait.TraitValue;
                    CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Wisdom:
                    newAttributes.Wisdom -= trait.TraitValue;
                    CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
            }
        }
    }
}