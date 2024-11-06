using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon
{
    internal class ReverseWords2_Regex
    {
        static void Main(string[] args)
        {
            string S = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            Regex regex = new Regex(@"<[a-z\s]+>|[a-z0-9]+");

            int idx = 0;
            foreach (var match in regex.Matches(S))
            {
                string cur = match.ToString();
                if (cur[0] == '<')
                {
                    sb.Append(cur);
                }
                else
                {
                    foreach (var c in cur.Reverse())
                    {
                        sb.Append(c);
                    }
                }

                idx += cur.Length;
                if (idx < S.Length && S[idx] == ' ')
                {
                    sb.Append(" ");
                    idx++;
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
