using System;
using System.Collections.Generic;
using TextBasedGame.Character.Constants;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character
{
    public class GameCharacters
    {
        // This is where all Characters for the game are defined/instantiated
        // Note: These should only ever be referenced by the CharacterCreator

        public static Models.Character Player = new Models.Character
        {
            Name = null,
            CharacterType = CharacterTypes.Player,
            Attributes = Program.AttributeCreator.PlayerAttributes,
            CarriedItems = new List<InventoryItem>
            {
                Program.ItemCreator.Bathrobe
            }
        };

        public static Models.Character Charlie = new Models.Character
        {
            Name = "Charlie",
            OnMeetDescription = "There's a small boy here, hiding from you in the shadows.",
            CharacterPhrases = new List<string>
            {
                "You ask him his name, he cautiously says \"Charlie.\"",
                "The boy tells you about his toy boat that he lost somewhere on the West side of town.",
                "The boy looks sad... he tells you he lost his favorite toy boat somewhere in town.",
                "You notice he's fiddling with a town gate key.",
                "It looks like he's holding a town gate key in his hands."
            },
            CharacterAppeasedPhrases = new List<string>
            {
                "Charlie seems happy to have his toy boat back."
            },
            CharacterKeywords = new List<string>
            {
                "charlie", "boy", "kid"
            },
            DesiredItem = Program.ItemCreator.ToyBoat,
            OfferedItem = Program.ItemCreator.TownNorthGateKey,
            CharacterType = CharacterTypes.Friendly,
            CurrentRoomName = null,
            MaximumHealthPoints = 30 + 
                                  (CharacterDefaults.HealthPerStaminaPointIncrease * Program.AttributeCreator.CharlieAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            HealthPoints = 30 + 
                           (CharacterDefaults.HealthPerStaminaPointIncrease * Program.AttributeCreator.CharlieAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            Attributes = Program.AttributeCreator.CharlieAttributes
        };

        public static Models.Character Henry = new Models.Character
        {
            Name = "Henry",
            CharacterType = CharacterTypes.Friendly,
            MaximumHealthPoints = CharacterDefaults.DefaultMaximumHealthPoints
                                  + (CharacterDefaults.HealthPerStaminaPointIncrease * Program.AttributeCreator.HenryAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            HealthPoints = CharacterDefaults.DefaultMaximumHealthPoints
                           + (CharacterDefaults.HealthPerStaminaPointIncrease * Program.AttributeCreator.HenryAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            Attributes = Program.AttributeCreator.HenryAttributes,
            WeaponItem = Program.ItemCreator.MagnumRevolver
        };

        public static Models.Character Ghoul = new Models.Character
        {
            Name = "The Ghoul",
            CharacterType = CharacterTypes.Enemy,
            MaximumHealthPoints = CharacterDefaults.DefaultMaximumHealthPoints 
                                  + (CharacterDefaults.HealthPerStaminaPointIncrease * Program.AttributeCreator.GhoulAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            HealthPoints = CharacterDefaults.DefaultMaximumHealthPoints
                           + (CharacterDefaults.HealthPerStaminaPointIncrease * Program.AttributeCreator.GhoulAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            Attributes = Program.AttributeCreator.GhoulAttributes,
            WeaponItem = Program.ItemCreator.GhoulClaws
        };
    }
}