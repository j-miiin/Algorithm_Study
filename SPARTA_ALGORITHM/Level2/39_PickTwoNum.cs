using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class PickTwoNum
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Solution.solution(new int[] { 2, 1, 3, 4, 1 })));
        }

        public class Solution
        {
            static int[] nums;
            static bool[] visited;
            static bool[] check;
            static List<int> result;

            public static int[] solution(int[] numbers)
            {
                nums = numbers;
                visited = new bool[numbers.Length];
                check = new bool[101];
                result = new List<int>();

                dfs(0, 0, 0);
                result.Sort();

                int[] answer = result.ToArray();
                return answer;
            }

            static void dfs(int start, int depth, int sum)
            {
                if (depth == 2)
                {
                    if (!check[sum])
                    {
                        check[sum] = true;
                        result.Add(sum);
                    }
                    return;
                }

                for (int i = start; i < nums.Length; i++)
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        dfs(start + 1, depth + 1, sum + nums[i]);
                        visited[i] = false;
                    }
                }
            }
        }
    }
}
