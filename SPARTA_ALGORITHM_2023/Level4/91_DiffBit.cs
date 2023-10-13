using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class DiffBit
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(new long[] { 2, 7 }));
        }

        public class Solution
        {
            public static long[] solution(long[] numbers)
            {
                long[] answer = new long[numbers.Length];

                for (int i = 0; i < answer.Length; i++)
                {
                    answer[i] = GetFx(numbers[i]);
                }

                return answer;
            }

            static long GetFx(long num)
            {
                if (num == 1) return 2;
                if (num % 2 == 0) return num + 1;

                string numToBinary = Convert.ToString(num, 2);
                char[] charArr = numToBinary.ToCharArray();
                for (int i = charArr.Length - 1; i >= 0; i--)
                {
                    char cur = charArr[i];
                    if (i > 0 && cur == '1' && charArr[i - 1] == '0')
                    {
                        charArr[i] = '0';
                        charArr[i - 1] = '1';
                        numToBinary = new string(charArr);
                        break;
                    }

                    if (i == 0 && cur == '1')
                    {
                        charArr[i] = '0';
                        numToBinary = '1' + new string(charArr);
                    }
                }
                Console.WriteLine(numToBinary);
                return Convert.ToInt64(numToBinary, 2);
            }
        }
    }
}
