using GildedRoseKata.Items;
using GildedRoseKata.Models;

namespace GildedRoseKata
{
    public class SellingItemFactory
    {
        private const string BRIE = "Aged Brie";
        private const string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private const string CONJURAS = "Conjured Mana Cake";
        /// <summary>
        /// Simple factory method
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>a new SellingItem item</returns>
        public static ISellingItem CreateItem(Item item) {
            return item switch
            {
                Item i when i.Name == BRIE => new AgedBrieItem(i),
                Item i when i.Name == BACKSTAGE => new BackStageItem(i),
                Item i when i.Name == SULFURAS => new SulfuraItem(i),
                Item i when i.Name == CONJURAS => new ConjuredItem(i),
                _ => new DefaultItem(item)
            };
        }
    }
}
