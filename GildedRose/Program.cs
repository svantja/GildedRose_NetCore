using GildedRoseLogic.Factory;
using GildedRoseShared.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

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
        if (!int.TryParse(args.FirstOrDefault(), out days))
        {
            throw new ArgumentException("Provided arg is no valid number");
        }
        return days;
    }
}