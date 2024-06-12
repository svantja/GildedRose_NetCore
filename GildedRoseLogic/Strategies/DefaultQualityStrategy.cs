using GildedRoseShared.Entities;

namespace GildedRoseLogic.Strategies
{
    public class DefaultQualityStrategy : IUpdateItemQualityStrategy
    {
        public void UpdateQuality(Item Items)
        {
            Items.Quality = Items.Quality > 0 ? Items.Quality - 1 : Items.Quality;
            Items.SellIn--;

            if (Items.SellIn < 0 && Items.Quality > 0)
            {
                Items.Quality--;
            }
        }
    }
}
