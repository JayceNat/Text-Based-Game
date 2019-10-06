using TextBasedGame.Character.Constants;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Implementations
{
    public class ItemTraitCreator : IItemTraitCreator
    {
        // These are the generic Item Trait creators
        public ItemTrait BatteryPercentage(int percent)
        {
            return new ItemTrait
            {
                TraitName = $"Battery - {percent}%",
                RelevantCharacterAttribute = "",
                TraitValue = percent
            };
        }

        public ItemTrait BatteryItem(int newBatteryPercent)
        {
            return new ItemTrait
            {
                TraitName = $"This item has ({newBatteryPercent}%) battery",
                RelevantCharacterAttribute = "",
                TraitValue = newBatteryPercent
            };
        }

        public ItemTrait HealthItem(int healthRestored)
        {
            return new ItemTrait
            {
                TraitName = $"Use: restores ({healthRestored}) Health Points",
                RelevantCharacterAttribute = "",
                TraitValue = healthRestored
            };
        }

        public ItemTrait ConsumedAttributeItem(string relevantAttribute, int traitValue)
        {
            return new ItemTrait
            {
                TraitName = traitValue >= 0 ? $"Use: increases {relevantAttribute} by ({traitValue})" : $"Use: decreases {relevantAttribute} by ({traitValue})",
                RelevantCharacterAttribute = relevantAttribute,
                TraitValue = traitValue
            };
        }

        public ItemTrait CarriedItemsIncrease(int amount)
        {
            return new ItemTrait
            {
                TraitName = amount == 0 ? "This item does not consume inventory space." : $"Consumes ({amount}) inventory spaces.",
                RelevantCharacterAttribute = AttributeStrings.CarriedItemsCount,
                TraitValue = amount
            };
        }

        public ItemTrait CarryingCapacityIncrease(int amount)
        {
            return new ItemTrait
            {
                TraitName = amount < 0 ? $"Inventory Space - ({amount})" : $"Inventory Space + ({amount})!",
                RelevantCharacterAttribute = AttributeStrings.MaxCarryingCapacity,
                TraitValue = amount
            };
        }

        public ItemTrait DefenseIncrease(int amount)
        {
            return new ItemTrait
            {
                TraitName = amount < 0 ? $"Defense - ({amount})" : $"Defense + ({amount})!",
                RelevantCharacterAttribute = AttributeStrings.Defense,
                TraitValue = amount
            };
        }

        public ItemTrait DexterityIncrease(int amount)
        {
            return new ItemTrait
            {
                TraitName = amount < 0 ? $"Dexterity - ({amount})" : $"Dexterity + ({amount})!",
                RelevantCharacterAttribute = AttributeStrings.Dexterity,
                TraitValue = amount
            };
        }

        public ItemTrait LuckIncrease(int amount)
        {
            return new ItemTrait
            {
                TraitName = amount < 0 ? $"Luck - ({amount})" : $"Luck + ({amount})!",
                RelevantCharacterAttribute = AttributeStrings.Luck,
                TraitValue = amount
            };
        }

        public ItemTrait StaminaIncrease(int amount)
        {
            return new ItemTrait
            {
                TraitName = amount < 0 ? $"Stamina - ({amount})" : $"Stamina + ({amount})!",
                RelevantCharacterAttribute = AttributeStrings.Stamina,
                TraitValue = amount
            };
        }

        public ItemTrait StrengthIncrease(int amount)
        {
            return new ItemTrait
            {
                TraitName = amount < 0 ? $"Strength - ({amount})" : $"Strength + ({amount})!",
                RelevantCharacterAttribute = AttributeStrings.Strength,
                TraitValue = amount
            };
        }

        public ItemTrait WisdomIncrease(int amount)
        {
            return new ItemTrait
            {
                TraitName = amount < 0 ? $"Wisdom - ({amount})" : $"Wisdom + ({amount})!",
                RelevantCharacterAttribute = AttributeStrings.Wisdom,
                TraitValue = amount
            };
        }
    }
}