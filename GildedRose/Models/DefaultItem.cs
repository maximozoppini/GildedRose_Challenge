﻿using System;
using GildedRoseKata.Models;

namespace GildedRoseKata.Items
{
    public class DefaultItem : BaseItem
    {
        public DefaultItem(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            _item.Quality = _item.Quality + CalculateQuality();
        }

        private int CalculateQuality() => (_item.Quality, _item.SellIn) switch
        {
            ( > MinQuality, < SellInThreshold) => -2,
            ( > MinQuality, _) => -1,
            _ => 0
        };
    }
}
