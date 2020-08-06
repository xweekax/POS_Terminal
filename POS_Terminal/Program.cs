using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;

namespace POS_Terminal
{
    public class product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public product(string aName, string aCategory, string aDescription, decimal aPrice)
        {
            Name = aName;
            Category = aCategory;
            Description = aDescription;
            Price = aPrice;
        }

        public override string ToString()
        {
            return $"{this.Name,-20} | {this.Price,10}";
        }
    }
    public class shoppingCart
    {

        //Dictionary
        public static List<product> fullCart = new List<product>();
        public void itemSelect(int userInput, List<product> myList)
        {
            fullCart.Add(myList[userInput]);
        }

    }
    public class storeInventory
    {
        public static List<product> inventory = new List<product>();
        
        public static void AddProduct(product theItem)
        {
            inventory.Add(theItem);
        }

        public static void DisplayProducts()
        {
            foreach (product item in inventory)
            {
                Console.WriteLine(item);
            }
        }

        
    }
    public class Program
    {
        static void Main(string[] args)
        {
            
            storeInventory.AddProduct(new product("apple", "produce", "food", 1.00m));
            storeInventory.AddProduct(new product("milk", "dairy", "food", 3.99m));
            storeInventory.AddProduct(new product("ham", "meat", "food", 5.99m));
            storeInventory.AddProduct(new product("pasta", "carbs", "food", 1.00m));
            storeInventory.AddProduct(new product("batteries", "electronics", "power", 4.69m));
            storeInventory.AddProduct(new product("asprin", "health", "pain relief", 10.70m));
            storeInventory.AddProduct(new product("charcoal", "outdoors", "fuel", 12.04m));
            storeInventory.AddProduct(new product("baseball", "sports", "sports ball", 5.54m));
            storeInventory.AddProduct(new product("cat food", "pets", "cat fuel", 15.54m));
            storeInventory.AddProduct(new product("dog food", "pets", "dog fuel", 13.56m));
            storeInventory.AddProduct(new product("shirt", "clothing", "mens shirt", 20.06m));
            storeInventory.AddProduct(new product("tires", "automotive", "car part", 73.06m));

            foreach (product p in storeInventory.inventory)
            {
                Console.WriteLine(p);
            }
            

        }
    }
}
