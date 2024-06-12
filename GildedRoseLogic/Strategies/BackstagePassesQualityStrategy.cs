using GildedRoseShared.Entities;

namespace GildedRoseLogic.Strategies
{
    public class BackstagePassesQualityStrategy : IUpdateItemQualityStrategy
    {
        public void UpdateQuality(Item Items)
        {
            if (Items.Quality < 50)
            {
                Items.Quality++;

                if (Items.SellIn < 11 && Items.Quality < 50)
                {
                    Items.Quality++;
                }

                if (Items.SellIn < 6 && Items.Quality < 50)
                {
                    Items.Quality++;
                }
            }

            Items.SellIn--;

            if (Items.SellIn < 0)
            {
                Items.Quality = 0;
            }
        }
    }
}
