using GildedRoseShared.Entities;

namespace GildedRoseLogic.Strategies
{
    public class DefaultQualityStrategy : IUpdateItemQualityStrategy
    {
        public void UpdateQuality(Item Items)
        {
            if (Items.Quality > 0)
            {
                Items.Quality = Items.Quality - 1;
            }

            Items.SellIn = Items.SellIn - 1;

            if (Items.SellIn < 0)
            {
                if (Items.Quality > 0)
                {
                    Items.Quality = Items.Quality - 1;
                }
            }
        }
    }
}
