namespace GildedRoseKata
{
    public class ConjuredItemHandler : ItemHandler
    {
        public ConjuredItemHandler(Item item) : base(item)
        {
        }

        protected override void DegradeItemQualityBy(int degradeValue)
        {
            base.DegradeItemQualityBy(degradeValue*2);
        }
    }
}