using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class DivideCard
    {
        public class Solution
        {
            public int solution(int[] arrayA, int[] arrayB)
            {
                int divisorA = GetDivisor(arrayA);
                int divisorB = GetDivisor(arrayB);

                bool isRight = true;
                int answer = 0;
                for (int i = 0; i < arrayB.Length; i++)
                {
                    if (arrayB[i] % divisorA == 0)
                    {
                        isRight = false;
                        break;
                    }
                }
                if (isRight) answer = Math.Max(answer, divisorA);

                isRight = true;
                for (int i = 0; i < arrayA.Length; i++)
                {
                    if (arrayA[i] % divisorB == 0)
                    {
                        isRight = false;
                        break;
                    }
                }
                if (isRight) answer = Math.Max(answer, divisorB);

                return answer;
            }

            static int GetDivisor(int[] array)
            {
                int idx = 1;
                int num = array[0];
                while (idx < array.Length)
                {
                    num = gcd(num, array[idx++]);
                }
                return num;
            }

            static int gcd(int a, int b)
            {
                if (b == 0) return a;
                else return gcd(b, a % b);
            }
        }
    }
}
