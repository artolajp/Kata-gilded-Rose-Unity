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
        public void DegradeTwiceAsFast_TheItemQuality_WhenTheItemHasPassed() {
            
            IList<Item> items = GetItemsFrom(sellIn: 0, quality:4);
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(2, items[0].Quality);
        }


        [Test(Description = "The Quality of an item is never negative")]
        public void NotDegradeTheItemQualityToNegative()
        {
            IList<Item> items = GetItemsFrom(quality:0, sellIn: 0);;
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }

        [Test(Description = "“Aged Brie” actually increases in Quality the older it gets")]
        public void IncreaseAgedBrieQualityInsteadDegradeIt()
        {
            IList<Item> items = GetItemsFrom(name: "Aged Brie", sellIn: 20, quality: 1);
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(2, items[0].Quality);
        }
        
        [Test(Description = "The Quality of an item is never more than 50")]
        public void Increase_TheItemQualityUntilFifty()
        {
            IList<Item> items =  GetItemsFrom(name: "Aged Brie", sellIn: 20, quality:50);
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(50, items[0].Quality);
        }

        [Test(Description = "“Sulfuras”, being a legendary item, never has to be sold or decreases in Quality")]
        public void NotDegrade_SulfurasItem()
        {
            IList<Item> items = GetItemsFrom(name: "Sulfuras, Hand of Ragnaros", sellIn: 20, quality:80); 
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(80, items[0].Quality);
        }
        
        [Test(Description = "“Sulfuras”, being a legendary item, never has to be sold or decreases in Quality")]
        public void NotSold_SulfurasItem()
        {
            IList<Item> items = GetItemsFrom(name: "Sulfuras, Hand of Ragnaros", sellIn: 20, quality:80); 
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(20, items[0].SellIn);
        }
        
        [Test(Description = "“Backstage passes” Quality increases by 2 when there are 10 days or less")]
        public void IncreaseBy2_OnBackstagePassesQuality_WhenThereAreTenOrLessDaysToSellIn()
        {
            IList<Item> items = GetItemsFrom(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 10, quality:10); 
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(12, items[0].Quality);
        }
        
        [Test(Description = "“Backstage passes” Quality increases by 3 when there are 5 days or less")]
        public void IncreaseBy3_OnBackstagePassesQuality_WhenThereAreFiveOrLessDaysToSellIn()
        {
            IList<Item> items = GetItemsFrom(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 5, quality:10); 
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(13, items[0].Quality);
        }
        
        [Test(Description = "“Backstage passes” Quality drops to 0 after the concert")]
        public void DropQuality_OnBackstagePassesQuality_WhenConcertFinished()
        {
            IList<Item> items = GetItemsFrom(name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 0, quality:10); 
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }
        
        [Test(Description = "“Conjured” items degrade in Quality twice as fast as normal items")]
        public void DegradeTwiceAsFast_OnConjuredItem()
        {
            IList<Item> items = GetItemsFrom(name: "Conjured", sellIn: 10, quality:10); 
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(8, items[0].Quality);
        }

        private static IList<Item> GetItemsFrom(string name = "foo",int sellIn = 0, int quality = 0 )
        {
            return new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
        }

    }
}
