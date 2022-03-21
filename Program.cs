using System;
using System.Collections.Generic;
using Capstone;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            Menu menu = new Menu();
            TextFileStock inventory = new TextFileStock();
            Bank bank = new Bank();
            
            Dictionary<string, List<Item>> dictionaryofItems = inventory.Stock();

            menu.Run(dictionaryofItems, bank.Balance);
            
        }
    }
}
