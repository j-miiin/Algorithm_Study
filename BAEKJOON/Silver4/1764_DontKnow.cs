using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver4
{
    class DontKnow
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");

            int N = int.Parse(str[0]);
            int M = int.Parse(str[1]);

            Dictionary<string, int> dic = new Dictionary<string, int>();
            List<string> list = new List<string>();

            for (int i = 0; i < N; i++)
            {
                string name = Console.ReadLine();
                dic.Add(name, 1);
            }

            for (int i = 0; i < M; i++)
            {
                string name = Console.ReadLine();

                if (dic.ContainsKey(name))
                {
                    list.Add(name);
                }
            }

            list.Sort();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                sb.Append(list[i]).Append("\n");
            }

            Console.WriteLine(list.Count);
            Console.WriteLine(sb.ToString());
        }

    }
}
