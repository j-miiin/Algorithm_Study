using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class DSLR
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            bool[] visited = new bool[10001];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < T; i++)
            {
                string[] str = Console.ReadLine().Split(" ");

                int A = int.Parse(str[0]);
                int B = int.Parse(str[1]);

                Array.Fill(visited, false);

                sb.Append(Search(A, B, visited)).Append("\n");
            }

            Console.WriteLine(sb.ToString());   
        }

        static string Search(int A, int B, bool[] visited)
        {
            int[] result = null;

            Queue<int[]> queue = new Queue<int[]>();

            visited[A] = true;
            queue.Enqueue(new int[] { A });

            while (queue.Count > 0)
            {
                int[] cur = queue.Dequeue();
                int curValue = cur[0];

                if (curValue == B)
                {
                    result = cur;
                    break;
                }

                int nextValue = CommandD(curValue);
                if (!visited[nextValue])
                {
                    visited[nextValue] = true;
                    queue.Enqueue(GetNextArray(nextValue, 0, cur));
                }

                nextValue = CommandS(curValue);
                if (!visited[nextValue])
                {
                    visited[nextValue] = true;
                    queue.Enqueue(GetNextArray(nextValue, 1, cur));
                }

                nextValue = CommandL(curValue);
                if (!visited[nextValue])
                {
                    visited[nextValue] = true;
                    queue.Enqueue(GetNextArray(nextValue, 2, cur));
                }

                nextValue = CommandR(curValue);
                if (!visited[nextValue])
                {
                    visited[nextValue] = true;
                    queue.Enqueue(GetNextArray(nextValue, 3, cur));
                }
            }
        
            StringBuilder sb = new StringBuilder(); 
            for (int i = 1; i < result.Length; i++)
            {
                if (result[i] == 0)
                {
                    sb.Append("D");
                } else if (result[i] == 1)
                {
                    sb.Append("S");
                } else if (result[i] == 2)
                {
                    sb.Append("L");
                } else
                {
                    sb.Append("R");
                }
            }

            return sb.ToString();
        }

        static int[] GetNextArray(int nextValue, int command, int[] cur)
        {
            int[] next = new int[cur.Length + 1];
            next[0] = nextValue;
            next[next.Length - 1] = command;
            Array.Copy(cur, 1, next, 1, cur.Length - 1);

            return next;
        }

        static int CommandD(int n)
        {
            n *= 2;
            n %= 10000;
            return n;
        }

        static int CommandS(int n)
        {
            n -= 1;
            n = (n == -1) ? 9999 : n;
            return n;
        }

        static int CommandL(int n)
        {
            return (n % 1000) * 10 + n / 1000;
        }

        static int CommandR(int n)
        {
            return (n - n % 10) / 10 + (n % 10) * 1000;
        }
    }
}
