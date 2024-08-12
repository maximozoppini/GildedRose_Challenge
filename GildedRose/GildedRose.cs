using System.Collections.Generic;
using GildedRoseKata.Models;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {

        foreach (var item in Items) {
            SellingItemFactory.CreateItem(item).Update();
        }

    }
}