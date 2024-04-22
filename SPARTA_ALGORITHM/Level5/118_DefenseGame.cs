using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class DefenseGame
    {
        public class Solution
        {
            public int solution(int n, int k, int[] enemy)
            {
                int answer = 0;
                SortedDictionary<int, int> skillRound = new SortedDictionary<int, int>();
                for (int i = 0; i < k && i < enemy.Length; i++)
                {
                    int key = enemy[i];
                    if (!skillRound.ContainsKey(key))
                        skillRound.Add(key, 0);
                    skillRound[key]++;
                    answer++;
                }

                for (int i = k; i < enemy.Length; i++)
                {
                    int minEnemy = skillRound.First().Key;
                    if (minEnemy < enemy[i])
                    {
                        if (minEnemy <= n)
                        {
                            skillRound[minEnemy]--;
                            if (skillRound[minEnemy] == 0) skillRound.Remove(minEnemy);
                            int key = enemy[i];
                            if (!skillRound.ContainsKey(key)) skillRound.Add(key, 0);
                            skillRound[key]++;
                            n -= minEnemy;
                            answer++;
                        }
                        else break;
                    } else
                    {
                        if (enemy[i] <= n)
                        {
                            n -= enemy[i];
                            answer++;
                        }
                        else break;
                    }
                }

                return answer;
            }
        }
    }
}
