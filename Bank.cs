using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Bank
    {
        public decimal Balance { get; set; }
        
        public decimal Pay(decimal balance, string id, Item thisItem)
        {
            decimal initalBalance = balance;
            balance -= thisItem.Price;

            VendLog.Log($"{thisItem.Name} {id} ${initalBalance.ToString("0.00")} ${balance.ToString("0.00")}");

            return balance;
        }

        public int InsertMoney(string moneyInserted)
        {
            int input;
            bool success = int.TryParse(moneyInserted, out input);
            input = success ? input : 0;
            return input;
        }

        public string Change(decimal remainingBalance)
        {
            decimal beforeChange = remainingBalance;
            int countNickles = 0;
            int countDimes = 0;
            int countQuarters = 0;

            while (remainingBalance - .25M >= 0M)
            {
                countQuarters++;
                remainingBalance -= .25M;
            }
            while (remainingBalance - .10M >= 0M)
            {
                countDimes++;
                remainingBalance -= .10M;
            }
            while (remainingBalance - .05M >= 0M)
            {
                countNickles++;
                remainingBalance -= .05M;
            }
            while (remainingBalance - .01M >= 0M)
            {
                remainingBalance -= .01M;
            }
            
            if (remainingBalance != 0)
            {
                return "Please call us for a full refund. 18008008000";
            }

            return $"You get {countQuarters} quarters, {countDimes} dimes, and {countNickles} nickles. Thanks!";
        }
    }
}
