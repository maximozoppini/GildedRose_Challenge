using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRoseKata.Models;

namespace GildedRoseKata.Items
{
    public class BackStageItem : BaseItem
    {
        const int FirstThreshold = 10;
        const int SecondThreshold = 5;

        public BackStageItem(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            //Quality must never increase above 50
            _item.Quality =  Math.Min(_item.Quality + CalculateQuality(), MaxQuality);
        }

        private int CalculateQuality() => (_item.Quality, _item.SellIn) switch
        {
            ( _, < 0) => -_item.Quality, // If SellIn < 0 -> Quality 0
            ( < MaxQuality, < SecondThreshold) => 3, // If SellIn < 5 -> Quality Increase 3
            ( < MaxQuality, < FirstThreshold) => 2, // If SellIn < 10 -> Quality Increase 2
            ( < MaxQuality, _) => 1, // // If SellIn < 50 -> Quality Increase 1
            _ => 0
        };


}
}
