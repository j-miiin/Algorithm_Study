using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class LosingParenthesis
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            int sum = 0;
            int sub = 0;
            bool isParenthesis = false;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c == '+')
                {
                    int tmp = int.Parse(sb.ToString());
                    if (isParenthesis)
                    {
                        sub += tmp;
                    } else
                    {
                        sum += tmp;
                    }
                    sb.Clear();
                } else if (c == '-')
                {
                    if (!isParenthesis && sb.Length > 0)
                    {
                        sum += int.Parse(sb.ToString());
                        sb.Clear();

                        isParenthesis = true;
                    } else if (isParenthesis)
                    {
                        if (sb.Length > 0)
                        {
                            sub += int.Parse(sb.ToString());
                            sb.Clear();
                        }

                        sum -= sub;
                        sub = 0;
                    }
                } else
                {
                    sb.Append(c);
                }
            }

            if (isParenthesis && sb.Length > 0)
            {
                sum -= sub + int.Parse(sb.ToString());
            } else if (!isParenthesis && sb.Length > 0)
            {
                sum += int.Parse(sb.ToString());
            }

            Console.WriteLine(sum);
        }
    }
}
