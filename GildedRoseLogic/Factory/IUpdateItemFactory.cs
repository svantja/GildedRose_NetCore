using GildedRoseLogic.Strategies;
using GildedRoseShared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseLogic.Factory
{
    public interface IUpdateItemFactory
    {
        IUpdateItemQualityStrategy Create(Item item);
    }
}
