using GildedRoseShared.Entities;

namespace GildedRoseLogic.Strategies
{
    public class AgedBrieQualityStrategy : IUpdateItemQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }
    }
}
