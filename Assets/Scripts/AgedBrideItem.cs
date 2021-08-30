namespace GildedRoseKata
{
    public class AgedBrideItem: BasicItem
    {
        public AgedBrideItem(Item item) :base (item)
        {
        }

        public override void UpdateQuality()
        {
            IncreaseItemQualityBy(1);
        }
        
    }
}