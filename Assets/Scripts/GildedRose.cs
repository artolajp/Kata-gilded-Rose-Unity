using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        const int MAXQuality = 50;
        
        private IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    return;
                }

                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    DegradeItemQualityBy1(item);

                }
                else
                {
                    if (item.Quality < MAXQuality)
                    {
                        IncreaseItemQualityBy(item, 1);
                        
                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn < 11)
                            {
                                IncreaseItemQualityBy(item, 1);
                            }

                            if (item.SellIn < 6)
                            {
                                IncreaseItemQualityBy(item, 1);
                            }
                        }
                    }
                }
                
                item.SellIn -= 1;

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            DegradeItemQualityBy1(item);
                        }
                        else
                        {
                            item.Quality -= item.Quality;
                        }
                    }
                    else
                    {
                        IncreaseItemQualityBy(item, 1);
                    }
                }
            }
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
