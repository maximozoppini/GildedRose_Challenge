using System.Collections.Generic;
using System.Linq;
using GildedRoseKata.Models;

namespace GildedRoseKata;

public class GildedRose
{
    IList<ISellingItem> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items.Select(i => SellingItemFactory.CreateItem(i)).ToList();
    }

    public void UpdateQuality()
    {
        foreach (var item in Items) {
            item.UpdateSellin();
            item.UpdateQuality();
        }

    }
}