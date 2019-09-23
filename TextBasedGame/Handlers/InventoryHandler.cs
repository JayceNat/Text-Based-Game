using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TextBasedGame.Character.Interfaces;
using TextBasedGame.Character.Models;
using TextBasedGame.Constants;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;
using TextBasedGame.Utilities;
using Console = Colorful.Console;

namespace TextBasedGame.Handlers
{
    public class InventoryHandler
    {
        private static readonly ICharacter Character = new Character.Implementations.Character();
        private static readonly IRoom Room = new Room.Implementations.Room();
        private static readonly IItem Item = new Item.Implementations.Item();

        public static Tuple<CharacterModel, RoomModel> HandleItemAdd(CharacterModel player, RoomModel currentRoom, ItemsModel foundItem)
        {
            if (foundItem?.InventoryItems != null)
            {
                var inventoryItemToAdd = foundItem.InventoryItems.FirstOrDefault();
                if (player.CarriedItemsCount + 1 <= player.MaximumCarryingCapacity)
                {
                    player = UpdatePlayerAttributesFromInventoryItem(player, inventoryItemToAdd);
                    inventoryItemToAdd = Item.UpdateInventoryItem(inventoryItemToAdd);
                    player = Character.UpdateCharacter(player, itemToAdd: inventoryItemToAdd, addToCarriedCount: 1);
                    currentRoom = Room.UpdateRoom(currentRoom, itemToRemove: inventoryItemToAdd);
                    Console.WriteLine();
                    TypingAnimation.Animate("You take the " + inventoryItemToAdd.ItemName + ".\n", Color.ForestGreen);
                }
                else
                {
                    Console.WriteLine();
                    TypingAnimation.Animate("Your inventory is full! \n" +
                                            "Drop an item to pick up the " + inventoryItemToAdd?.ItemName + ".\n", Color.DarkOliveGreen);
                }
            }
            else if (foundItem?.WeaponItems != null)
            {
                var weaponItemToAdd = foundItem.WeaponItems.FirstOrDefault();
                if (string.IsNullOrEmpty(player.WeaponItem.WeaponName))
                {
                    player = UpdatePlayerAttributesFromWeaponItem(player, weaponItemToAdd);
                    weaponItemToAdd = Item.UpdateWeaponItem(weaponItemToAdd);
                    player = Character.UpdateCharacter(player, weapon: weaponItemToAdd);
                    currentRoom = Room.UpdateRoom(currentRoom, weaponToRemove: weaponItemToAdd);
                    Console.WriteLine();
                    TypingAnimation.Animate("You take the " + weaponItemToAdd.WeaponName + ".\n", Color.ForestGreen);
                }
                else
                {
                    var oldWeapon = player.WeaponItem.WeaponName;
                    var playerAndRoom = DropWeaponAndPickupNew(player, currentRoom, weaponItemToAdd);
                    player = playerAndRoom.Item1;
                    currentRoom = playerAndRoom.Item2;
                    player = UpdatePlayerAttributesFromWeaponItem(player, weaponItemToAdd);
                    player = Character.UpdateCharacter(player, weapon: weaponItemToAdd);
                    currentRoom = Room.UpdateRoom(currentRoom, weaponToRemove: weaponItemToAdd);
                    Console.WriteLine();
                    TypingAnimation.Animate("You drop your " + oldWeapon + " for the " + weaponItemToAdd.WeaponName + ".\n",
                        Color.ForestGreen);
                }
            }

            return Tuple.Create(player, currentRoom);
        }

        private static Tuple<CharacterModel, RoomModel> DropWeaponAndPickupNew(CharacterModel player, RoomModel room, WeaponItemModel weaponToAdd)
        {
            room = Room.UpdateRoom(room, weaponToAdd: player.WeaponItem);
            player = UpdatePlayerAttributesFromWeaponItem(player, player.WeaponItem, true);
            player = UpdatePlayerAttributesFromWeaponItem(player, weaponToAdd);
            weaponToAdd = Item.UpdateWeaponItem(weaponToAdd);
            player = Character.UpdateCharacter(player, weapon: weaponToAdd);
            room = Room.UpdateRoom(room, weaponToRemove: weaponToAdd);
            return Tuple.Create(player, room);
        }

        private static CharacterModel UpdatePlayerAttributesFromInventoryItem(CharacterModel player,
            InventoryItemModel newInventoryItem, bool removeAttributes = false)
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

        private static CharacterModel UpdatePlayerAttributesFromWeaponItem(CharacterModel player, WeaponItemModel newWeaponItem, bool removeAttributes = false)
        {
            var newAttributes = player.Attributes;
            if (newWeaponItem?.WeaponTraits == null) return player;
            foreach (var trait in newWeaponItem?.WeaponTraits)
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

        private static void AddCharacterAttributesByTrait(CharacterModel player, ItemTraitModel trait,
            CharacterAttributeModel newAttributes)
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
                        increaseMaximumHealth: 15 * trait.TraitValue);
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

        private static void RemoveCharacterAttributesByTrait(CharacterModel player, ItemTraitModel trait,
            CharacterAttributeModel newAttributes)
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
                        increaseMaximumHealth: -(15 * trait.TraitValue));
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

        public static ItemsModel FindAnyMatchingItems(string inputSubstring, List<string> itemKeywords, ItemsModel roomItems)
        {
            ItemsModel itemModel = null;
            var words = inputSubstring.Split(ConsoleStrings.StringDelimiters);
            foreach (var word in words)
            {
                if (itemKeywords.Contains(word))
                {
                    foreach (var inventoryItem in roomItems.InventoryItems)
                    {
                        if (inventoryItem.KeywordsForPickup.Contains(word))
                        {
                            itemModel = new ItemsModel()
                            {
                                InventoryItems = new List<InventoryItemModel>()
                                {
                                    inventoryItem
                                }
                            };
                            return itemModel;
                        }
                    }

                    foreach (var weapon in roomItems.WeaponItems)
                    {
                        if (weapon.KeywordsForPickup.Contains(word))
                        {
                            itemModel = new ItemsModel()
                            {
                                WeaponItems = new List<WeaponItemModel>()
                                {
                                    weapon
                                }
                            };
                            return itemModel;
                        }
                    }
                }
            }

            return itemModel;
        }
    }
}