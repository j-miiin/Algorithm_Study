using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class ReverseOrderNum
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(118372));
        }

        public class Solution
        {
            public static long solution(long n)
            {
                long answer = 0;
                char[] charArr = n.ToString().ToCharArray();
                int[] numArr = new int[charArr.Length];
                for (int i = 0; i < numArr.Length; i++) numArr[i] = int.Parse(charArr[i]+"");
                Array.Sort(numArr);
                Array.Reverse(numArr);
                string result = "";
                foreach (int i in numArr) result += i;
                answer = long.Parse(result);
                return answer;
            }
        }
    }
}
