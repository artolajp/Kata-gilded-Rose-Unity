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
            else if(IsConjuredItem(item))
            {
                return new ConjuredItemHandler(item);

            }
            else
            {
                return new ItemHandler(item);
            }
        }

        private bool IsBackstagePassesItem(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool IsAgedBrieItem(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private bool IsSulfurasItem(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private bool IsConjuredItem(Item item)
        {
            return item.Name == "Conjured";
        }
    }
}