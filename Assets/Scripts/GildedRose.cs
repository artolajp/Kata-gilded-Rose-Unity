using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private readonly IList<ItemHandler> _items;

        public GildedRose(IList<Item> items)
        {
            var itemHandlerfactory = new ItemHandlerFactory();
            
            _items = new List<ItemHandler>(items.Count);
            
            foreach (var item in items)
            {
                ItemHandler newItemHandler = itemHandlerfactory.GetItemHandler(item);
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