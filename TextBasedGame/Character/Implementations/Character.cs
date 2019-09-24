using System.Collections.Generic;
using TextBasedGame.Character.Interfaces;
using TextBasedGame.Character.Models;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Implementations
{
    public class Character : ICharacter
    {
        public Models.Character CreateCharacter(CharacterAttribute attributes, string name = null,
            List<InventoryItem> items = null, WeaponItem weapon = null, int baseHP = 100, int baseCarryingCapacity = 4)
        {
            var player = new Models.Character
            {
                Name = name,
                MaximumHealthPoints = baseHP,
                HealthPoints = baseHP,
                Attributes = attributes,
                CarriedItems = items == null ? new List<InventoryItem>() : items,
                MaximumCarryingCapacity = baseCarryingCapacity,
                CarriedItemsCount = items == null ? 0 : items.Count,
                WeaponItem = weapon == null ? new WeaponItem() : weapon
            };

            return player;
        }

        public Models.Character UpdateCharacter(Models.Character character, string name = null, CharacterAttribute attributes = null,
            InventoryItem itemToAdd = null, InventoryItem itemToRemove = null, WeaponItem weapon = null, 
            int increaseMaxHealth = 0, int addToHealth = 0, int increaseMaxCarryingCapacity = 0, int addToCarriedCount = 0)
        {
            if (name != null)
            {
                character.Name = name;
            }

            if (increaseMaxHealth != 0)
            {
                character.MaximumHealthPoints += increaseMaxHealth;
                character.HealthPoints += increaseMaxHealth;
            }

            if (addToHealth != 0)
            {
                character.HealthPoints += addToHealth;
            }

            if (attributes != null)
            {
                character.Attributes = attributes;
            }

            if (itemToAdd != null)
            {
                character.CarriedItems.Add(itemToAdd);
            }

            if (itemToRemove != null)
            {
                character.CarriedItems.Remove(itemToRemove);
            }

            if (increaseMaxCarryingCapacity != 0)
            {
                character.MaximumCarryingCapacity += increaseMaxCarryingCapacity;
            }

            if (addToCarriedCount != 0)
            {
                character.CarriedItemsCount += addToCarriedCount;
            }

            if (weapon != null)
            {
                character.WeaponItem = weapon;
            }
            
            return character;
        }
    }
}