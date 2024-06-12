using GildedRoseShared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseLogic.Strategies
{
    public interface IUpdateItemQualityStrategy
    {
        void UpdateQuality(Item item);
    }
}
