using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TextBasedGame.Character.Constants;
using TextBasedGame.Character.Handlers;
using TextBasedGame.Item.Models;
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
                        var inventoryItemToAddToPlayer = foundItem.InventoryItems.First();
                        if (PickupOrDropItemIsOk(player, foundItem))
                        {
                            AttributeHandler.UpdatePlayerAttributesFromInventoryItem(player, inventoryItemToAddToPlayer);
                            inventoryItemToAddToPlayer.InOriginalLocation = false;
                            player.CarriedItems.Add(inventoryItemToAddToPlayer);
                            player.Attributes.CarriedItemsCount += foundItem.InventoryItems.First().InventorySpaceConsumed;
                            currentRoom.RoomItems.InventoryItems.Remove(inventoryItemToAddToPlayer);
                            Console.WriteLine();
                            TypingAnimation.Animate("You take the " + inventoryItemToAddToPlayer.ItemName + ".\n", Color.ForestGreen);
                        }
                        else
                        {
                            Console.WriteLine();
                            TypingAnimation.Animate("Your inventory is full! \n" +
                                                    "Drop an item to pick up the " + inventoryItemToAddToPlayer?.ItemName + ".\n", Color.DarkOliveGreen);
                        }
                    }
                    else if (foundItem?.WeaponItems != null)
                    {
                        var weaponItemToAddToPlayer = foundItem.WeaponItems.First();
                        if (string.IsNullOrEmpty(player.WeaponItem.WeaponName))
                        {
                            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, weaponItemToAddToPlayer);
                            weaponItemToAddToPlayer.InOriginalLocation = false;
                            player.WeaponItem = weaponItemToAddToPlayer;
                            currentRoom.RoomItems.WeaponItems.Remove(weaponItemToAddToPlayer);
                            Console.WriteLine();
                            TypingAnimation.Animate("You take the " + weaponItemToAddToPlayer?.WeaponName + ".\n", Color.ForestGreen);
                        }
                        else
                        {
                            var oldWeapon = player.WeaponItem.WeaponName.Clone();
                            DropWeaponAndPickupNew(player, currentRoom, weaponItemToAddToPlayer);
                            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, weaponItemToAddToPlayer);
                            player.WeaponItem = weaponItemToAddToPlayer;
                            currentRoom.RoomItems.WeaponItems.Remove(weaponItemToAddToPlayer);
                            Console.WriteLine();
                            TypingAnimation.Animate("You drop your " + oldWeapon + " for the " + weaponItemToAddToPlayer?.WeaponName + ".\n",
                                Color.ForestGreen);
                        }
                    }

                    break;

                // We are adding an item to a room, removing/dropping it from player inventory
                case false:
                    if (foundItem?.InventoryItems != null)
                    {
                        var inventoryItemToRemoveFromPlayer = foundItem.InventoryItems.First();

                        DropItemInRoom(player, currentRoom, inventoryItemToRemoveFromPlayer);
                        Console.WriteLine();
                        TypingAnimation.Animate("You drop the " + inventoryItemToRemoveFromPlayer?.ItemName + ".\n", Color.ForestGreen);
                    }
                    else if (foundItem?.WeaponItems != null)
                    {
                        var weaponItemToRemoveFromPlayer = foundItem.WeaponItems.First();

                        DropWeaponInRoom(player, currentRoom);
                        Console.WriteLine();
                        TypingAnimation.Animate("You drop the " + weaponItemToRemoveFromPlayer?.WeaponName + ".\n", Color.ForestGreen);
                    }

                    break;
            }
        }

        public static bool PickupOrDropItemIsOk(Character.Models.Character player, Items foundItem, bool pickingUpItem = true)
        {
            if (foundItem?.WeaponItems != null)
            {
                return true;
            }

            if (foundItem?.InventoryItems == null) return false;
            if (foundItem.InventoryItems?.First()?.ItemTraits == null 
                && player.Attributes.CarriedItemsCount + foundItem.InventoryItems.First().InventorySpaceConsumed <= player.Attributes.MaximumCarryingCapacity)
                return true;

            foreach (var itemTrait in foundItem.InventoryItems.First().ItemTraits)
            {
                if (pickingUpItem)
                {
                    if (itemTrait.RelevantCharacterAttribute != AttributeStrings.MaxCarryingCapacity
                        && player.Attributes.CarriedItemsCount + foundItem.InventoryItems.First().InventorySpaceConsumed > player.Attributes.MaximumCarryingCapacity)
                    {
                        return false;
                    }

                    if (itemTrait.RelevantCharacterAttribute == AttributeStrings.MaxCarryingCapacity
                        && player.Attributes.MaximumCarryingCapacity + itemTrait.TraitValue < player.Attributes.CarriedItemsCount)
                    {
                        return false;
                    }

                    return itemTrait.RelevantCharacterAttribute != AttributeStrings.CarriedItemsCount 
                           || player.Attributes.CarriedItemsCount + itemTrait.TraitValue <= player.Attributes.MaximumCarryingCapacity;
                }

                else
                {
                    if (itemTrait.RelevantCharacterAttribute != AttributeStrings.MaxCarryingCapacity)
                    {
                        return true;
                    }

                    if (player.Attributes.MaximumCarryingCapacity - itemTrait.TraitValue <
                        player.Attributes.CarriedItemsCount)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void DropItemInRoom(Character.Models.Character player, Room.Models.Room room,
            InventoryItem itemBeingDropped)
        {
            AttributeHandler.UpdatePlayerAttributesFromInventoryItem(player, itemBeingDropped, true);
            player.Attributes.CarriedItemsCount -= itemBeingDropped.InventorySpaceConsumed;
            room.RoomItems.InventoryItems.Add(itemBeingDropped);
            player.CarriedItems.Remove(itemBeingDropped);
        }

        public static void DropWeaponInRoom(Character.Models.Character player, Room.Models.Room room)
        {
            room.RoomItems.WeaponItems.Add(player.WeaponItem);
            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, player.WeaponItem, true);
            player.WeaponItem = new WeaponItem();
        }

        public static void DropWeaponAndPickupNew(Character.Models.Character player, Room.Models.Room room,
            WeaponItem weaponToAddToPlayer)
        {
            room.RoomItems.WeaponItems.Add(player.WeaponItem);
            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, player.WeaponItem, true);
            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, weaponToAddToPlayer);
            weaponToAddToPlayer.InOriginalLocation = false;
            player.WeaponItem = weaponToAddToPlayer;
            room.RoomItems.WeaponItems.Remove(weaponToAddToPlayer);
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
            var keywords = new List<string>();

            if (player?.CarriedItems != null)
            {
                foreach (var item in player.CarriedItems)
                {
                    keywords.AddRange(item.KeywordsForPickup.Where(k => !string.IsNullOrEmpty(k)));
                }
            }

            if (!string.IsNullOrEmpty(player?.WeaponItem?.WeaponName))
            {
                keywords.AddRange(player.WeaponItem.KeywordsForPickup.Where(k => !string.IsNullOrEmpty(k)));
            }

            return keywords;
        }
    }
}