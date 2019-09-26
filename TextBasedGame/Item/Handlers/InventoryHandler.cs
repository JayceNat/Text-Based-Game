using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TextBasedGame.Character.Handlers;
using TextBasedGame.Character.Interfaces;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Interfaces;
using TextBasedGame.Shared.Constants;
using TextBasedGame.Shared.Utilities;

namespace TextBasedGame.Item.Handlers
{
    public class InventoryHandler
    {
        // This updates the room and/or player when the exchange of an item occurs
        public static void HandleItemAddOrRemove(Character.Models.Character player, Room.Models.Room currentRoom,
            Items foundItem, bool removeItemFromRoom = false)
        {
            switch (removeItemFromRoom)
            {
                // We are removing an item from a room, adding it to player inventory
                case true:
                    if (foundItem?.InventoryItems != null)
                    {
                        var inventoryItemToAdd = foundItem.InventoryItems.FirstOrDefault();
                        if (player.CarriedItemsCount + 1 <= player.MaximumCarryingCapacity)
                        {
                            AttributeHandler.UpdatePlayerAttributesFromInventoryItem(player, inventoryItemToAdd);
                            Program.ItemCreator.UpdateInventoryItem(inventoryItemToAdd);
                            Program.CharacterCreator.UpdateCharacter(player, itemToAdd: inventoryItemToAdd, addToCarriedCount: 1);
                            Program.RoomCreator.UpdateRoom(currentRoom, currentRoom.RoomEntered, itemToRemove: inventoryItemToAdd);
                            Console.WriteLine();
                            TypingAnimation.Animate("You take the " + inventoryItemToAdd?.ItemName + ".\n", Color.ForestGreen);
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
                            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, weaponItemToAdd);
                            Program.ItemCreator.UpdateWeaponItem(weaponItemToAdd);
                            Program.CharacterCreator.UpdateCharacter(player, weapon: weaponItemToAdd);
                            Program.RoomCreator.UpdateRoom(currentRoom, currentRoom.RoomEntered, weaponToRemove: weaponItemToAdd);
                            Console.WriteLine();
                            TypingAnimation.Animate("You take the " + weaponItemToAdd?.WeaponName + ".\n", Color.ForestGreen);
                        }
                        else
                        {
                            var oldWeapon = player.WeaponItem.WeaponName;
                            DropWeaponAndPickupNew(player, currentRoom, weaponItemToAdd);
                            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, weaponItemToAdd);
                            Program.CharacterCreator.UpdateCharacter(player, weapon: weaponItemToAdd);
                            Program.RoomCreator.UpdateRoom(currentRoom, currentRoom.RoomEntered, weaponToRemove: weaponItemToAdd);
                            Console.WriteLine();
                            TypingAnimation.Animate("You drop your " + oldWeapon + " for the " + weaponItemToAdd?.WeaponName + ".\n",
                                Color.ForestGreen);
                        }
                    }

                    break;

                // We are adding an item to a room, removing/dropping it from player inventory
                case false:
                    if (foundItem?.InventoryItems != null)
                    {
                        var inventoryItemToRemove = foundItem.InventoryItems.FirstOrDefault();
                        DropItemInRoom(player, currentRoom, inventoryItemToRemove);
                        Console.WriteLine();
                        TypingAnimation.Animate("You drop the " + inventoryItemToRemove?.ItemName + ".\n", Color.ForestGreen);
                    }
                    else if (foundItem?.WeaponItems != null)
                    {
                        var weaponItemToRemove = foundItem.WeaponItems.FirstOrDefault();
                        DropWeaponInRoom(player, currentRoom);
                        Console.WriteLine();
                        TypingAnimation.Animate("You drop the " + weaponItemToRemove?.WeaponName + ".\n", Color.ForestGreen);
                    }

                    break;
            }
        }

        public static void DropItemInRoom(Character.Models.Character player, Room.Models.Room room,
            InventoryItem itemToDrop)
        {
            Program.RoomCreator.UpdateRoom(room, room.RoomEntered, itemToAdd: itemToDrop);
            AttributeHandler.UpdatePlayerAttributesFromInventoryItem(player, itemToDrop, true);
            Program.CharacterCreator.UpdateCharacter(player, itemToRemove: itemToDrop, addToCarriedCount: -1);
        }

        public static void DropWeaponInRoom(Character.Models.Character player, Room.Models.Room room)
        {
            Program.RoomCreator.UpdateRoom(room, room.RoomEntered, weaponToAdd: player.WeaponItem);
            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, player.WeaponItem, true);
            Program.CharacterCreator.UpdateCharacter(player, weapon: new WeaponItem());
        }

        private static void DropWeaponAndPickupNew(Character.Models.Character player, Room.Models.Room room,
            WeaponItem weaponToAdd)
        {
            Program.RoomCreator.UpdateRoom(room, room.RoomEntered, weaponToAdd: player.WeaponItem);
            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, player.WeaponItem, true);
            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, weaponToAdd);
            Program.ItemCreator.UpdateWeaponItem(weaponToAdd);
            Program.CharacterCreator.UpdateCharacter(player, weapon: weaponToAdd);
            Program.RoomCreator.UpdateRoom(room, room.RoomEntered, weaponToRemove: weaponToAdd);
        }

        public static Items FindAnyMatchingItemsByKeywords(string inputSubstring, List<string> itemKeywords,
            List<InventoryItem> invItemsToSearch, List<WeaponItem> weaponsToSearch)
        {
            if (inputSubstring.Length == 0)
            {
                return null;
            }
            var words = inputSubstring.Split(ConsoleStrings.StringDelimiters);
            foreach (var word in words)
            {
                if (itemKeywords.Contains(word))
                {
                    Items item;
                    foreach (var inventoryItem in invItemsToSearch)
                    {
                        if (inventoryItem.KeywordsForPickup.Contains(word))
                        {
                            item = new Items()
                            {
                                InventoryItems = new List<InventoryItem>()
                                {
                                    inventoryItem
                                }
                            };
                            return item;
                        }
                    }

                    foreach (var weapon in weaponsToSearch)
                    {
                        if (weapon.KeywordsForPickup.Contains(word))
                        {
                            item = new Items()
                            {
                                WeaponItems = new List<WeaponItem>()
                                {
                                    weapon
                                }
                            };
                            return item;
                        }
                    }
                }
            }

            return null;
        }

        public static List<string> GetAllInventoryItemKeywords(Character.Models.Character player)
        {
            IEnumerable<string> itemKeywords = new List<string>();
            IEnumerable<string> weaponKeywords = new List<string>();
            var keywords = new List<string>();

            if (player?.CarriedItems != null)
            {
                foreach (var item in player.CarriedItems)
                {
                    itemKeywords = (item.KeywordsForPickup.Where(k => !string.IsNullOrEmpty(k)));
                }
            }

            if (!string.IsNullOrEmpty(player?.WeaponItem?.WeaponName))
            {
                weaponKeywords = player.WeaponItem.KeywordsForPickup.Where(k => !string.IsNullOrEmpty(k));
            }

            keywords.AddRange(itemKeywords);
            keywords.AddRange(weaponKeywords);
            return keywords;
        }
    }
}