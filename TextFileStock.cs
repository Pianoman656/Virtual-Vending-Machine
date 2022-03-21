using System;
using System.Collections.Generic;
using System.IO;
using Capstone.VendingItemType;

namespace Capstone
{
    public class TextFileStock
    {
        public Dictionary<string, List<Item>> Stock()
        {
            string inputpath = "C:\\Users\\Student\\workspace\\c-sharp-mini-capstone-module-1-team-3\\vendingmachine.csv";
            Dictionary<string, List<Item>> newStock = new Dictionary<string, List<Item>>();
            try
            {
                using (StreamReader sr = new StreamReader(inputpath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] itemData = line.Split("|");
                        Item item = null;
                        List<Item> listOfItems = new List<Item>();
                        // set up an item, an instance of Item

                        for (int i = 0; i < itemData.Length; i++)
                        {
                            if (itemData[3].Contains("Gum"))
                            {
                                item = new Gum(itemData[1], decimal.Parse(itemData[2]));
                            }
                            if (itemData[3] == "Candy")
                            {
                                item = new Candy(itemData[1], decimal.Parse(itemData[2]));
                            }
                            if (itemData[3] == "Chip")
                            {
                                item = new Chip(itemData[1], decimal.Parse(itemData[2]));
                            }
                            if (itemData[3] == "Drink")
                            {
                                item = new Drink(itemData[1], decimal.Parse(itemData[2]));
                            }
                            listOfItems.Add(item);
                        }

                        newStock[itemData[0]] = listOfItems;
                    }
                }
            }
            catch (IOException ex)
            {
                throw new IOException(ex.Message);
            };
            return newStock;
        }
    }
}
