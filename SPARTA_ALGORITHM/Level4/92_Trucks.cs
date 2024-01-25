using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class Trucks
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(10, 12, new int[] { 4, 4, 4, 2, 2, 1, 1, 1, 1 }));
        }

        public class Solution
        {
            public static int solution(int bridge_length, int weight, int[] truck_weights)
            {
                int answer = 0;

                int idx = 0;
                int sum = 0;
                List<int> list = new List<int>();
                for (int i = 0; i < bridge_length; i++) list.Add(0);

                while (list.Count > 0)
                {
                    answer++;

                    sum -= list[0];
                    list.RemoveAt(0);

                    if (idx < truck_weights.Length)
                    {
                        if (sum + truck_weights[idx] <= weight)
                        {
                            sum += truck_weights[idx];
                            list.Add(truck_weights[idx]);
                            idx++;
                        } else
                        {
                            list.Add(0);
                        }
                    }
                }

                return answer;
            }
        }
    }
}
