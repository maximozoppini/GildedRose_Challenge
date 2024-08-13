using System.Collections;
using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseKata.Models;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    private const string BRIE = "Aged Brie";
    private const string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
    private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
    private const string CONJURAS = "Conjured Mana Cake";
    private const string DEFAULT = "Default";

    private static Item CreateItem(string name, int quality, int sellin) {
        return new Item { Name = name, Quality = quality, SellIn = sellin };
    }

    public static IEnumerable NonLegendaryItemsWithSellin10 = new[]
    {
        new TestCaseData(new {item= CreateItem(BRIE, 10, 10), exp_result = 9 }),
        new TestCaseData(new {item= CreateItem(BACKSTAGE, 10, 10), exp_result = 9 }),
        new TestCaseData(new {item= CreateItem(DEFAULT, 10, 10), exp_result = 9 }),
        new TestCaseData(new {item= CreateItem(CONJURAS, 10, 10), exp_result = 9 }),

    };

    public static IEnumerable DefualtItem_PositiveSellingCombinations = new[]
    {
        new TestCaseData(new {quality = 10, sellin = 10 , exp_result = 9 }),
        new TestCaseData(new {quality = 10, sellin = 5 , exp_result = 9 }),
        new TestCaseData(new {quality = 10, sellin = 2 , exp_result = 9 }),
        new TestCaseData(new {quality = 10, sellin = 1 , exp_result = 9 }),
    };

    public static IEnumerable BrieItem_PositiveSellingCombinations = new[]
    {
        new TestCaseData(new {quality = 10, sellin = 10 , exp_result = 11 }),
        new TestCaseData(new {quality = 10, sellin = 5 , exp_result = 11 }),
        new TestCaseData(new {quality = 10, sellin = 2 , exp_result = 11 }),
        new TestCaseData(new {quality = 10, sellin = 1 , exp_result = 11 }),
    };

    public static IEnumerable BackstageItem_SellingCombinations = new[]
    {
        new TestCaseData(new {quality = 10, sellin = 12 , exp_result = 11 }),
        new TestCaseData(new {quality = 10, sellin = 10 , exp_result = 12 }),
        new TestCaseData(new {quality = 10, sellin = 8 , exp_result = 12 }),
        new TestCaseData(new {quality = 10, sellin = 5 , exp_result = 13 }),
        new TestCaseData(new {quality = 10, sellin = 3 , exp_result = 13 }),
        new TestCaseData(new {quality = 0, sellin = 0 , exp_result = 0 }),
        new TestCaseData(new {quality = 0, sellin = -1 , exp_result = 0 }),
    };

    [Test, Description("At the end of each day our system lowers both values for every item")]
    [TestCaseSource(nameof(NonLegendaryItemsWithSellin10))]
    public void UpdateQuality_Non_LegendaryItem_Should_LowerSelling_By_1(dynamic sellingItem)
    {
        // Given the item has selling of 10
        // When update
        var GR = new GildedRose(new List<Item> { sellingItem.item });
        GR.UpdateQuality();

        // Should have quality of 9
        Assert.That(sellingItem.item.SellIn, Is.EqualTo(sellingItem.exp_result));
    }


    [Test, Description("At the end of each day our system lowers both values for every item")]
    [TestCaseSource(nameof(DefualtItem_PositiveSellingCombinations))]
    public void UpdateQuality_Should_DefaultItem_LowerQuality_By_1_When_SellingPositive(dynamic sellingItem)
    {
        // Given the default item 
        var item = CreateItem(DEFAULT, sellingItem.quality, sellingItem.sellin);

        // When update
        var GR = new GildedRose(new List<Item> { item });
        GR.UpdateQuality();

        // Should have quality
        Assert.That(item.Quality, Is.EqualTo(sellingItem.exp_result));
    }

    [Test, Description("Once the sell by date has passed, Quality degrades twice as fast")]
    public void UpdateQuality_Should_DefaultItem_LowerQuality_By_2_When_SellingNegative()
    {
        // Given the default item (this item is the only one that its quality decereases)
        var item = CreateItem(DEFAULT, 10, -1);

        // When update
        var GR = new GildedRose(new List<Item> { item });
        GR.UpdateQuality();

        // Should have quality of 8
        Assert.That(item.Quality, Is.EqualTo(8));
    }

    [Test, Description("Once the sell by date has passed, Quality degrades twice as fast")]
    public void UpdateQuality_Should_ConjurasItem_LowerQuality_By_2_When_SellingPositive()
    {
        // Given the conjuras item (this item is the only one that its quality decereases)
        var item = CreateItem(CONJURAS, 10, 2);

        // When update
        var GR = new GildedRose(new List<Item> { item });
        GR.UpdateQuality();

        // Should have quality of 8
        Assert.That(item.Quality, Is.EqualTo(8));
    }

    [Test, Description("Once the sell by date has passed, Quality degrades twice as fast")]
    public void UpdateQuality_Should_ConjurasItem_LowerQuality_By_4_When_SellingNegative()
    {
        // Given the conjuras item (this item is the only one that its quality decereases)
        var item = CreateItem(CONJURAS, 10, -1);

        // When update
        var GR = new GildedRose(new List<Item> { item });
        GR.UpdateQuality();

        // Should have quality of 6
        Assert.That(item.Quality, Is.EqualTo(6));
    }

    [Test, Description("The Quality of an item is never negative")]
    public void UpdateQuality_Should_DefaultItem_QualityNeverNegative_When_SellingDecrease()
    {
        // Given the default item (this item is the only one that its quality decereases)
        var item = CreateItem(DEFAULT, 0, 1);

        // When update
        var GR = new GildedRose(new List<Item> { item });
        GR.UpdateQuality();

        // Should have quality of 0
        Assert.That(item.Quality, Is.EqualTo(0));
    }

    [Test, Description("The Quality of an item is never negative")]
    public void UpdateQuality_Should_ConjurasItem_QualityNeverNegative_When_SellingDecrease()
    {
        // Given the CONJURAS item (this item is the only one that its quality decereases)
        var item = CreateItem(CONJURAS, 0, 1);

        // When update
        var GR = new GildedRose(new List<Item> { item });
        GR.UpdateQuality();

        // Should have quality of 0
        Assert.That(item.Quality, Is.EqualTo(0));
    }

    [Test, Description("\"Aged Brie\" actually increases in Quality the older it gets")]
    [TestCaseSource(nameof(BrieItem_PositiveSellingCombinations))]
    public void UpdateQuality_Should_BrieItem_IncreaseQuality_By_1_When_SellingPositive(dynamic sellingItem)
    {
        // Given the default item 
        var item = CreateItem(BRIE, sellingItem.quality, sellingItem.sellin);

        // When update
        var GR = new GildedRose(new List<Item> { item });
        GR.UpdateQuality();

        // Should have quality
        Assert.That(item.Quality, Is.EqualTo(sellingItem.exp_result));
    }

    [Test, Description("The Quality of an item is never more than 50")]
    [TestCase(49, 5)]
    [TestCase(49, 5)]
    [TestCase(50, 5)]
    public void UpdateQuality_Should_BrieItem_QualityBeMax50_When_SellinDecrease(int quality, int sellin)
    {
        // Given the brie item 
        var item = CreateItem(BRIE, quality, sellin);

        // When update
        var GR = new GildedRose(new List<Item> { item });
        GR.UpdateQuality();

        // Should have max quality of 50
        Assert.That(item.Quality, Is.EqualTo(50));
    }

    [Test, Description("The Quality of an item is never more than 50")]
    [TestCase(48, 1)]
    [TestCase(48, 3)]
    [TestCase(49, 5)]
    [TestCase(49, 10)]
    [TestCase(50, 4)]
    public void UpdateQuality_Should_BackstageItem_QualityBeMax50_When_SellinDecrease(int quality, int sellin)
    {
        // Given the BACKSTAGE item 
        var item = CreateItem(BACKSTAGE, quality, sellin);

        // When update
        var GR = new GildedRose(new List<Item> { item });
        GR.UpdateQuality();

        // Should have max quality of 50
        Assert.That(item.Quality, Is.EqualTo(50));
    }


    [Test, Description("\"Sulfuras\", being a legendary item, never has to be sold or decreases in Quality")]

    public void UpdateQuality_Should_SulfuraItem_NeverLowerQualityOrSelling_When_SellinDecrease()
    {
        // Given the sulfuras item (legendary)
        var item = CreateItem(SULFURAS, 5, 5);

        // When update
        var GR = new GildedRose(new List<Item> { item });
        GR.UpdateQuality();

        // Should have quality and selling of 5.
        Assert.That(item.Quality, Is.EqualTo(5));
        Assert.That(item.SellIn, Is.EqualTo(5));
    }

    [Test, Description("\"Backstage passes\", like aged brie, increases in Quality as its SellIn value approaches;")]
    [TestCaseSource(nameof(BackstageItem_SellingCombinations))]
    public void UpdateQuality_Should_BackstageItem_IncreaseQuality_When_SellingApproaches(dynamic sellingItem)
    {
        /*
         "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
            Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
            Quality drops to 0 after the concert
        */
        var item = CreateItem(BACKSTAGE, sellingItem.quality, sellingItem.sellin);

        // When update
        var GR = new GildedRose(new List<Item> { item });
        GR.UpdateQuality();

        // Should have quality
        Assert.That(item.Quality, Is.EqualTo(sellingItem.exp_result));
    }




}