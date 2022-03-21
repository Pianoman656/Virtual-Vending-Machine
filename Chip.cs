using System;
using System.Collections.Generic;
using System.Text;


namespace Capstone.VendingItemType
{
    public class Chip : Item
    {
        public Chip(string name, decimal price) : base(name, price)
        {

        }

        public override string MakeNoise()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
