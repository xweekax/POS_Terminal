using System;
using Xunit;
using POS_Terminal;
using System.Collections.Generic;

namespace XUnitTestPOS
{
    public class UnitTest1
    {
        [Fact]
        public void itemSelectTest()
        {
            product Apple = new product("Apple", "Produce", "Fruit", 1.00m);
            storeInventory.inventory.Add(Apple);

            product Pear = new product("Pear", "Produce", "Fruit", 1.50m);
            storeInventory.inventory.Add(Pear);

            Assert.Equal(Apple, storeInventory.inventory[0]);
            Assert.Equal(Pear, storeInventory.inventory[1]);
            
        }
        [Fact]
        public void cartContents()
        {
            shoppingCart.fullCart.Clear();
            product Pear = new product("Pear", "Produce", "Fruit", 1.50m);
            shoppingCart.fullCart.Add(Pear);

            Assert.Equal(Pear, shoppingCart.fullCart[0]);
        }
        
        [Fact]
        public void cartTaxesTest()
        {
            shoppingCart.fullCart.Clear();
            product Pear = new product("Pear", "Produce", "Fruit", 1.50m);
            shoppingCart.fullCart.Add(Pear);
            product Apple = new product("Apple", "Produce", "Fruit", 2.50m);
            shoppingCart.fullCart.Add(Apple);

            Assert.Equal(0.24m, shoppingCart.Taxes(shoppingCart.cartTotal()));
        }
        
        [Fact]
        public void cartTotalTest()
        {
            shoppingCart.fullCart.Clear();
            product Pear = new product("Pear", "Produce", "Fruit", 1.50m);
            shoppingCart.fullCart.Add(Pear);
            product Apple = new product("Apple", "Produce", "Fruit", 2.50m);
            shoppingCart.fullCart.Add(Apple);

            Assert.Equal(4.00m, shoppingCart.cartTotal());
        } 
        
        [Fact]
        public void totalWithTaxTest()
        {
            shoppingCart.fullCart.Clear();
            product Pear = new product("Pear", "Produce", "Fruit", 1.00m);
            shoppingCart.fullCart.Add(Pear);

            Assert.Equal(1.06m, shoppingCart.totalWithTax());
        }
        
        [Fact]
        public void finalReceiptTest() //test the final receipt to see what happens when you add more than 1 of an item to the list
        {
            shoppingCart.fullCart.Clear();
            product Pear = new product("Pear", "Produce", "Fruit", 1.00m);
            shoppingCart.fullCart.Add(Pear);
            product Apple = new product("Apple", "Produce", "Fruit", 2.00m);
            shoppingCart.fullCart.Add(Apple);
            shoppingCart.fullCart.Add(Apple);
            product Tire = new product("Tire", "Not Produce", "Car Stuff", 200.00m);
            shoppingCart.fullCart.Add(Tire);

            Assert.Equal(Pear, shoppingCart.fullCart[0]);
            Assert.Equal(Apple, shoppingCart.fullCart[1]);
            Assert.Equal(Apple, shoppingCart.fullCart[2]);
            Assert.Equal(Tire, shoppingCart.fullCart[3]);

        }
    }
}
