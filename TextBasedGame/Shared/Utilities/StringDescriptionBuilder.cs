using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Shared.Utilities
{
    public class StringDescriptionBuilder
    {
        // Used when user types 'items' or similar command
        public static string CreateStringOfItemDescriptions(List<InventoryItem> roomItems)
        {
            var itemDescriptions = "";

            if (roomItems != null)
            {
                foreach (var item in roomItems)
                {
                    if (item.InOriginalLocation)
                    {
                        itemDescriptions += item.OriginalPlacementDescription + "\n\n";
                    }
                    else
                    {
                        itemDescriptions += item.GenericPlacementDescription + "\n\n";
                    }
                }
            }

            return itemDescriptions;
        }

        // Used when user types 'weapons' or similar command
        public static string CreateStringOfWeaponDescriptions(List<WeaponItem> roomWeapons)
        {
            var weaponDescriptions = "";

            if (roomWeapons != null)
            {
                foreach (var weapon in roomWeapons)
                {
                    if (weapon.InOriginalLocation)
                    {
                        weaponDescriptions += weapon.OriginalPlacementDescription + "\n\n";
                    }
                    else
                    {
                        weaponDescriptions += weapon.GenericPlacementDescription + "\n\n";
                    }
                }
            }

            return weaponDescriptions;
        }

        // Used when user types 'exits' or similar command
        public static string CreateStringOfExitDescriptions(RoomExit roomExits)
        {
            var allRoomExits = "";

            if (roomExits?.NorthRoom != null)
            {
                allRoomExits += roomExits.NorthRoomDescription + "\n\n";
            }

            if (roomExits?.EastRoom != null)
            {
                allRoomExits += roomExits.EastRoomDescription + "\n\n";
            }

            if (roomExits?.SouthRoom != null)
            {
                allRoomExits += roomExits.SouthRoomDescription + "\n\n";
            }

            if (roomExits?.WestRoom != null)
            {
                allRoomExits += roomExits.WestRoomDescription + "\n\n";
            }

            return allRoomExits;
        }

        // Used when user types 'inventory' or similar command
        public static string CreateStringOfPlayerInventory(Character.Models.Character player, bool displayDescription)
        {
            var weaponName = player.WeaponItem?.WeaponName;
            var inventoryItems = player.CarriedItems;
            var inventory = player.Name + "'s Inventory (" + player.Attributes.CarriedItemsCount + "/" + player.Attributes.MaximumCarryingCapacity + "): \n";
            if (!string.IsNullOrEmpty(weaponName))
            {
                inventory += "\n\tHeld Weapon: " + player.WeaponItem.WeaponName + "\n";
                if (displayDescription)
                {
                    inventory += "\t\t" + player.WeaponItem.WeaponDescription + "\n" +
                                 "\t\tAttack Power: \t" + player.WeaponItem.AttackPower + "\n";
                    if (player.WeaponItem?.AmmunitionAmount >= 0)
                    {
                        inventory += "\t\tAmmo: \t" + player.WeaponItem.AmmunitionAmount + "\n";
                    }
                    if (player.WeaponItem?.WeaponTraits != null)
                    {
                        foreach (var trait in player.WeaponItem.WeaponTraits)
                        {
                            inventory += "\t\tTrait: \t" + trait.TraitName + "\n";
                        }
                    }
                }
            }

            if (player.CarriedItems.Count != 0)
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

            if (string.IsNullOrEmpty(player.WeaponItem?.WeaponName) && player.CarriedItems.Count == 0)
            {
                inventory += "\n\t<empty> \n";
            }

            return inventory;
        }

        // Used when user types 'status' or similar command
        public static string CreateStringOfPlayerInfo(Character.Models.Character player)
        {
            return player.Name + "'s Status: \n" +
                                "\t - Health points: \t" + player.HealthPoints + "/" + player.MaximumHealthPoints + "\n" +
                                "\t - Inventory Space: \t" + player.Attributes.CarriedItemsCount + "/" + player.Attributes.MaximumCarryingCapacity + "\n" +
                                "\t - Defense: \t\t" + (player.Attributes.Defense == 0 ? "-" : player.Attributes.Defense.ToString()) + "\n" +
                                "\t - Dexterity: \t\t" + (player.Attributes.Dexterity == 0 ? "-" : player.Attributes.Dexterity.ToString()) + "\n" +
                                "\t - Luck: \t\t" + (player.Attributes.Luck == 0 ? "-" : player.Attributes.Luck.ToString()) + "\n" +
                                "\t - Stamina: \t\t" + (player.Attributes.Stamina == 0 ? "-" : player.Attributes.Stamina.ToString()) + "\n" +
                                "\t - Strength: \t\t" + (player.Attributes.Strength == 0 ? "-" : player.Attributes.Strength.ToString()) + "\n" +
                                "\t - Wisdom: \t\t" + (player.Attributes.Wisdom == 0 ? "-" : player.Attributes.Wisdom.ToString()) + "\n";
        }
    }
}