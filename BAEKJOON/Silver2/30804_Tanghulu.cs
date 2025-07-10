using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmStudy.Baekjoon.Silver2
{
    class Tanghulu
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[] fruits = new int[N];
            Dictionary<int, int> fruitsDic = new Dictionary<int, int>();

            string[] str = Console.ReadLine().Split(" ");

            for (int i = 0; i < N; i++)
            {
                int f = int.Parse(str[i]);
                fruits[i] = f;

                if (fruitsDic.ContainsKey(f))
                    fruitsDic[f]++;
                else
                    fruitsDic.Add(f, 1);
            }

            if (fruitsDic.Keys.Count <= 2)
            {
                Console.WriteLine(fruits.Length);
                return;
            }

            int front = 0;
            int back = 0;
            int maxFruits = 0;

            fruitsDic.Clear();
            fruitsDic.Add(fruits[front], 1);

            while (front <= back && back < fruits.Length - 1)
            {
                back++;

                int key = fruits[back];

                if (fruitsDic.ContainsKey(key))
                    fruitsDic[key]++;
                else
                    fruitsDic.Add(key, 1);

                while (fruitsDic.Keys.Count > 2)
                {
                    int removedKey = fruits[front];
                    fruitsDic[removedKey]--;

                    if (fruitsDic[removedKey] == 0) 
                        fruitsDic.Remove(removedKey);

                    front++;
                }

                maxFruits = Math.Max(maxFruits, back - front + 1);
            }

            Console.WriteLine(maxFruits);
        }
    }
}
