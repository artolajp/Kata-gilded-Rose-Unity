using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const int MAXQuality = 50;

        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            this._items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (IsSulfurasItem(item))
                {
                    return;
                }

                DecreaseItemSellIn(item);

                if (IsAgedBrieItem(item))
                {
                    IncreaseItemQualityBy(item, 1);
                }
                else if (IsBackstagePassesItem(item))
                {
                    if (item.SellIn <= 5)
                    {
                        IncreaseItemQualityBy(item, 3);
                    }
                    else if (item.SellIn <= 10)
                    {
                        IncreaseItemQualityBy(item, 2);
                    }
                }
                else
                {
                    DegradeItemQualityBy1(item);
                }


                if (IsExpiredItem(item))
                {
                    if (IsAgedBrieItem(item))
                    {
                        IncreaseItemQualityBy(item, 1);
                    }
                    else if (IsBackstagePassesItem(item))
                    {
                        DropItemQuality(item);
                    }
                    else
                    {
                        DegradeItemQualityBy1(item);
                    }
                }
            }
        }

        private static bool IsExpiredItem(Item item)
        {
            return item.SellIn < 0;
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

        private static void DecreaseItemSellIn(Item item)
        {
            item.SellIn -= 1;
        }

        private static void DropItemQuality(Item item)
        {
            item.Quality -= item.Quality;
        }

        private static void DegradeItemQualityBy1(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }

        private static void IncreaseItemQualityBy(Item item, int increaseValue)
        {
            if (item.Quality < MAXQuality)
            {
                item.Quality += increaseValue;
            }
        }
    }
}