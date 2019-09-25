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
        private static readonly ICharacterCreator CharacterCreator = new Character.Implementations.CharacterCreator();
        private static readonly IRoomCreator RoomCreator = new Room.Implementations.RoomCreator();
        private static readonly IItemCreator ItemCreator = new Implementations.ItemCreator();

        public static Tuple<Character.Models.Character, Room.Models.Room> HandleItemAddOrRemove(Character.Models.Character player, 
            Room.Models.Room currentRoom, Items foundItem, bool removeItem = false)
        {
            switch (removeItem)
            {
                case true:
                    if (foundItem?.InventoryItems != null)
                    {
                        var inventoryItemToAdd = foundItem.InventoryItems.FirstOrDefault();
                        if (player.CarriedItemsCount + 1 <= player.MaximumCarryingCapacity)
                        {
                            player = AttributeHandler.UpdatePlayerAttributesFromInventoryItem(player, inventoryItemToAdd);
                            inventoryItemToAdd = ItemCreator.UpdateInventoryItem(inventoryItemToAdd);
                            player = CharacterCreator.UpdateCharacter(player, itemToAdd: inventoryItemToAdd, addToCarriedCount: 1);
                            currentRoom = RoomCreator.UpdateRoom(currentRoom, currentRoom.RoomEntered, itemToRemove: inventoryItemToAdd);
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
                            player = AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, weaponItemToAdd);
                            weaponItemToAdd = ItemCreator.UpdateWeaponItem(weaponItemToAdd);
                            player = CharacterCreator.UpdateCharacter(player, weapon: weaponItemToAdd);
                            currentRoom = RoomCreator.UpdateRoom(currentRoom, currentRoom.RoomEntered, weaponToRemove: weaponItemToAdd);
                            Console.WriteLine();
                            TypingAnimation.Animate("You take the " + weaponItemToAdd.WeaponName + ".\n", Color.ForestGreen);
                        }
                        else
                        {
                            var oldWeapon = player.WeaponItem.WeaponName;
                            var playerAndRoom = DropWeaponAndPickupNew(player, currentRoom, weaponItemToAdd);
                            player = playerAndRoom.Item1;
                            currentRoom = playerAndRoom.Item2;
                            player = AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, weaponItemToAdd);
                            player = CharacterCreator.UpdateCharacter(player, weapon: weaponItemToAdd);
                            currentRoom = RoomCreator.UpdateRoom(currentRoom, currentRoom.RoomEntered, weaponToRemove: weaponItemToAdd);
                            Console.WriteLine();
                            TypingAnimation.Animate("You drop your " + oldWeapon + " for the " + weaponItemToAdd?.WeaponName + ".\n",
                                Color.ForestGreen);
                        }
                    }

                    break;

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
            

            return Tuple.Create(player, currentRoom);
        }

        public static Tuple<Character.Models.Character, Room.Models.Room> DropItemInRoom(Character.Models.Character player, Room.Models.Room room, InventoryItem itemToDrop)
        {
            room = RoomCreator.UpdateRoom(room, room.RoomEntered, itemToAdd: itemToDrop);
            player = AttributeHandler.UpdatePlayerAttributesFromInventoryItem(player, itemToDrop, true);
            player = CharacterCreator.UpdateCharacter(player, itemToRemove: itemToDrop, addToCarriedCount: -1);
            return Tuple.Create(player, room);
        }

        public static Tuple<Character.Models.Character, Room.Models.Room> DropWeaponInRoom(Character.Models.Character player, Room.Models.Room room)
        {
            room = RoomCreator.UpdateRoom(room, room.RoomEntered, weaponToAdd: player.WeaponItem);
            player = AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, player.WeaponItem, true);
            player = CharacterCreator.UpdateCharacter(player, weapon: new WeaponItem());
            return Tuple.Create(player, room);
        }

        private static Tuple<Character.Models.Character, Room.Models.Room> DropWeaponAndPickupNew(Character.Models.Character player, 
            Room.Models.Room room, WeaponItem weaponToAdd)
        {
            room = RoomCreator.UpdateRoom(room, room.RoomEntered, weaponToAdd: player.WeaponItem);
            player = AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, player.WeaponItem, true);
            player = AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, weaponToAdd);
            weaponToAdd = ItemCreator.UpdateWeaponItem(weaponToAdd);
            player = CharacterCreator.UpdateCharacter(player, weapon: weaponToAdd);
            room = RoomCreator.UpdateRoom(room, room.RoomEntered, weaponToRemove: weaponToAdd);
            return Tuple.Create(player, room);
        }

        public static Models.Items FindAnyMatchingItemsByKeywords(string inputSubstring, List<string> itemKeywords, 
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
                    Models.Items item;
                    foreach (var inventoryItem in invItemsToSearch)
                    {
                        if (inventoryItem.KeywordsForPickup.Contains(word))
                        {
                            item = new Models.Items()
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
                            item = new Models.Items()
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

        public static bool HandleItemAndUpdatePlayerAndRoom(Character.Models.Character player, Room.Models.Room currentRoom, Items foundItem, bool removeItem = false)
        {
            var updatedPlayerAndRoom = removeItem
                ? HandleItemAddOrRemove(player, currentRoom, foundItem)
                : HandleItemAddOrRemove(player, currentRoom, foundItem, true);

            player = updatedPlayerAndRoom.Item1;
            currentRoom = updatedPlayerAndRoom.Item2;
            return true;
        }
    }
}