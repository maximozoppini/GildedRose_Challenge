using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRoseKata.Models;

namespace GildedRoseKata.Items
{
    public class BaseItem : ISellingItem
    {
        protected const int MaxQuality = 50;
        protected const int MinQuality = 0;
        protected const int SellInThreshold = 0;
        public Item _item { get; set; }

        public BaseItem(Item item)
        {
            _item = item;
        }

        public virtual void UpdateQuality()
        {
            return;
        }

        public virtual void UpdateSellin()
        {
            _item.SellIn = --_item.SellIn;
        }
    }
}
