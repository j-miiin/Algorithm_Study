using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class StrOrderByMe
    {
        public class Solution
        {
            public string[] solution(string[] strings, int n)
            {
                Array.Sort(strings);
                string[] answer = strings.OrderBy(x => x[n]).ToArray();

                return answer;
            }
        }
    }
}
