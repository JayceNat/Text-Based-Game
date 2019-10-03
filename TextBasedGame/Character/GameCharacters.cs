﻿using TextBasedGame.Character.Constants;

namespace TextBasedGame.Character
{
    public class GameCharacters
    {
        // This is where all Characters for the game are defined/instantiated
        // Note: These should only ever be referenced by the CharacterCreator

        public static Models.Character Player = new Models.Character
        {
            Name = null,
            Attributes = Program.AttributeCreator.PlayerAttributes
        };

        public static Models.Character Henry = new Models.Character
        {
            Name = "Henry",
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
            MaximumHealthPoints = CharacterDefaults.DefaultMaximumHealthPoints 
                                  + (CharacterDefaults.HealthPerStaminaPointIncrease * Program.AttributeCreator.GhoulAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            HealthPoints = CharacterDefaults.DefaultMaximumHealthPoints
                           + (CharacterDefaults.HealthPerStaminaPointIncrease * Program.AttributeCreator.GhoulAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            Attributes = Program.AttributeCreator.GhoulAttributes,
            WeaponItem = Program.ItemCreator.GhoulClaws
        };
    }
}