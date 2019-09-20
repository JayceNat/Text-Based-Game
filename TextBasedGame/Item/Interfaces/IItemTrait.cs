﻿using TextBasedGame.Character.Models;
using TextBasedGame.Constants;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Interfaces
{
    public interface IItemTrait
    {
        ItemTraitModel CreateItemTrait(string name, CharacterAttributes relevantCharacterAttribute, int traitValue);
    }
}