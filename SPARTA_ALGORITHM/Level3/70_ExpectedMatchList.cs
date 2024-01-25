using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class ExpectedMatchList
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(16, 9, 12));
        }

        class Solution
        {
            public static int solution(int n, int a, int b)
            {
                int p1 = a, p2 = b;
                int mid = n;
                while (mid > 1)
                {
                    mid /= 2;
                    if ((p1 <= mid && p2 > mid) || (p1 > mid && p2 <= mid))
                    {
                        mid *= 2;
                        break;
                    }
                    else if (p1 > mid && p2 > mid)
                    {
                        p1 -= mid;
                        p2 -= mid;
                    }
                    Console.WriteLine(mid + ", " + p1 + ", " + p2);
                }

                int answer = GetMinExponent2(mid);
                return (answer == 0) ? 1 : answer;
            }

            static int GetMinExponent2(int num)
            {
                int cur = 1;
                int count = 0;
                while (cur < num)
                {
                    cur *= 2;
                    count++;
                }
                return count;
            }
        }
    }
}
