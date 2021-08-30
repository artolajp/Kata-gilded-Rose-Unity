namespace GildedRoseKata
{
    public class AgedBrideItemHandler: ItemHandler
    {
        public AgedBrideItemHandler(Item item) :base (item)
        {
        }

        public override void UpdateQuality()
        {
            IncreaseItemQualityBy(1);
        }
        
    }
}