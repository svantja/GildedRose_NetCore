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

    public static void Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        builder.Services.AddScoped<IUpdateItemFactory, UpdateItemFactory>();

        using IHost host = builder.Build();

        var gildedRose = new GildedRose(host.Services.GetRequiredService<IUpdateItemFactory>(), GetDays(args));

        gildedRose.UpdateQuality();
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
}