namespace GildedRoseKata
{
    public class BackstagePassesItem : BasicItem
    {
        public BackstagePassesItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            if (IsExpired())
            {
                DropItemQuality();
            }
            else
            {
                if (Item.SellIn <= 5)
                {
                    IncreaseItemQualityBy(3);
                }
                else if (Item.SellIn <= 10)
                {
                    IncreaseItemQualityBy(2);
                }
            }
        }
    }
}