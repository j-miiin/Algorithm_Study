using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class LIS4
    {
        static void Main(string[] args)
        {
            int A = int.Parse(Console.ReadLine());
            int[] array = new int[A];

            string[] str = Console.ReadLine().Split(" ");
            for (int i = 0; i < A; i++)
            {
                array[i] = int.Parse(str[i]);
            }

            int max = 1;
            int[] count = new int[A];
            for (int i = 0; i < A; i++)
            {
                count[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (array[j] < array[i] && count[i] < count[j] + 1)
                    {
                        count[i] = count[j] + 1;
                        max = Math.Max(max, count[i]);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(max).Append("\n");

            List<int> increasingSequence = new List<int>();
            for (int i = count.Length - 1; i >= 0; i--)
            {
                if (max == 0)
                {
                    break;
                }

                if (count[i] == max)
                {
                    increasingSequence.Add(array[i]);
                    max--;
                }
            }

            for (int i = increasingSequence.Count - 1; i >= 0; i--)
            {
                sb.Append(increasingSequence[i]).Append(" ");
            }

            Console.WriteLine(sb.ToString());   
        }
    }
}
