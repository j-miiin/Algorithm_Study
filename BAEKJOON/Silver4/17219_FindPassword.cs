using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmStudy.Baekjoon.Silver4
{
    class FindPassword
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            int M = int.Parse(str[1]);

            Dictionary<string, string> passwords = new Dictionary<string, string>();

            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                string site = str[0];
                string pw = str[1]; 

                passwords.Add(site, pw);
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < M; i++)
            {
                string site = Console.ReadLine();
                sb.Append(passwords[site]).Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
