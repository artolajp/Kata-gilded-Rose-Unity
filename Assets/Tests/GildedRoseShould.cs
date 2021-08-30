using NUnit.Framework;
using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework.Internal;

namespace EditorTests
{
    [TestFixture]
    public class GildedRoseShould
    {
        [Test(Description = "Once the sell by date has passed, Quality degrades twice as fast")]
        public void DegradeTwiceAsFast_TheItemQuality_WhenTheSellByDateHasPassed() {
            
            IList<Item> items = GetItemIListFrom(sellIn: 0, quality:4);
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(2, items[0].Quality);
        }


        [Test(Description = "The Quality of an item is never negative")]
        public void NotDegradeTheItemQualityToNegative()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }

        [Test(Description = "“Aged Brie” actually increases in Quality the older it gets")]
        public void IncreaseAgedBrieQualityInsteadDegradeIt()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 20, Quality = 1 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(2, items[0].Quality);
        }
        
        [Test(Description = "The Quality of an item is never more than 50")]
        public void Increase_TheItemQualityUntilFifty()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 20, Quality = 50 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(50, items[0].Quality);
        }

        [Test(Description = "“Sulfuras”, being a legendary item, never has to be sold or decreases in Quality")]
        public void NotDegrade_SulfurasItem()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 20, Quality = 80 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(80, items[0].Quality);
        }
        
        [Test(Description = "“Sulfuras”, being a legendary item, never has to be sold or decreases in Quality")]
        public void NotSold_SulfurasItem()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 20, Quality = 80 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(20, items[0].SellIn);
        }
/*
 “Backstage passes”, like aged brie, increases in Quality as its SellIn value approaches;
Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
Quality drops to 0 after the concert
*/
        [Test(Description = "“Backstage passes” Quality increases by 2 when there are 10 days or less")]
        public void IncreaseBy2_OnBackstagePassesQuality_WhenThereAreTenOrLessDaysToSellIn()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(12, items[0].Quality);
        }
        
        [Test(Description = "“Backstage passes” Quality increases by 3 when there are 5 days or less")]
        public void IncreaseBy3_OnBackstagePassesQuality_WhenThereAreFiveOrLessDaysToSellIn()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(13, items[0].Quality);
        }
        
        [Test(Description = "“Backstage passes” Quality drops to 0 after the concert")]
        public void DropQuality_OnBackstagePassesQuality_WhenConcertFinished()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }

        private static IList<Item> GetItemIListFrom(string name = "foo",int sellIn = 1, int quality = 1 )
        {
            return new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
        }

    }
}
