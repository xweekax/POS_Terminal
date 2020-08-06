using System;
using Xunit;
using POS_Terminal;
using System.Collections.Generic;

namespace XUnitTestPOS
{
    public class UnitTest1
    {

        /*
         [Fact]
        public void Test1()
        {
            int choice = 1;
            ArrayList myList = new ArrayList();
            PrimeNumbers.CreatePrimeList(myList);
            Assert.Equal(2, PrimeNumbers.GetPrime(myList, choice));

        }
        */
        [Fact]
        public void itemSelectTest()
        {
            product Apple = new product("Apple", "Produce", "Fruit", 1.00m);
            storeInventory.inventory.Add(Apple);

            product Pear = new product("Pear", "Produce", "Fruit", 1.50m);
            storeInventory.inventory.Add(Pear);

            Assert.Equal(Apple, storeInventory.inventory[0]);
            Assert.Equal(Pear, storeInventory.inventory[1]);

            //Testing ideas
            //Adding a product with the same name "Apple"
            //What do we do here, when more than 1 of the same object comes up.

            //Build test, run - fail
            //Modify to do what we need it to do

            //Isolate a class, it should be doing one thing.
            
        }
        [Fact]
        public void cartContents()
        {
            product Pear = new product("Pear", "Produce", "Fruit", 1.50m);
            shoppingCart.fullCart.Add(Pear);

            Assert.Equal(Pear, shoppingCart.fullCart[0]);
        }
        
        [Fact]
        public void lineTotalTest()
        {

        }
        /*
                 [Fact]
        public void calculateTotals()
        {

        } */
        [Fact]
        public void calculaateChange()
        {

        }
        [Fact]
        public void finalProduct()
        {

        }
    }
}
