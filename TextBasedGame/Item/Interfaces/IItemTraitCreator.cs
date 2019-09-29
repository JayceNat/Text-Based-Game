using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Interfaces
{
    public interface IItemTraitCreator
    {
        ItemTrait BatteryPercentage(int percent);

        ItemTrait BatteryItem(int newBatteryPercent);

        ItemTrait HealthItem(int healthRestored);

        ItemTrait CarriedItemsIncrease(int amount);

        ItemTrait CarryingCapacityIncrease(int amount);

        ItemTrait DefenseIncrease(int amount);

        ItemTrait DexterityIncrease(int amount);

        ItemTrait LuckIncrease(int amount);

        ItemTrait StaminaIncrease(int amount);

        ItemTrait StrengthIncrease(int amount);

        ItemTrait WisdomIncrease(int amount);
    }
}