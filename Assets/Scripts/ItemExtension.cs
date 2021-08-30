using System;

namespace GildedRoseKata
{
    public class ItemHandler
    {
        private const int MAXQuality = 50;

        protected readonly Item Item;

        public ItemHandler(Item item)
        {
            Item = item;
        }

        protected bool IsExpired()
        {
            return Item.SellIn < 0;
        }

        public virtual void DecreaseItemSellIn()
        {
            Item.SellIn -= 1;
        }

        protected void DropItemQuality()
        {
            Item.Quality = 0;
        }

        protected void DegradeItemQualityBy(int degradeValue)
        {
            if (Item.Quality != 0)
            {
                Item.Quality = Math.Max(Item.Quality - degradeValue, 0);
            }
        }

        protected void IncreaseItemQualityBy(int increaseValue)
        {
            if (Item.Quality < MAXQuality)
            {
                Item.Quality += increaseValue;
            }
        }

        public virtual void UpdateQuality()
        {
            DecreaseItemSellIn();
            if (IsExpired())
            {
                DegradeItemQualityBy(2);
            }
            else
            {
                DegradeItemQualityBy(1);
            }
        }
    }
}