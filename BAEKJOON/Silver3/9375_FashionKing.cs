using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmStudy.Baekjoon.Silver3
{
    class FashionKing
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < T; i++)
            {
                int n = int.Parse(Console.ReadLine());

                Dictionary<string, List<string>> clothes = new Dictionary<string, List<string>>();

                for (int j = 0; j < n; j++)
                {
                    string[] str = Console.ReadLine().Split(" ");
                    string name = str[0];
                    string category = str[1];

                    if (clothes.ContainsKey(category))
                        clothes[category].Add(name);
                    else
                        clothes.Add(category, new List<string>() { name });
                }

                int count = 1;

                foreach (List<string> list in clothes.Values)
                {
                    count *= list.Count + 1;
                }

                sb.Append(count - 1).Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
