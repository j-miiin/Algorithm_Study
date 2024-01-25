using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class FindKim
    {
        public class Solution
        {
            public string solution(string[] seoul)
            {
                string answer = "김서방은 " + Array.IndexOf(seoul, "Kim") + "에 있다";
                return answer;
            }
        }
    }
}
