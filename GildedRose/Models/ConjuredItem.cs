using System;
using GildedRoseKata.Models;

namespace GildedRoseKata.Items
{
    public class ConjuredItem : BaseItem
    {
        public ConjuredItem(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            _item.Quality = _item.Quality + CalculateQuality();
        }

        private int CalculateQuality() => (_item.Quality, _item.SellIn) switch
        {
            ( > MinQuality, < SellInThreshold) => -4,
            ( > MinQuality, _) => -2,
            _ => 0
        };
    }
}
