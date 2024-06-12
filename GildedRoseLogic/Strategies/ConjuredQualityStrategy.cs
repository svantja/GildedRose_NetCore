using GildedRoseShared.Entities;

namespace GildedRoseLogic.Strategies
{
    public class ConjuredQualityStrategy : IUpdateItemQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 2;
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - 2;
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
