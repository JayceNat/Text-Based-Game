﻿using System.Collections.Generic;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Models
{
    public class CharacterModel
    {
        public string Name { get; set; }

        public int MaximumHealthPoints { get; set; } = 100;

        public int HealthPoints { get; set; } = 100;

        public CharacterAttributeModel Attributes { get; set; }

        public List<InventoryItemModel> CarriedItems { get; set; }

        public int MaximumCarryingCapacity { get; set; } = 4;

        public int CarriedItemsCount { get; set; } = 0;

        public WeaponItemModel WeaponItem { get; set; }
    }
}