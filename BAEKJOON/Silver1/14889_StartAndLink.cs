using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class StartAndLink
    {
        static int N;
        static int[,] ability;

        static int answer = int.MaxValue;

        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            ability = new int[N, N];

            string[] str;
            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                for (int j = 0; j < N; j++)
                {
                    ability[i, j] = int.Parse(str[j]);
                }
            }

            MakeTeam(0, new List<int>());

            Console.WriteLine(answer);
        }

        static void MakeTeam(int start, List<int> teamList)
        {
            if (teamList.Count == N / 2)
            {
                List<int> otherTeamList = new List<int>();
                for (int i = 0; i < N; i++)
                {
                    if (!teamList.Contains(i))
                    {
                        otherTeamList.Add(i);
                    }
                }

                int sum1 = 0, sum2 = 0;
                for (int i = 0; i < teamList.Count; i++)
                {
                    for (int j = 0; j < teamList.Count; j++)
                    {
                        if (teamList[i] == teamList[j])
                        {
                            continue;
                        }
                        sum1 += ability[teamList[i], teamList[j]];

                        if (otherTeamList[i] == otherTeamList[j])
                        {
                            continue;
                        }

                        sum2 += ability[otherTeamList[i], otherTeamList[j]];
                    }
                }

                answer = Math.Min(answer, Math.Abs(sum1 - sum2));
                return;
            }

            for (int i = start; i < N; i++)
            {
                if (!teamList.Contains(i))
                {
                    teamList.Add(i);
                    MakeTeam(i + 1, teamList);
                    teamList.RemoveAt(teamList.Count - 1);
                }
            }
        }
    }
}
