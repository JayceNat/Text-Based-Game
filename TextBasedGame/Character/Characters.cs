using TextBasedGame.Character.Interfaces;
using TextBasedGame.Character.Models;
using TextBasedGame.Item;

namespace TextBasedGame.Character
{
    public class Characters
    {
        private static readonly ICharacter Character = new Implementations.Character();

        public static CharacterModel Ghoul = Character.CreateCharacter(
            name: "The Ghoul",
            attributes: Attributes.GhoulAttributes,
            baseHP: 100 + (15 * Attributes.GhoulAttributes.Stamina - 3),
            weapon: Weapons.GhoulClaws);
    }
}