using GildedRoseShared.Entities;

namespace GildedRoseLogic.Strategies
{
    public class ConjuredQualityStrategy : IUpdateItemQualityStrategy
    {
        public void UpdateQuality(Item Items)
        {
            if (Items.Quality > 0)
            {
                Items.Quality = Items.Quality - 2;
            }

            Items.SellIn = Items.SellIn - 1;

            if (Items.SellIn < 0)
            {
                Items.Quality = Items.Quality - 2;
            }

            if (Items.Quality < 0)
            {
                Items.Quality = 0;
            }
        }
    }
}
