using System;
using System.Collections.Generic;
using GildedRoseShared.Entities;
using GildedRoseLogic.Strategies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GildedRoseLogic.Factory;

namespace GildedRoseKata;

public class Program
{
    IUpdateItemFactory _updateItemFactory;
    IList<Item> Items;
    int _days;

    public List<Item> items => (List<Item>)Items;

    public Program(IUpdateItemFactory updateItemFactory, int days)
    {
        _updateItemFactory = updateItemFactory;
        _days = days;
        Items = GenerateDefaultItems();
    }

    public static void Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        builder.Services.AddScoped<IUpdateItemFactory, UpdateItemFactory>();

        using IHost host = builder.Build();

        var app = new Program(host.Services.GetRequiredService<IUpdateItemFactory>(), GetDays(args));

        Console.WriteLine("OMGHAI!");

        app.UpdateQuality();
    }

    public static int GetDays(string[] args)
    {
        int days = 2;
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        return days;
    }

    //write method for generating default items
    public static List<Item> GenerateDefaultItems()
    {
        return new List<Item>
        {
            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 49
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            },
            // this conjured item does not work properly yet
            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        };
    }


    public void UpdateQuality()
    {
        for (var i = 0; i < _days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            foreach (var item in Items)
            {
                Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
                var strategy = _updateItemFactory.Create(item);
                strategy.UpdateQuality(item);
            }
            Console.WriteLine("");
        }
    }

}