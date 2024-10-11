using System;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class ArcheryContest
    {
        public class Solution
        {
            static int scoreDiff = 0;
            static int[] ryan;
            static int[] result;

            public int[] solution(int n, int[] info)
            {
                ryan = new int[11];
                result = new int[11];

                CalculateScore(n, 0, 0, info);

                return (scoreDiff > 0) ? result : new int[1] { -1 };
            }

            public static void CalculateScore(int n, int shootCount, int start, int[] apeach)
            {
                if (shootCount == n)
                {
                    int newScoreDiff = GetScoreDiff(apeach);
                    if (newScoreDiff > 0 && scoreDiff <= newScoreDiff)
                    {
                        if (scoreDiff < newScoreDiff)
                        {
                            scoreDiff = newScoreDiff;
                            Array.Copy(ryan, result, ryan.Length);
                        } else
                        {
                            for (int i = 10; i >= 0; i--)
                            {
                                if (result[i] < ryan[i])
                                {
                                    Array.Copy(ryan, result, ryan.Length);
                                    break;
                                } else if (result[i] > ryan[i])
                                {
                                    break;
                                }
                            }
                        }
                    }
                    return;
                }

                for (int i = start; i < 11; i++)
                {
                    ryan[i]++;
                    CalculateScore(n, shootCount + 1, i, apeach);
                    ryan[i]--;
                }
            }

            public static int GetScoreDiff(int[] apeach)
            {
                int apeachScore = 0, ryanScore = 0;

                for (int i = 0; i < apeach.Length; i++)
                {
                    if (ryan[i] > apeach[i])
                    {
                        ryanScore += 10 - i;
                    } else if (apeach[i] != 0)
                    {
                        apeachScore += 10 - i;
                    }
                }

                return ryanScore - apeachScore;
            }
        }
    }
}
