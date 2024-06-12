using GildedRoseShared.Entities;

namespace GildedRoseLogic.Strategies
{
    public class AgedBrieQualityStrategy : IUpdateItemQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.Quality = item.Quality < 50 ? item.Quality + 1 : item.Quality;
            item.SellIn--;

            if (item.SellIn < 0 && item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }
}
