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

            switch (item) {                 
                case AgedBrieItem agedBrieItem:
                    return new AgedBrieQualityStrategy();
                case BackstagePassesItem backstagePassesItem:
                    return new BackstagePassesQualityStrategy();
                case SulfurasItem sulfurasItem:
                    return new SulfurasQualityStrategy();
                case ConjuredItem conjuredItem:
                    return new ConjuredQualityStrategy();
                default:
                    return new DefaultQualityStrategy();
            }

            // get type of ConjuredItem
            var t = typeof(ConjuredItem);
        }
    }
}
