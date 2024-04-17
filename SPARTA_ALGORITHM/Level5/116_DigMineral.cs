using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class DigMineral
    {
        public class Solution
        {
            const int DIAMOND = 0;
            const int IRON = 1;
            const int STONE = 2;

            static int totalPicks = 0;
            static int requiredPicks;
            static int[] pickList;
            static string[] mineralList;
            static int[,] fatigueRate = { { 1, 1, 1 }, { 5, 1, 1 }, { 25, 5, 1 } };

            static int answer = int.MaxValue;

            public int solution(int[] picks, string[] minerals)
            {
                for (int i = 0; i < picks.Length; i++) totalPicks += picks[i];
                requiredPicks = minerals.Length / 5;
                if (minerals.Length % 5 != 0) requiredPicks++;
                pickList = picks;
                mineralList = minerals;

                Dfs(new List<int>());
                return answer;
            }

            static void Dfs( List<int> comb)
            {
                if (comb.Count == requiredPicks || totalPicks == 0)
                {
                    answer = Math.Min(answer, Dig(comb));
                    return;
                }

                for (int i = 0; i < 3; i++)
                {
                    if (pickList[i] == 0) continue;
                    List<int> newComb = new List<int>();
                    foreach (int p in comb) newComb.Add(p);
                    newComb.Add(i);
                    totalPicks--;
                    pickList[i]--;
                    Dfs(newComb);
                    totalPicks++;
                    pickList[i]++;
                }
            }

            static int Dig(List<int> comb)
            {
                int result = 0;
                for (int i = 0; i < comb.Count; i++)
                {
                    int curPick = comb[i];
                    for (int j = i * 5; (j < i * 5 + 5 && j < mineralList.Length); j++)
                    {
                        int curMineral = STONE;
                        if (mineralList[j] == "diamond") curMineral = DIAMOND;
                        else if (mineralList[j] == "iron") curMineral = IRON;
                        result += fatigueRate[curPick, curMineral];
                    }
                }
                return result;
            }
        }
    }
}
