﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.SaveGameConverters;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Room.Models
{
    [TypeConverter(typeof(RoomConverter))]
    [SettingsSerializeAs(SettingsSerializeAs.String)]
    public class Room
    {
        public string RoomName { get; set; }

        public bool RoomEntered { get; set; } = false;

        public string InitialRoomDescription { get; set; }

        public string GenericRoomDescription { get; set; }

        public string AsExitDescription { get; set; }

        public RoomExit AvailableExits { get; set; } = new RoomExit();

        public Items RoomItems { get; set; } = 
            new Items() { InventoryItems = new List<InventoryItem>(), WeaponItems = new List<WeaponItem>()};

        public List<string> KeywordsToEnter { get; set; } = new List<string>();

        public AttributeRequirement AttributeRequirementToSee { get; set; } = null;

        public ItemRequirement ItemRequirementToSee { get; set; } = null;

        public AttributeRequirement AttributeRequirementToEnter { get; set; } = null;

        public ItemRequirement ItemRequirementToEnter { get; set; } = null;
    }
}