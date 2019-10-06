using System.Collections.Generic;
using System.Linq;
using TextBasedGame.Item.Constants;
using TextBasedGame.Item.Handlers;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Models;
using TextBasedGame.Shared.Constants;

namespace TextBasedGame.Shared.Utilities
{
    public class StringDescriptionBuilder
    {
        // Used when user types 'items' or similar command
        public static string CreateStringOfItemDescriptions(Character.Models.Character player, List<InventoryItem> roomItems)
        {
            var itemDescriptions = "";

            if (roomItems != null)
            {
                foreach (var item in roomItems)
                {
                    if (item?.AttributeRequirementToSee != null && !InventoryHandler.PlayerMeetsRequirementForItem(player, false, item))
                    {
                        itemDescriptions += $"{ConsoleStrings.LackingRequirementItemDescription} (<{item.AttributeRequirementToSee.RequirementName}> needed) \n\n";
                    }
                    else if (item.InOriginalLocation)
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
        public static string CreateStringOfWeaponDescriptions(Character.Models.Character player, List<WeaponItem> roomWeapons)
        {
            var weaponDescriptions = "";

            if (roomWeapons != null)
            {
                foreach (var weapon in roomWeapons)
                {
                    if (weapon?.AttributeRequirementToSee != null && !InventoryHandler.PlayerMeetsRequirementForItem(player, false, weaponItem: weapon))
                    {
                        weaponDescriptions += $"{ConsoleStrings.LackingRequirementItemDescription} (<{weapon.AttributeRequirementToSee.RequirementName}> needed) \n\n";
                    }
                    else if (weapon.InOriginalLocation)
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
        public static string CreateStringOfExitDescriptions(Character.Models.Character player, RoomExit roomExits)
        {
            var allRoomExits = "";

            if (roomExits?.NorthRoom != null)
            {
                if (roomExits.NorthRoom?.AttributeRequirementToSee != null 
                    && !PlayerAttributeComparer.ComparePlayerTraitsToAttributeRequirement(player, roomExits.NorthRoom.AttributeRequirementToSee))
                {
                    allRoomExits += $"{ConsoleStrings.LackingRequirementRoomDescription} (<{roomExits.NorthRoom.AttributeRequirementToSee.RequirementName}> needed) \n\n";
                }
                else if (roomExits.NorthRoom?.ItemRequirementToSee != null)
                {
                    var hasItem = false;
                    foreach (var item in player.CarriedItems)
                    {
                        if (item.ItemName == roomExits.NorthRoom.ItemRequirementToSee.RelevantItem.ItemName)
                        {
                            hasItem = true;
                        }
                    }

                    if (hasItem)
                    {
                        allRoomExits += roomExits.NorthRoomDescription + "\n\n";
                    }
                    else
                    {
                        allRoomExits += $"{ConsoleStrings.LackingRequirementRoomDescription} (<{roomExits.NorthRoom.ItemRequirementToSee.RequirementName}> needed) \n\n";
                    }
                }
                else
                {
                    if (roomExits.NorthRoom.RoomEntered)
                    {
                        allRoomExits += roomExits.NorthRoomDescription + " \t(entered)\n\n";
                    }
                    else
                    {
                        allRoomExits += roomExits.NorthRoomDescription + "\n\n";
                    }
                }
            }

            if (roomExits?.EastRoom != null)
            {
                if (roomExits.EastRoom?.AttributeRequirementToSee != null
                    && !PlayerAttributeComparer.ComparePlayerTraitsToAttributeRequirement(player, roomExits.EastRoom.AttributeRequirementToSee))
                {
                    allRoomExits += $"{ConsoleStrings.LackingRequirementRoomDescription} (<{roomExits.EastRoom.AttributeRequirementToSee.RequirementName}> needed) \n\n";
                }
                else if (roomExits.EastRoom?.ItemRequirementToSee != null)
                {
                    var hasItem = false;
                    foreach (var item in player.CarriedItems)
                    {
                        if (item.ItemName == roomExits.EastRoom.ItemRequirementToSee.RelevantItem.ItemName)
                        {
                            hasItem = true;
                        }
                    }

                    if (hasItem)
                    {
                        allRoomExits += roomExits.EastRoomDescription + "\n\n";
                    }
                    else
                    {
                        allRoomExits += $"{ConsoleStrings.LackingRequirementRoomDescription} (<{roomExits.EastRoom.ItemRequirementToSee.RequirementName}> needed) \n\n";
                    }
                }
                else
                {
                    if (roomExits.EastRoom.RoomEntered)
                    {
                        allRoomExits += roomExits.EastRoomDescription + " \t(entered)\n\n";
                    }
                    else
                    {
                        allRoomExits += roomExits.EastRoomDescription + "\n\n";
                    }
                }
            }

            if (roomExits?.SouthRoom != null)
            {
                if (roomExits.SouthRoom?.AttributeRequirementToSee != null
                    && !PlayerAttributeComparer.ComparePlayerTraitsToAttributeRequirement(player, roomExits.SouthRoom.AttributeRequirementToSee))
                {
                    allRoomExits += $"{ConsoleStrings.LackingRequirementRoomDescription} (<{roomExits.SouthRoom.AttributeRequirementToSee.RequirementName}> needed) \n\n";
                }
                else if (roomExits.SouthRoom?.ItemRequirementToSee != null)
                {
                    var hasItem = false;
                    foreach (var item in player.CarriedItems)
                    {
                        if (item.ItemName == roomExits.SouthRoom.ItemRequirementToSee.RelevantItem.ItemName)
                        {
                            hasItem = true;
                        }
                    }

                    if (hasItem)
                    {
                        allRoomExits += roomExits.SouthRoomDescription + "\n\n";
                    }
                    else
                    {
                        allRoomExits += $"{ConsoleStrings.LackingRequirementRoomDescription} (<{roomExits.SouthRoom.ItemRequirementToSee.RequirementName}> needed) \n\n";
                    }
                }
                else
                {
                    if (roomExits.SouthRoom.RoomEntered)
                    {
                        allRoomExits += roomExits.SouthRoomDescription + " \t(entered)\n\n";
                    }
                    else
                    {
                        allRoomExits += roomExits.SouthRoomDescription + "\n\n";
                    }
                }
            }

            if (roomExits?.WestRoom != null)
            {
                if (roomExits.WestRoom?.AttributeRequirementToSee != null
                    && !PlayerAttributeComparer.ComparePlayerTraitsToAttributeRequirement(player, roomExits.WestRoom.AttributeRequirementToSee))
                {
                    allRoomExits += $"{ConsoleStrings.LackingRequirementRoomDescription} (<{roomExits.WestRoom.AttributeRequirementToSee.RequirementName}> needed) \n\n";
                }
                else if (roomExits.WestRoom?.ItemRequirementToSee != null)
                {
                    var hasItem = false;
                    foreach (var item in player.CarriedItems)
                    {
                        if (item.ItemName == roomExits.WestRoom.ItemRequirementToSee.RelevantItem.ItemName)
                        {
                            hasItem = true;
                        }
                    }

                    if (hasItem)
                    {
                        allRoomExits += roomExits.WestRoomDescription + "\n\n";
                    }
                    else
                    {
                        allRoomExits += $"{ConsoleStrings.LackingRequirementRoomDescription} (<{roomExits.WestRoom.ItemRequirementToSee.RequirementName}> needed) \n\n";
                    }
                }
                else
                {
                    if (roomExits.WestRoom.RoomEntered)
                    {
                        allRoomExits += roomExits.WestRoomDescription + " \t(entered)\n\n";
                    }
                    else
                    {
                        allRoomExits += roomExits.WestRoomDescription + "\n\n";
                    }
                }
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
                inventory += "\n\tWorn Items (these do not consume space): \n";
                var carriedItems = "\n\tCarried Items: \n";

                foreach (var item in inventoryItems)
                {
                    if (item.TreatItemAs == ItemUseTypes.Bag || item.TreatItemAs == ItemUseTypes.Wearable)
                    {
                        inventory += "\n\t\t-" + item.ItemName + "\n";
                        if (displayDescription)
                        {
                            inventory += "\t\t\t" + item.ItemDescription + "\n";
                        }
                        if (item.ItemTraits != null)
                        {
                            foreach (var trait in item.ItemTraits)
                            {
                                if (trait.TraitName != "")
                                {
                                    inventory += "\t\t\tTrait: \t" + trait.TraitName + "\n";
                                }
                            }
                        }
                    }
                    else
                    {
                        carriedItems += "\n\t\t-" + item.ItemName + "\n";
                        if (displayDescription)
                        {
                            carriedItems += "\t\t\t" + item.ItemDescription + "\n";
                        }
                        if (item.ItemTraits != null)
                        {
                            foreach (var trait in item.ItemTraits)
                            {
                                if (trait.TraitName != "")
                                {
                                    carriedItems += "\t\t\tTrait: \t" + trait.TraitName + "\n";
                                }
                            }
                        }
                    }
                }

                inventory += carriedItems;
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