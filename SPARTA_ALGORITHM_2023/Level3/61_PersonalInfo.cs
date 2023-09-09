using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class PersonalInfo
    {
        public class Solution
        {
            static int year, month, day;
            public int[] solution(string today, string[] terms, string[] privacies)
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
                    if (!isExpired(privaciesStr[0], termDic.GetValueOrDefault(privaciesStr[1])))
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
                if (m > 12)
                {
                    m -= 12;
                    y++;
                }

                d--;
                if (d == 0)
                {
                    m--;
                    d = 28;
                }

                if (y > year) return false;
                else if (m > month) return false;
                else if (d > day) return false;

                return true;
            }
        }
    }
}
