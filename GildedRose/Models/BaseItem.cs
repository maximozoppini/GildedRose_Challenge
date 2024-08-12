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
        public Item _item { get; set; }

        public BaseItem(Item item)
        {
            _item = item;
        }

        public virtual void Update()
        {
            _item.SellIn = --_item.SellIn;
        }
    }
}
