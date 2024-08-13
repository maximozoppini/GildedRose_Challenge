using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRoseKata.Models;

namespace GildedRoseKata.Items
{
    public class SulfuraItem : BaseItem
    {
        public SulfuraItem(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            return;
        }

        public override void UpdateSellin()
        {
            return;
        }

    }
}
