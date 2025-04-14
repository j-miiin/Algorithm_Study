using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver5
{
    internal class Set
    {
        static void Main(string[] args)
        {
            int M = int.Parse(Console.ReadLine());

            HashSet<int> set = new HashSet<int>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < M; i++)
            {
                string[] str = Console.ReadLine().Split(" ");
                string command = str[0];
                int x = -1;

                if (command != "all" && command != "empty")
                    x = int.Parse(str[1]);

                switch (command)
                {
                    case "add":
                        set.Add(x);
                        break;

                    case "remove":
                        set.Remove(x);
                        break;

                    case "check":
                        if (set.Contains(x))
                            sb.Append(1).Append("\n");
                        else
                            sb.Append(0).Append("\n");
                        break;

                    case "toggle":
                        if (set.Contains(x))
                            set.Remove(x);
                        else
                            set.Add(x);
                            break;

                    case "all":
                        set.Clear();
                        for (int j = 1; j <= 20; j++)
                            set.Add(j);
                        break;

                    case "empty":
                        set.Clear();
                        break;
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
