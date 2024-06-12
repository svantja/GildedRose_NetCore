using GildedRoseLogic.Factory;
using GildedRoseShared.Entities;
using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        readonly IUpdateItemFactory _updateItemFactory;
        readonly IList<Item> Items;
        readonly int _days;

        public List<Item> ItemList => (List<Item>)Items;

        public GildedRose(IUpdateItemFactory updateItemFactory, int days)
        {
            _updateItemFactory = updateItemFactory;
            _days = days;
            Items = GenerateDefaultItems();
        }

        private static List<Item> GenerateDefaultItems()
        {
            return new List<Item>
        {
            new DefaultItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new AgedBrieItem {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new DefaultItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new SulfurasItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new SulfurasItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            new BackstagePassesItem
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            },
            new BackstagePassesItem
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 49
            },
            new BackstagePassesItem
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            },
            new ConjuredItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        };
        }

        public void UpdateQuality()
        {
            Console.WriteLine("OMGHAI!");

            for (var i = 0; i < _days; i++)
            {
                // using string interpolation
                Console.WriteLine($"-------- day {i} --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (var item in Items)
                {
                    Console.WriteLine($"{item.Name}, {item.SellIn}, {item.Quality}");
                    var strategy = _updateItemFactory.Create(item);
                    strategy.UpdateQuality(item);
                }
                Console.WriteLine("");
            }
        }
    }
}
