using GildedRoseShared.Entities;

namespace GildedRoseLogic.Strategies
{
    public class DefaultQualityStrategy : IUpdateItemQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.Quality = item.Quality > 0 ? item.Quality - 1 : item.Quality;
            item.SellIn--;

            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}
