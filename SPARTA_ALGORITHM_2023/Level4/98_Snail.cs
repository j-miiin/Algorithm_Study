using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class Snail
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Solution.solution(6)));
        }

        public class Solution
        {
            public static int[] solution(int n)
            {
                int length = (n * n + n) / 2;
                int curNum = 1;

                int[,] snail = new int[n, n];
                int start = 0;
                int end = n - 1;
                while (curNum <= length)
                {
                    Console.WriteLine($"start = {start}, end = {end}");

                    for (int i = start; i <= end - 1 && curNum <= length; i++)
                    {
                        snail[i, start] = curNum++;
                        Console.WriteLine($"snail[{i}, {start}] = {snail[i, start]}");
                    }

                    Console.WriteLine();

                    for (int i = start; i < end && curNum <= length; i++)
                    {
                        snail[end, i] = curNum++;
                        Console.WriteLine($"snail[{end}, {i}] = {snail[end, i]}");
                    }

                    Console.WriteLine();

                    for (int i = end; i > start + 1 && curNum <= length; i--)
                    {
                        snail[i, i] = curNum++;
                        Console.WriteLine($"snail[{i}, {i}] = {snail[i, i]}");
                    }

                    Console.WriteLine();

                    start++;
                    end--;
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(snail[i, j] + ", ");
                    }
                    Console.WriteLine();
                }

                int[] answer = new int[length];

                int idx = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        answer[idx++] = snail[i, j];
                    }
                }

                return answer;
            }
        }
    }
}
