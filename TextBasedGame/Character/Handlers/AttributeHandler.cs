using TextBasedGame.Character.Constants;
using TextBasedGame.Character.Models;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Handlers
{
    public class AttributeHandler
    {
        // When a user picks up or drops an inventory item, adjusts their attributes accordingly
        public static void UpdatePlayerAttributesFromInventoryItem(Models.Character player,
            InventoryItem newInventoryItem, bool removeAttributes = false)
        {
            var newAttributes = player.Attributes;
            if (newInventoryItem?.ItemTraits == null) return;
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
        }

        // When a user picks up or drops a weapon item, adjusts their attributes accordingly
        public static void UpdatePlayerAttributesFromWeaponItem(Models.Character player, WeaponItem newWeaponItem, bool removeAttributes = false)
        {
            var newAttributes = player.Attributes;
            if (newWeaponItem?.WeaponTraits == null) return;
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
        }

        // Helper used by the two methods above
        public static void AddCharacterAttributesByTrait(Models.Character player, ItemTrait trait,
            CharacterAttribute newAttributes)
        {
            switch (trait.RelevantCharacterAttribute)
            {
                case CharacterAttributes.Defense:
                    newAttributes.Defense += trait.TraitValue;
                    Program.CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Dexterity:
                    newAttributes.Dexterity += trait.TraitValue;
                    Program.CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Luck:
                    newAttributes.Luck += trait.TraitValue;
                    Program.CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Stamina:
                    newAttributes.Stamina += trait.TraitValue;
                    Program.CharacterCreator.UpdateCharacter(player, attributes: newAttributes,
                        increaseMaximumHealth: CharacterAttributes.StaminaPerPointIncrease * trait.TraitValue);
                    break;
                case CharacterAttributes.Strength:
                    newAttributes.Strength += trait.TraitValue;
                    Program.CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Wisdom:
                    newAttributes.Wisdom += trait.TraitValue;
                    Program.CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
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
                    Program.CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Dexterity:
                    newAttributes.Dexterity -= trait.TraitValue;
                    Program.CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Luck:
                    newAttributes.Luck -= trait.TraitValue;
                    Program.CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Stamina:
                    newAttributes.Stamina -= trait.TraitValue;
                    Program.CharacterCreator.UpdateCharacter(player, attributes: newAttributes,
                        increaseMaximumHealth: -(CharacterAttributes.StaminaPerPointIncrease * trait.TraitValue));
                    break;
                case CharacterAttributes.Strength:
                    newAttributes.Strength -= trait.TraitValue;
                    Program.CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
                case CharacterAttributes.Wisdom:
                    newAttributes.Wisdom -= trait.TraitValue;
                    Program.CharacterCreator.UpdateCharacter(player, attributes: newAttributes);
                    break;
            }
        }
    }
}