using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRoseKata.Models;

namespace GildedRoseKata.Items
{
    public class AgedBrieItem : BaseItem
    {
        public AgedBrieItem(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            //Quality must never increase above 50
            _item.Quality = Math.Min(_item.Quality + CalculateQuality(), MaxQuality);
        }

        private int CalculateQuality() => (_item.Quality, _item.SellIn) switch
        {
            ( < MaxQuality, < 0) => 2,
            ( < MaxQuality, _) => 1,
            _ => 0
        };

    }
}
