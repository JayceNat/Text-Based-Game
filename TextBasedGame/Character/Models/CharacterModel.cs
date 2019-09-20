﻿using System.Collections.Generic;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Models
{
    public class CharacterModel
    {
        public string Name { get; set; }

        public int HealthPoints { get; set; } = 100;

        public CharacterAttributeModel Attributes { get; set; }

        public List<ItemModel> CarriedItems { get; set; }

        public WeaponItemModel WeaponItem { get; set; }
    }
}