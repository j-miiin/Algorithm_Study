using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.RegexSolutions
{
    internal class Contact
    {
        static void Main(string[] args)
        {
            const string YES = "YES";
            const string NO = "NO";

            Regex regex = new Regex(@"^(100+1+|01)+$");

            int T = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < T; i++)
            {
                if (regex.IsMatch(Console.ReadLine()))
                {
                    sb.Append(YES).Append("\n");
                } else
                {
                    sb.Append(NO).Append("\n");
                }
            }

            Console.WriteLine(sb.ToString());   
        }
    }
}
