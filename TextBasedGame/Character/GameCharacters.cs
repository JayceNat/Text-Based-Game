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
            CharacterType = CharacterTypes.Friendly,
            CurrentRoomName = null,
            MaximumHealthPoints = 30 + 
                                  (CharacterDefaults.HealthPerStaminaPointIncrease * Program.AttributeCreator.CharlieAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            HealthPoints = 30 + 
                           (CharacterDefaults.HealthPerStaminaPointIncrease * Program.AttributeCreator.CharlieAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            Attributes = Program.AttributeCreator.CharlieAttributes,
            CarriedItems = null
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