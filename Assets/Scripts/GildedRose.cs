using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const int MAXQuality = 50;

        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (IsSulfurasItem(item))
                {
                    continue;
                }

                DecreaseItemSellIn(item);

                if (IsAgedBrieItem(item))
                {
                    IncreaseItemQualityBy(item, 1);
                    
                    continue;
                }

                if (IsBackstagePassesItem(item))
                {
                    if (IsExpiredItem(item))
                    {
                        DropItemQuality(item);
                    }
                    else
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

                    continue;
                }


                if (IsExpiredItem(item))
                {
                    DegradeItemQualityBy(item, 2);
                }
                else
                {
                    DegradeItemQualityBy(item, 1);
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

        private static void DegradeItemQualityBy(Item item, int degradeValue)
        {
            if (item.Quality != 0)
            {
                item.Quality = Math.Max(item.Quality - degradeValue, 0);
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