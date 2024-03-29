using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class HotelBooking2
    {
        public class Solution
        {
            public int solution(string[,] book_time)
            {
                int[] usedTime = new int[1500];

                for (int i = 0; i < book_time.GetLength(0); i++)
                {
                    string[] start = book_time[i, 0].Split(':');
                    string[] end = book_time[i, 1].Split(':');

                    int startTime = int.Parse(start[0]) * 60 + int.Parse(start[1]);
                    int endTime = int.Parse(end[0]) * 60 + int.Parse(end[1]) + 10;

                    for (int j = startTime; j < endTime; j++)
                    {
                        usedTime[j]++;
                    }
                }

                return usedTime.Max();
            }
        }
    }
}
