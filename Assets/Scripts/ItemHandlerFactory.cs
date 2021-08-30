namespace GildedRoseKata
{
    public class ItemHandlerFactory
    {
        public ItemHandler GetItemHandler(Item item)
        {
            if (IsSulfurasItem(item))
            {
                return new SulfurasItemHandler(item);
            }
            else if (IsAgedBrieItem(item))
            {
                return new AgedBrideItemHandler(item);
            }
            else if (IsBackstagePassesItem(item))
            {
                return new BackstagePassesItemHandler(item);
            }
            else
            {
                return new ItemHandler(item);
            }
        }

        private static bool IsBackstagePassesItem(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static bool IsAgedBrieItem(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private static bool IsSulfurasItem(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}