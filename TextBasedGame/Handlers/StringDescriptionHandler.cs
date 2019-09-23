using System.Collections.Generic;
using TextBasedGame.Character.Models;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Handlers
{
    public class StringDescriptionHandler
    {
        public static string CreateStringOfItemDescriptions(List<InventoryItemModel> roomItems)
        {
            string itemDescriptions = "";

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

            return itemDescriptions;
        }

        public static string CreateStringOfWeaponDescriptions(List<WeaponItemModel> roomWeapons)
        {
            string weaponDescriptions = "";

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

            return weaponDescriptions;
        }

        public static string CreateStringOfExitDescriptions(List<RoomExitModel> roomExits)
        {
            string allRoomItems = "";

            foreach (var exit in roomExits)
            {
                allRoomItems += exit.ExitDescription + '\n';
            }

            return allRoomItems;
        }

        public static string CreateStringOfPlayerInventory(CharacterModel player, bool displayDescription)
        {
            string weaponName = player.WeaponItem?.WeaponName;
            List<InventoryItemModel> inventoryItems = player.CarriedItems;
            string inventory = player.Name + "'s Inventory (" + player.CarriedItemsCount + "/" + player.MaximumCarryingCapacity + "): ";
            if (!string.IsNullOrEmpty(weaponName))
            {
                inventory += "\n\n\tHeld Weapon: " + player.WeaponItem.WeaponName + "\n";
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
                inventory += "<empty> \n";
            }

            return inventory;
        }

        public static string CreateStringOfPlayerInfo(CharacterModel player)
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