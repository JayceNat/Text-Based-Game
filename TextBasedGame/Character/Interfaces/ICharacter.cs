using System.Collections.Generic;
using TextBasedGame.Character.Models;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Interfaces
{
    public interface ICharacter
    {
        CharacterModel CreateCharacter(CharacterAttributeModel attributes, string name = null,
            List<ItemModel> items = null, WeaponItemModel weapon = null, int baseHP = 100);

        CharacterModel UpdateCharacter(CharacterModel character, string name, CharacterAttributeModel attributes,
            List<ItemModel> items, WeaponItemModel weapon, int addToHealth);
    }
}