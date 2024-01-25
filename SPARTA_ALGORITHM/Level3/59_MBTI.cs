using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class MBTI
    {
        public class Solution
        {
            static int R = 0, T = 0, C = 0, F = 0, J = 0, M = 0, A = 0, N = 0;
            public string solution(string[] survey, int[] choices)
            {
                string answer = "";
                

                for (int i = 0; i < choices.Length; i++)
                {
                    int score = 0;
                    if (choices[i] < 4)
                    {
                        score = 4 - choices[i] ;
                        SetScore(survey[i][0], score);
                    }
                    else
                    {
                        score = choices[i] - 4;
                        SetScore(survey[i][1], score);
                    }
                }

                if (R >= T) answer += 'R';
                else answer += 'T';
                if (C >= F) answer += 'C';
                else answer += 'F';
                if (J >= M) answer += 'J';
                else answer += 'M';
                if (A >= N) answer += 'A';
                else answer += 'N';
                return answer;
            }

            static void SetScore(char c, int score)
            {
                switch (c)
                {
                    case 'R':
                        R += score;
                        break;
                    case 'T':
                        T += score;
                        break;
                    case 'C':
                        C += score;
                        break;
                    case 'F':
                        F += score;
                        break;
                    case 'J':
                        J += score;
                        break;
                    case 'M':
                        M += score;
                        break;
                    case 'A':
                        A += score;
                        break;
                    case 'N':
                        N += score;
                        break;
                }
            }
        }
    }
}
