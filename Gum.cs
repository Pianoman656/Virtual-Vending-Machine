using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.VendingItemType
{
    public class Gum : Item
    {
        public Gum (string name, decimal price) : base(name, price)
        {

        }

        public override string MakeNoise()
        {
            return "Chew Chew, Yum!";
        }
    }
}
