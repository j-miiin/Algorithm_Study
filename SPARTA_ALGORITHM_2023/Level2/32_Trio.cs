using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class Trio
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(new int[] { -2, 3, 0, 2, -5 }));
        }

        public class Solution
        {
            static int count = 0;
            static int[] students;
            static bool[] visited;
            public static int solution(int[] number)
            {
                int answer = 0;

                students = number;
                visited = new bool[number.Length];

                dfs(0, 0, 0);

                answer = count;

                return answer;
            }

            static void dfs(int start, int depth, int sum)
            {
                if (depth == 3)
                {
                    if (sum == 0)
                    {
                        count++;
                    }
                    return;
                }

                for (int i = start; i < students.Length; i++)
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        dfs(i + 1, depth + 1, sum + students[i]);
                        visited[i] = false;
                    }
                }
            }
        }
    }
}
