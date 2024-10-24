using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class MakeCode
    {
        static int L, C;
        static string[] alphabets;
        static List<string> result = new List<string>();
        static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            L = int.Parse(str[0]);
            C = int.Parse(str[1]);

            alphabets = Console.ReadLine().Split(" ");
            Array.Sort(alphabets);

            MakePossibleCode(0, new List<string>());

            sb.Clear();
            for (int i = 0; i < result.Count; i++)
            {
                sb.Append(result[i]).Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }

        static void MakePossibleCode(int start, List<string> codeList)
        {
            if (codeList.Count == L)
            {
                int count = 0;
                for (int i = 0; i < codeList.Count; i++)
                {
                    if (codeList[i] == "a" || codeList[i] == "e" 
                        || codeList[i] == "i" || codeList[i] == "o"
                        || codeList[i] == "u")
                    {
                        count++;
                    }
                }

                if (count >= 1 && count <= L - 2)
                {
                    sb.Clear();
                    for (int i = 0; i < codeList.Count; i++)
                    {
                        sb.Append(codeList[i]);
                    }
                    result.Add(sb.ToString());
                }

                return;
            }

            for (int i = start; i < alphabets.Length; i++)
            {
                codeList.Add(alphabets[i]);
                MakePossibleCode(i + 1, codeList);
                codeList.RemoveAt(codeList.Count - 1);
            }
        }
    }
}
