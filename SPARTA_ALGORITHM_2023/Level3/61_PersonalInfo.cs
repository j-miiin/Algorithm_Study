using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class PersonalInfo
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Solution.solution("2016.02.15", new string[] { "A 100" }, new string[] { "2000.06.16 A", "2008.02.15 A" })));
        }
        public class Solution
        {
            static int year, month, day;
            public static int[] solution(string today, string[] terms, string[] privacies)
            {
                List<int> result = new List<int>();

                string[] todayDate = today.Split('.');
                year = int.Parse(todayDate[0]);
                month = int.Parse(todayDate[1]);
                day = int.Parse(todayDate[2]);

                Dictionary<string, int> termDic = new Dictionary<string, int>();

                foreach (string term in terms)
                {
                    string[] termStr = term.Split(' ');
                    termDic.Add(termStr[0], int.Parse(termStr[1]));
                }

                for (int i = 0; i < privacies.Length; i++)
                {
                    string[] privaciesStr = privacies[i].Split(' ');
                    if (isExpired(privaciesStr[0], termDic.GetValueOrDefault(privaciesStr[1])))
                    {
                        result.Add(i + 1);
                    }
                }

                int[] answer = result.ToArray();
                return answer;
            }

            static bool isExpired(string date, int term)
            {
                string[] dateStr = date.Split('.');
                int y = int.Parse(dateStr[0]);
                int m = int.Parse(dateStr[1]);
                int d = int.Parse(dateStr[2]);

                m += term;
                while (m > 12)
                {
                    m -= 12;
                    y++;
                }

                d--;
                if (d < 1)
                {
                    m--;
                    d = 28;
                }
                Console.WriteLine(y + ", " + m + ", " + d);

                if (y < year) return true;
                else if (y == year && m < month) return true;
                else if (y == year && m == month && d < day) return true;

                return false;
            }
        }
    }
}
