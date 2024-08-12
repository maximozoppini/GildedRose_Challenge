using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRoseKata.Models;

namespace GildedRoseKata.Items
{
    public class DefaultItem : BaseItem
    {
        public DefaultItem(Item item) : base(item) { }

        public override void Update()
        {
            base.Update();
            if (_item.Quality > 0) _item.Quality--;
            if (_item.SellIn < 0 && _item.Quality > 0) _item.Quality--;
        }
    }
}
