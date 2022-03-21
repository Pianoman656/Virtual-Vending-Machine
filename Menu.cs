using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Menu : ConsoleService
    {
        Bank bank = new Bank();
        public void DisplayFirstMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n(1) Display Vending Machine Items");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("(2) Purchase");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("(3) Exit");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Please enter a menu option: ");
        }
        
        public void DisplayPurchaseMenu(decimal Balance)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n(1) Feed Money");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("(2) Select Product");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("(3) Finish Transaction");
            Console.ResetColor();
            //potential fourth option hidden from user (4)
            Console.WriteLine();
            Console.WriteLine($"Current Money Provided: ${Balance.ToString("0.00")}");
            Console.WriteLine();
            Console.Write("Please enter a menu option: ");
        }
        
        public void ListAvailableItems(Dictionary<string, List<Item>> dictionaryOfItems)
        {
            int count = 0;
            Console.WriteLine();
            foreach (KeyValuePair<string, List<Item>> item in dictionaryOfItems)
            { 
                if (count == 3)
                {
                    count = 0;
                }

                if (dictionaryOfItems[item.Key].Count != 0)
                {
                    if (count == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\n{item.Value[0].Name}".PadRight(20));
                        Console.Write($"| {item.Key} | ");
                        Console.Write($"{item.Value[0].Price} | ");
                        Console.Write($"Qty: {item.Value.Count}");
                        Console.ResetColor();
                        count++;
                    }
                    else if (count == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"\n{item.Value[0].Name}".PadRight(20));
                        Console.Write($"| {item.Key} | ");
                        Console.Write($"{item.Value[0].Price} | ");
                        Console.Write($"Qty: {item.Value.Count}");
                        Console.ResetColor();
                        count++;
                    }
                    else if (count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"\n{item.Value[0].Name}".PadRight(20));
                        Console.Write($"| {item.Key} | ");
                        Console.Write($"{item.Value[0].Price} | ");
                        Console.Write($"Qty: {item.Value.Count}");
                        Console.ResetColor();
                        count++;
                    }
                    
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public void Run(Dictionary<string, List<Item>> dictionaryOfItems, decimal Balance)
        {
            string choice = null;
            while (choice != "3")
            {
                DisplayFirstMenu();
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    ListAvailableItems(dictionaryOfItems);
                    base.Pause();
                }
                if (choice == "2")
                {
                    NavigatePurchaseMenu(dictionaryOfItems, Balance);
                }
            }
            Environment.Exit(0);
            Console.WriteLine("Exiting Application!");
        }

        private void NavigatePurchaseMenu(Dictionary<string, List<Item>> dictionaryOfItems, decimal Balance)
        {
            while (true)
            {
                DisplayPurchaseMenu(Balance);
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter amount in whole dollars: $");
                    string insertMoneyString = Console.ReadLine();
                    int insertedMoney = bank.InsertMoney(insertMoneyString);
                    Balance += insertedMoney;

                    VendLog.Log($"FEED MONEY: ${insertedMoney.ToString("0.00")} ${Balance.ToString("0.00")}");
                }
                else if (choice == "2")
                {
                    ListAvailableItems(dictionaryOfItems);
                    Console.Write("Select an avaliable item ID from the list: ");
                    string id = Console.ReadLine();
                    Item thisItem = dictionaryOfItems[id][0];

                    if (dictionaryOfItems.ContainsKey(id) && dictionaryOfItems[id].Count > 0 && thisItem.Price <= Balance)
                    {
                        Console.WriteLine($"{thisItem.Name}, {thisItem.Price}, {thisItem.MakeNoise()}");
                        Balance = bank.Pay(Balance, id, thisItem);
                        Console.WriteLine($"Your new balance is: {Balance}");
                        base.Pause();
                        dictionaryOfItems[id].Remove(thisItem);
                    }
                    else
                    {
                        NoVendForYou(dictionaryOfItems, Balance, id);
                    }
                }
                else if (choice == "3")
                {
                    decimal remainingBalance = Balance;
                    Console.WriteLine(bank.Change(Balance));
                    base.Pause();
                    VendLog.Log($"GIVE CHANGE: ${remainingBalance.ToString("0.00")} $0.00");
                    break;
                }
            }
        }
        

        private void NoVendForYou(Dictionary<string, List<Item>> dictionaryOfItems, decimal Balance, string id)
        {
            if (!dictionaryOfItems.ContainsKey(id)) 
            {
                Console.WriteLine("Invalid Code. Please re-enter Slot Position.");
                base.Pause();
            }
            else if (dictionaryOfItems[id].Count <= 0) 
            {
                Console.WriteLine("Item is sold out. Returning to purchase menu..");
                base.Pause();
            }
            else if (dictionaryOfItems[id][0].Price > Balance) 
            {
                Console.WriteLine("You're broke bruh!");
                base.Pause();
            }
        }
    }
}