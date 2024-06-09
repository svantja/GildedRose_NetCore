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
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        using IHost host = builder.Build();
        Program app = new Program(host.Services.GetRequiredService<IUpdateItemFactory>(), 30);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
    }

    // Write test for verifying that the quality of an item is never negative
    [Fact]
    public void bar() {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Services.AddScoped<IUpdateItemFactory, UpdateItemFactory>();

        using IHost host = builder.Build();

        Program app = new Program(host.Services.GetRequiredService<IUpdateItemFactory>(), 30);
        app.UpdateQuality();
        app.Items.ForEach(item => Assert.True(item.Quality >= 0));
    }
}