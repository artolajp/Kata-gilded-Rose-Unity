using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private readonly IList<BasicItem> _items;

        public GildedRose(IList<Item> items)
        {
            _items = new List<BasicItem>();
            foreach (var item in items)
            {
                BasicItem newItem;
                if (IsSulfurasItem(item))
                {
                    newItem = new SulfurasItem(item);
                }
                else if (IsAgedBrieItem(item))
                {
                    newItem = new AgedBrideItem(item);
                }
                else if (IsBackstagePassesItem(item))
                {
                    newItem = new BackstagePassesItem(item);
                }
                else
                {
                    newItem = new BasicItem(item);
                }

                _items.Add(newItem);
            }
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                item.DecreaseItemSellIn();
                item.UpdateQuality();
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