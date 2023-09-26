using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class Fatigue
    {
        public class Solution
        {
            static bool[] visited;
            static int result = 0;
            public int solution(int k, int[,] dungeons)
            {
                visited = new bool[dungeons.GetLength(0)];

                dfs(k, 0, dungeons);

                int answer = result;
                return answer;
            }

            static void dfs(int curFatigue, int count, int[,] dungeons)
            {
                result = Math.Max(result, count);

                for (int i = 0; i < dungeons.GetLength(0); i++)
                {
                    if (!visited[i])
                    {
                        int needFatigue = dungeons[i, 0];
                        int useFatigue = dungeons[i, 1];

                        if (curFatigue < needFatigue) continue;

                        visited[i] = true;
                        dfs(curFatigue - useFatigue, count + 1, dungeons);
                        visited[i] = false;
                    }
                }
            } 
        }
    }
}
