using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace POS_Terminal
{
    public class product //: IComparable <product>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public product(string aName, string aCategory, string aDescription, decimal aPrice)
        {
            Name = aName;
            Category = aCategory;
            Description = aDescription;
            Price = aPrice;
        }

        public override string ToString()
        {
            return $"{this.Name,-20}            ${this.Price,2}";
        }
    }
    public class shoppingCart
    {
        public static List<product> fullCart = new List<product>();
        public static void itemSelect(int userInput, List<product> myList)
        {
            fullCart.Add(myList[userInput]);
        }
        public static decimal cartTotal()
        {
            decimal total = 0m;
            foreach (product item in shoppingCart.fullCart)
            {
                total += item.Price;
            }
            return total;
        }
        public static decimal Taxes(decimal total)
        {
            decimal taxes = .06m;
            decimal taxTotal;

            taxTotal = total * taxes;

            return taxTotal;
        }
        public static void FinalReceipt()
        {
            foreach (product item in fullCart)
            {
                Console.WriteLine(item);
            }
        }
        public static decimal totalWithTax()
        {
            decimal taxedTotal = shoppingCart.Taxes(shoppingCart.cartTotal()) + shoppingCart.cartTotal();
            return taxedTotal;
        }

    }
    public class storeInventory
    {
        public static List<product> inventory = new List<product>();

        public static void AddProduct(product theItem)
        {
            inventory.Add(theItem);
        }
    }
    public class Program
    {
        static void Main()
        {
            storeInventory.AddProduct(new product("apple", "produce", "food", 1.00m));
            storeInventory.AddProduct(new product("milk", "dairy", "food", 3.99m));
            storeInventory.AddProduct(new product("ham", "meat", "food", 5.99m));
            storeInventory.AddProduct(new product("pasta", "carbs", "food", 1.00m));
            storeInventory.AddProduct(new product("battery Pack", "electronics", "power", 4.69m));
            storeInventory.AddProduct(new product("asprin", "health", "pain relief", 10.70m));
            storeInventory.AddProduct(new product("charcoal", "outdoors", "fuel", 12.04m));
            storeInventory.AddProduct(new product("baseball", "sports", "sports ball", 5.54m));
            storeInventory.AddProduct(new product("cat food", "pets", "cat fuel", 15.54m));
            storeInventory.AddProduct(new product("dog food", "pets", "dog fuel", 13.56m));
            storeInventory.AddProduct(new product("shirt", "clothing", "mens shirt", 20.06m));
            storeInventory.AddProduct(new product("tire", "automotive", "car part", 73.06m));

            bool isRunning = true;
            while (isRunning)
            {
                shoppingTime();
                Checkout();
            }
        }
        public static void Checkout()
        {
            decimal taxedTotal = shoppingCart.totalWithTax();
            decimal change;

            shoppingCart.FinalReceipt();
            Console.WriteLine("");
            Console.WriteLine($"Your subtotal is: {shoppingCart.cartTotal():C2}");
            Console.WriteLine($"Your taxes are: {shoppingCart.Taxes(shoppingCart.cartTotal()):C2}");
            Console.WriteLine($"Your total including taxes is: {taxedTotal:C2}\n");
            
            bool isCorrectMoney = true;
            while (isCorrectMoney)
            {
                Console.Write("Enter the amount you'd like to pay?: $");

                bool isValid = decimal.TryParse(Console.ReadLine(), out decimal paymentAmount);
                while (!isValid)
                {
                    Console.Write("That's not money. Please try again: $");
                    isValid = decimal.TryParse(Console.ReadLine(), out paymentAmount);
                }

                change = paymentAmount - taxedTotal;

                if (change >= 0)
                {
                    bool shopAgain = true;
                    while (shopAgain)
                    {
                        Console.WriteLine($"Your change is {change:C2}");
                        Console.WriteLine("");
                        Console.WriteLine("Would you like to shop again?");
                        string askAgain = Console.ReadLine().ToLower();
                        if (askAgain == "y")
                        {
                            shoppingCart.fullCart.Clear();
                            Console.Clear();
                            isCorrectMoney = false;
                            break;

                        }
                        else if (askAgain == "n")
                        {
                            Console.Clear();
                            Environment.Exit(1);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"That is not enough money, please enter more than {taxedTotal:C2}");
                    continue;
                }
            }
        }
        public static void Menu()
        {
            int counter = 1;

            foreach (product p in storeInventory.inventory)
            {
                if (counter <= 9)
                {
                    Console.WriteLine($" {counter}|{p}");
                }
                else
                {
                    Console.WriteLine($"{counter}|{p}");
                }
                counter++;
            }
        }
        public static void shoppingTime()
        {
            string keepGoing = "y";

            while (keepGoing != "n")
            {
                Menu();

                Console.WriteLine("What do you want to choose?");
                int itemChoice = int.Parse(Console.ReadLine());
                itemChoice--;

                Console.WriteLine($"How many {storeInventory.inventory[itemChoice].Name}s would you like to purchase?");
                int numberOfItems = int.Parse(Console.ReadLine());

                decimal lineTotal = 0m;

                //Adds product to shopping cart

                for (int index = 0; index < numberOfItems; index++)
                {
                    shoppingCart.itemSelect(itemChoice, storeInventory.inventory);
                    lineTotal += storeInventory.inventory[itemChoice].Price;
                }

                //views what was added
                //foreach (product item in shoppingCart.fullCart)
                //{
                //    Console.WriteLine(item);
                //}
                Console.WriteLine($"{numberOfItems} {storeInventory.inventory[itemChoice].Name}s totals {lineTotal:C2}");

                Console.WriteLine("Would you like to purchase more? (y/n)");
                keepGoing = Console.ReadLine();
                Console.Clear();
            }

        }
    }
}
