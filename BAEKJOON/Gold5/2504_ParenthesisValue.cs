using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class ParenthesisValue
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            Stack<string> stack = new Stack<string>();

            bool isRight = true;
            for (int i = 0; i < s.Length; i++)
            {
                string cur = s[i].ToString();

                if (cur == "(" || cur == "[")
                {
                    stack.Push(cur);
                } else if (cur == ")")
                {
                    if (stack.Count == 0 || stack.Peek() != "(")
                    {
                        isRight = false;
                    } else
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    if (stack.Count == 0 || stack.Peek() != "[")
                    {
                        isRight = false;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }

                if (!isRight)
                {
                    Console.WriteLine(0);
                    return;
                }
            }

            if (stack.Count > 0)
            {
                Console.WriteLine(0);
                return;
            }

            stack.Clear();

            for (int i = 0; i < s.Length; i++)
            {
                string cur = s[i].ToString();

                if (cur == "(" || cur == "[")
                {
                    stack.Push(cur);
                }
                else if (cur == ")")
                {
                    int tmp = 0;
                    while (stack.Count > 0)
                    {
                        string str = stack.Pop();   
                        if (str == "(")
                        {
                            break;
                        }

                        tmp += int.Parse(str);
                    }

                    if (tmp == 0)
                    {
                        stack.Push("2");
                    } else
                    {
                        stack.Push((tmp * 2).ToString());
                    }
                } else
                {
                    int tmp = 0;
                    while (stack.Count > 0)
                    {
                        string str = stack.Pop();
                        if (str == "[")
                        {
                            break;
                        }

                        tmp += int.Parse(str);
                    }

                    if (tmp == 0)
                    {
                        stack.Push("3");
                    }
                    else
                    {
                        stack.Push((tmp * 3).ToString());
                    }
                }
            }

            int answer = 0;
            while (stack.Count > 0)
            {
                answer += int.Parse(stack.Pop());
            }

            Console.WriteLine(answer);
        }
    }
}
