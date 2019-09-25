﻿using TextBasedGame.Character.Constants;
using TextBasedGame.Character.Interfaces;
using TextBasedGame.Character.Models;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Handlers
{
    public class AttributeHandler
    {
        private static readonly ICharacter Character = new Character.Implementations.Character();

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

        public static void AddCharacterAttributesByTrait(Models.Character player, ItemTrait trait,
            CharacterAttribute newAttributes)
        {
            switch (trait.RelevantCharacterAttribute)
            {
                case CharacterAttributes.Defense:
                    newAttributes.Defense += trait.TraitValue;
                    Character.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Dexterity:
                    newAttributes.Dexterity += trait.TraitValue;
                    Character.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Luck:
                    newAttributes.Luck += trait.TraitValue;
                    Character.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Stamina:
                    newAttributes.Stamina += trait.TraitValue;
                    Character.UpdateCharacter(player, attributes: newAttributes,
                        increaseMaximumHealth: CharacterAttributes.StaminaPerPointIncrease * trait.TraitValue);
                    break;
                case CharacterAttributes.Strength:
                    newAttributes.Strength += trait.TraitValue;
                    Character.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Wisdom:
                    newAttributes.Wisdom += trait.TraitValue;
                    Character.UpdateCharacter(player, attributes: newAttributes);
                    break;
            }
        }

        public static void RemoveCharacterAttributesByTrait(Models.Character player, ItemTrait trait,
            CharacterAttribute newAttributes)
        {
            switch (trait.RelevantCharacterAttribute)
            {
                case CharacterAttributes.Defense:
                    newAttributes.Defense -= trait.TraitValue;
                    Character.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Dexterity:
                    newAttributes.Dexterity -= trait.TraitValue;
                    Character.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Luck:
                    newAttributes.Luck -= trait.TraitValue;
                    Character.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Stamina:
                    newAttributes.Stamina -= trait.TraitValue;
                    Character.UpdateCharacter(player, attributes: newAttributes,
                        increaseMaximumHealth: -(CharacterAttributes.StaminaPerPointIncrease * trait.TraitValue));
                    break;
                case CharacterAttributes.Strength:
                    newAttributes.Strength -= trait.TraitValue;
                    Character.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Wisdom:
                    newAttributes.Wisdom -= trait.TraitValue;
                    Character.UpdateCharacter(player, attributes: newAttributes);
                    break;
            }
        }
    }
}