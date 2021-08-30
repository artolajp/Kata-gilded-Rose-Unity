using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private readonly IList<ItemHandler> _items;

        public GildedRose(IList<Item> items)
        {
            var itemHandlerFactory = new ItemHandlerFactory();
            
            _items = new List<ItemHandler>(items.Count);
            
            foreach (var item in items)
            {
                ItemHandler newItemHandler = itemHandlerFactory.GetItemHandler(item);
                _items.Add(newItemHandler);
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

    }
}