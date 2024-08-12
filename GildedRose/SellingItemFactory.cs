using GildedRoseKata.Items;
using GildedRoseKata.Models;

namespace GildedRoseKata
{
    public class SellingItemFactory
    {
        /// <summary>
        /// Simple factory method
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>a new SellingItem item</returns>
        public static ISellingItem CreateItem(Item item) {
            return item switch
            {
                Item i when i.Name == "Aged Brie" => new AgedBrieItem(i),
                Item i when i.Name == "Backstage passes to a TAFKAL80ETC concert" => new BackStageItem(i),
                Item i when i.Name == "Sulfuras, Hand of Ragnaros" => new SulfuraItem(i),
                Item i when i.Name == "Conjured Mana Cake" => new DefaultItem(i),
                _ => new DefaultItem(item)
            };
        }
    }
}
