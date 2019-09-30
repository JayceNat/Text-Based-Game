using System.Collections.Generic;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Shared.Utilities
{
    public class FlashlightBatteryUpdate
    {
        public static void FlashlightBatteryChange(InventoryItem item, int percentBefore = 0, int percentToReduce = 0, int percentToSet = -1)
        {
            if (percentToSet > -1)
            {
                item.ItemTraits = new List<ItemTrait>
                {
                    Program.ItemTraitCreator.BatteryPercentage(percentToSet)
                };
            }
            else if (percentToReduce > 0)
            {
                if (percentBefore - percentToReduce < 0)
                {
                    item.ItemTraits = new List<ItemTrait>
                    {
                        Program.ItemTraitCreator.BatteryPercentage(0)
                    };
                }
                else
                {
                    item.ItemTraits = new List<ItemTrait>
                    {
                        Program.ItemTraitCreator.BatteryPercentage(percentBefore - percentToReduce)
                    };
                }
            }
        }
    }
}