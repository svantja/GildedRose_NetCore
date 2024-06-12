using GildedRoseShared.Entities;

namespace GildedRoseLogic.Strategies
{
    public class SulfurasQualityStrategy : IUpdateItemQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn = item.SellIn;
            item.Quality = item.Quality;
        }
    }
}
