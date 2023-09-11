using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class ReportResult
    {
        public class Solution
        {
            public int[] solution(string[] id_list, string[] report, int k)
            {
                Dictionary<string, HashSet<string>> reportDic = new Dictionary<string, HashSet<string>>();
                foreach (string id in id_list)
                {
                    reportDic.Add(id, new HashSet<string>());
                }

                foreach (string r in report)
                {
                    string[] strArr = r.Split(' ');
                    string reporter = strArr[0];
                    string reported = strArr[1];

                    reportDic.GetValueOrDefault(reported).Add(reporter);
                }

                Dictionary<string, int> mailCnt = new Dictionary<string, int>();
                foreach (string id in id_list)
                {
                    mailCnt.Add(id, 0);
                }
                foreach (KeyValuePair<string, HashSet<string>> entry in reportDic) 
                {
                    HashSet<string> curReporters = reportDic.GetValueOrDefault(entry.Key);
                    if (curReporters.Count >= k)
                    {
                        foreach (string name in curReporters)
                        {
                            mailCnt[name] = mailCnt.GetValueOrDefault(name) + 1;
                        }
                    }
                }

                int[] answer = new int[id_list.Length];
                int idx = 0;
                foreach (KeyValuePair<string, int> entry in mailCnt)
                {
                    answer[idx++] = entry.Value;
                }

                return answer;
            }
        }
    }
}
