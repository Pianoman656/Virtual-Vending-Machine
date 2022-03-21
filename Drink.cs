using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.VendingItemType
{
    public class Drink : Item
    {
        public Drink(string name, decimal price) : base(name, price)
        {

        }

        public override string MakeNoise()
        {
            return "Glug Glug, Yum!";
        }
    }
}
