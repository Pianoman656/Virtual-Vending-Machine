using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public abstract class Item 
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public abstract string MakeNoise();
    }
}
