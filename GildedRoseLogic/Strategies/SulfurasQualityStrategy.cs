using GildedRoseShared.Entities;

namespace GildedRoseLogic.Strategies
{
    public class SulfurasQualityStrategy : IUpdateItemQualityStrategy
    {
        public void UpdateQuality(Item Items)
        {
            // No operation needed for Sulfuras as its Quality and SellIn do not change
        }
    }
}
