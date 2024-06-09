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

            switch (item.Name) {                 
                case "Aged Brie":
                    return new AgedBrieQualityStrategy();
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassesQualityStrategy();
                case "Sulfuras, Hand of Ragnaros":
                    return new SulfurasQualityStrategy();
                case "Conjured Mana Cake":
                    return new ConjuredQualityStrategy();
                default:
                    return new DefaultQualityStrategy();
            }
        }
    }
}
