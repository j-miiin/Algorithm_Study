using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class ShortOfMoney
    {
        class Solution
        {
            public long solution(int price, int money, int count)
            {
                long totalPrice = 0;
                for (int i = 1; i <= count; i++)
                {
                    totalPrice += i * price;
                }
                return (money >= totalPrice) ? 0 : (totalPrice - money);
            }
        }
    }
}
