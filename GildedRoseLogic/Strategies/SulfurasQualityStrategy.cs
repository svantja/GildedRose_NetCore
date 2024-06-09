using GildedRoseShared.Entities;

namespace GildedRoseLogic.Strategies
{
    public class SulfurasQualityStrategy : IUpdateItemQualityStrategy
    {
        public void UpdateQuality(Item Items)
        {
            Items.SellIn = Items.SellIn;
            Items.Quality = Items.Quality;
        }
    }
}
