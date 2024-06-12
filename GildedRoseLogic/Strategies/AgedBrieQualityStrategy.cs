using GildedRoseShared.Entities;

namespace GildedRoseLogic.Strategies
{
    public class AgedBrieQualityStrategy : IUpdateItemQualityStrategy
    {
        public void UpdateQuality(Item Items)
        {
            Items.Quality = Items.Quality < 50 ? Items.Quality + 1 : Items.Quality;
            Items.SellIn--;

            if (Items.SellIn < 0 && Items.Quality < 50)
            {
                Items.Quality++;
            }
        }
    }
}
