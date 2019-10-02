﻿using System;
using System.Collections.Generic;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Models
{
    [Serializable]
    public class Character
    {
        public string Name { get; set; }

        public string CurrentLocation { get; set; }

        public int MaximumHealthPoints { get; set; } = Constants.CharacterDefaults.DefaultMaximumHealthPoints;

        public int HealthPoints { get; set; } = Constants.CharacterDefaults.DefaultBaseHealthPoints;

        public CharacterAttribute Attributes { get; set; } = new CharacterAttribute();

        public List<InventoryItem> CarriedItems { get; set; } = new List<InventoryItem>();

        public WeaponItem WeaponItem { get; set; } = new WeaponItem();

        public bool ShowInputHelp { get; set; } = true;
    }
}