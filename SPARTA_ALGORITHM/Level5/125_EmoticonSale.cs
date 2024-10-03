using System;
using System.Collections.Generic;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class EmoticonSale
    {
        public class Solution
        {
            public class Emoticon
            {
                public int price;
                public int discountRatio;

                public Emoticon(int p, int r)
                {
                    price = p;
                    discountRatio = r;
                }
            }

            public static int maxMemberCount;
            public static int maxSales;

            public int[] solution(int[,] users, int[] emoticons)
            {
                List<Emoticon> emoticonList = new List<Emoticon>();

                for (int i = 0; i < emoticons.Length; i++)
                {
                    emoticonList.Add(new Emoticon(emoticons[i], 0));
                }

                DfsSearch(0, users, emoticonList);

                int[] answer = new int[2]{ maxMemberCount, maxSales };
                return answer;
            }

            public static void DfsSearch(int idx, int[,] users, List<Emoticon> emoticonList)
            {
                if (idx == emoticonList.Count)
                {
                    int memberCount = 0;
                    int sales = 0;

                    for (int i = 0; i < users.GetLength(0); i++)
                    {
                        int minDiscount = users[i, 0];
                        int minPrice = users[i, 1];

                        int price = 0;
                        for (int j = 0; j < emoticonList.Count; j++)
                        {
                            if (emoticonList[j].discountRatio < minDiscount)
                            {
                                continue;
                            }

                            price += emoticonList[j].price * (100 - emoticonList[j].discountRatio) / 100;
                        }

                        if (price < minPrice)
                        {
                            sales += price;
                        }
                        else
                        {
                            memberCount++;
                        }
                    }

                    if (memberCount > maxMemberCount)
                    {
                        maxMemberCount = memberCount;
                        maxSales = sales;
                    } else if (memberCount == maxMemberCount)
                    {
                        maxSales = Math.Max(maxSales, sales);
                    }

                    return;
                }

                for (int i = 10; i <= 40; i += 10)
                {
                    emoticonList[idx].discountRatio = i;
                    DfsSearch(idx + 1, users, emoticonList);
                }
            }
        }
    }
}
