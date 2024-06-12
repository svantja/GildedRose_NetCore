using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseShared.Entities;
using GildedRoseLogic.Strategies;
using GildedRoseLogic.Factory;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System;
using VerifyXunit;
using System.Linq;

namespace GildedRoseTests; 

public class GildedRoseTest
{
    [Fact]
    public Task ThirtyDays()
    {
        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));
        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        Program.Main(new string[] { "30" });
        var output = fakeoutput.ToString();

        return Verifier.Verify(output);
    }

    [Fact]
    public void foo()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Services.AddScoped<IUpdateItemFactory, UpdateItemFactory>();
        using IHost host = builder.Build();
        GildedRose app = new GildedRose(host.Services.GetRequiredService<IUpdateItemFactory>(), 30);
        app.UpdateQuality();
        Assert.Equal(0, app.ItemList[0].Quality);
    }

    
    [Fact]
    public void VerifyQualityNeverNegative() {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Services.AddScoped<IUpdateItemFactory, UpdateItemFactory>();

        using IHost host = builder.Build();

        GildedRose app = new GildedRose(host.Services.GetRequiredService<IUpdateItemFactory>(), 30);
        app.UpdateQuality();
        app.ItemList.ForEach(item => Assert.True(item.Quality >= 0));
    }

    [Fact]
    public void VerifyQualityNeverMoreThanFifty()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Services.AddScoped<IUpdateItemFactory, UpdateItemFactory>();

        using IHost host = builder.Build();

        GildedRose app = new GildedRose(host.Services.GetRequiredService<IUpdateItemFactory>(), 30);
        app.UpdateQuality();
        app.ItemList.ForEach(item =>
        {
            if (item is not SulfurasItem)
            {
                Assert.True(item.Quality <= 50);
            }
        });
    }

    [Fact]
    public void VerifySulfurasStaysTheSame()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Services.AddScoped<IUpdateItemFactory, UpdateItemFactory>();

        using IHost host = builder.Build();

        GildedRose app = new GildedRose(host.Services.GetRequiredService<IUpdateItemFactory>(), 30);
        var initialQuality = app.ItemList.First(i => i is SulfurasItem).Quality;
        var initialSellIn = app.ItemList.First(i => i is SulfurasItem).SellIn;
        app.UpdateQuality();
        var finalQuality = app.ItemList.First(i => i is SulfurasItem).Quality;
        var finalSellIn = app.ItemList.First(i => i is SulfurasItem).SellIn;

        Assert.Equal(initialQuality, finalQuality);
        Assert.Equal(initialSellIn, finalSellIn);
    }

    [Fact]
    public void VerifyAgedBrieQualityIncreasesOverTime()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Services.AddScoped<IUpdateItemFactory, UpdateItemFactory>();

        using IHost host = builder.Build();

        GildedRose app = new GildedRose(host.Services.GetRequiredService<IUpdateItemFactory>(), 30);
        var initialQuality = app.ItemList.First(i => i is AgedBrieItem).Quality;
        app.UpdateQuality();
        var finalQuality = app.ItemList.First(i => i is AgedBrieItem).Quality;

        Assert.True(finalQuality > initialQuality);
    }
}