using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class LCMs
    {
        public class Solution
        {
            public int solution(int[] arr)
            {
                Stack<int> stack = new Stack<int>();
                foreach (int i in arr) stack.Push(i);

                while (stack.Count > 1)
                {
                    int n1 = stack.Pop();
                    int n2 = stack.Pop();

                    int newLcm = lcm(n1, n2);
                    stack.Push(newLcm);
                }

                int answer = stack.Pop();
                return answer;
            }

            static int gcd(int n, int m)
            {
                if (m == 0) return n;
                else return gcd(m, n % m);
            }

            static int lcm(int n, int m)
            {
                return (n * m) / gcd(n, m);
            }
        }
    }
}