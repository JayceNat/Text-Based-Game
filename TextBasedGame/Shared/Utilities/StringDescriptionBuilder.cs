﻿using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Shared.Utilities
{
    public class StringDescriptionBuilder
    {
        public static string CreateStringOfItemDescriptions(List<InventoryItem> roomItems)
        {
            var itemDescriptions = "";

            if (roomItems != null)
            {
                foreach (var item in roomItems)
                {
                    if (item.InOriginalLocation)
                    {
                        itemDescriptions += item.OriginalPlacementDescription + '\n';
                    }
                    else
                    {
                        itemDescriptions += item.GenericPlacementDescription + "\n";
                    }
                }
            }

            return itemDescriptions;
        }

        public static string CreateStringOfWeaponDescriptions(List<WeaponItem> roomWeapons)
        {
            var weaponDescriptions = "";

            if (roomWeapons != null)
            {
                foreach (var weapon in roomWeapons)
                {
                    if (weapon.InOriginalLocation)
                    {
                        weaponDescriptions += weapon.OriginalPlacementDescription + '\n';
                    }
                    else
                    {
                        weaponDescriptions += weapon.GenericPlacementDescription + '\n';
                    }
                }
            }

            return weaponDescriptions;
        }

        public static string CreateStringOfExitDescriptions(RoomExit roomExits)
        {
            var allRoomExits = "";

            if (roomExits?.NorthRoom != null)
            {
                allRoomExits += roomExits.NorthRoom.AsExitDescription + '\n';
            }

            if (roomExits?.EastRoom != null)
            {
                allRoomExits += roomExits.EastRoom.AsExitDescription + '\n';
            }

            if (roomExits?.SouthRoom != null)
            {
                allRoomExits += roomExits.SouthRoom.AsExitDescription + '\n';
            }

            if (roomExits?.WestRoom != null)
            {
                allRoomExits += roomExits.WestRoom.AsExitDescription + '\n';
            }

            return allRoomExits;
        }

        public static string CreateStringOfPlayerInventory(Character.Models.Character player, bool displayDescription)
        {
            var weaponName = player.WeaponItem?.WeaponName;
            var inventoryItems = player.CarriedItems;
            var inventory = player.Name + "'s Inventory (" + player.CarriedItemsCount + "/" + player.MaximumCarryingCapacity + "): \n";
            if (!string.IsNullOrEmpty(weaponName))
            {
                inventory += "\n\tHeld Weapon: " + player.WeaponItem.WeaponName + "\n";
                if (displayDescription)
                {
                    inventory += "\t\t" + player.WeaponItem.WeaponDescription + "\n" +
                                 "\t\tAttack Power: \t" + player.WeaponItem.AttackPower + "\n";
                    if (player.WeaponItem?.WeaponTraits != null)
                    {
                        foreach (var trait in player.WeaponItem.WeaponTraits)
                        {
                            inventory += "\t\tTrait: \t" + trait.TraitName + "\n";
                        }
                    }
                }
            }

            if (player.CarriedItemsCount != 0)
            {
                foreach (var item in inventoryItems)
                {
                    inventory += "\n\t - " + item.ItemName + "\n";
                    if (displayDescription)
                    {
                        inventory += "\t\t" + item.ItemDescription + "\n";
                    }
                    if (item.ItemTraits != null)
                    {
                        foreach (var trait in item.ItemTraits)
                        {
                            inventory += "\t\tTrait: \t" + trait.TraitName + "\n";
                        }
                    }
                }

            }

            if (string.IsNullOrEmpty(player.WeaponItem?.WeaponName) && player.CarriedItemsCount == 0)
            {
                inventory += "\n\t<empty> \n";
            }

            return inventory;
        }

        public static string CreateStringOfPlayerInfo(Character.Models.Character player)
        {
            return player.Name + "'s Status: \n" +
                                "\t - Health points: \t" + player.HealthPoints + "/" + player.MaximumHealthPoints + "\n" +
                                "\t - Inventory Space: \t" + player.CarriedItemsCount + "/" + player.MaximumCarryingCapacity + "\n" +
                                "\t - Defense: \t\t" + player.Attributes.Defense + "\n" +
                                "\t - Dexterity: \t\t" + player.Attributes.Dexterity + "\n" +
                                "\t - Luck: \t\t" + player.Attributes.Luck + "\n" +
                                "\t - Stamina: \t\t" + player.Attributes.Stamina + "\n" +
                                "\t - Strength: \t\t" + player.Attributes.Strength + "\n" +
                                "\t - Wisdom: \t\t" + player.Attributes.Wisdom + "\n";
        }
    }
}