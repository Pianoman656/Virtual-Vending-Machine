using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.VendingItemType
{
    public class Candy : Item
    {
        public Candy(string name, decimal price) : base(name, price)
        {

        }

        public override string MakeNoise()
        {
            return "Munch Munch, Yum!";
        }
    }
}
