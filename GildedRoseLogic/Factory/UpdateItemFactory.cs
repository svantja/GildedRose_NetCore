using GildedRoseLogic.Strategies;
using GildedRoseShared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseLogic.Factory
{
    public class UpdateItemFactory : IUpdateItemFactory
    {
        public IUpdateItemQualityStrategy Create(Item item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return item switch
            {
                AgedBrieItem agedBrieItem => new AgedBrieQualityStrategy(),
                BackstagePassesItem backstagePassesItem => new BackstagePassesQualityStrategy(),
                SulfurasItem sulfurasItem => new SulfurasQualityStrategy(),
                ConjuredItem conjuredItem => new ConjuredQualityStrategy(),
                _ => new DefaultQualityStrategy(),
            };
        }
    }
}
