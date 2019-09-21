using System.Collections.Generic;
using TextBasedGame.Character.Interfaces;
using TextBasedGame.Character.Models;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Implementations
{
    public class Character : ICharacter
    {
        public CharacterModel CreateCharacter(CharacterAttributeModel attributes, string name = null,
            List<InventoryItemModel> items = null, WeaponItemModel weapon = null, int baseHP = 100)
        {
            CharacterModel player = new CharacterModel
            {
                Name = name,
                MaximumHealthPoints = baseHP,
                HealthPoints = baseHP,
                Attributes = attributes,
                CarriedItems = items,
                WeaponItem = weapon
            };

            return player;
        }

        public CharacterModel UpdateCharacter(CharacterModel character, string name = null, CharacterAttributeModel attributes = null,
            List<InventoryItemModel> items = null, WeaponItemModel weapon = null, int increaseMaxHealth = 0, int addToHealth = 0)
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

            if (items != null)
            {
                character.CarriedItems = items;
            }

            if (weapon != null)
            {
                character.WeaponItem = weapon;
            }
            
            return character;
        }
    }
}