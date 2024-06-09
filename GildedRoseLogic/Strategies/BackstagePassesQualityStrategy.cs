using GildedRoseShared.Entities;

namespace GildedRoseLogic.Strategies
{
    public class BackstagePassesQualityStrategy : IUpdateItemQualityStrategy
    {
        public void UpdateQuality(Item Items)
        {
            if (Items.Quality < 50)
            {
                Items.Quality = Items.Quality + 1;

                if (Items.SellIn < 11)
                {
                    if (Items.Quality < 50)
                    {
                        Items.Quality = Items.Quality + 1;
                    }
                }

                if (Items.SellIn < 6)
                {
                    if (Items.Quality < 50)
                    {
                        Items.Quality = Items.Quality + 1;
                    }
                }
            }

            Items.SellIn = Items.SellIn - 1;

            if (Items.SellIn < 0)
            {
                Items.Quality = 0;
            }
        }
    }
}
