using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class WordMath
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            
            List<string> words = new List<string>();
            Dictionary<char, int> weightDic = new Dictionary<char, int>();
            for (int i = 0; i < N; i++)
            {
                string s = Console.ReadLine();
                words.Add(s);

                for (int j = 0; j < s.Length; j++)
                {
                    if (!weightDic.ContainsKey(s[j]))
                    {
                        weightDic[s[j]] = (int)Math.Pow(10, s.Length - j - 1);
                    } else
                    {
                        weightDic[s[j]] += (int)Math.Pow(10, s.Length - j - 1);
                    }
                }
            }

            List<char> chars = weightDic.Keys.ToList();
            chars.Sort((c1, c2) => { return weightDic[c2] - weightDic[c1]; });

            int value = 9;
            for (int i = 0; i < chars.Count; i++)
            {
                weightDic[chars[i]] = value;
                value--;
            }

            int answer = 0;
            foreach (string w in words)
            {
                for (int i = 0; i < w.Length; i++)
                {
                    answer += weightDic[w[i]] * (int)Math.Pow(10, (w.Length - i - 1));
                }
            }

            Console.WriteLine(answer);
        }
    }
}
