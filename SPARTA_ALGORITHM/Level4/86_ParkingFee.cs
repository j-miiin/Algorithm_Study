using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class ParkingFee
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Solution.solution(new int[] { 180, 5000, 10, 600 }, new string[] { "05:34 5961 IN", "06:00 0000 IN", "06:34 0000 OUT", "07:59 5961 OUT", 
                "07:59 0148 IN", "18:59 0000 IN", "19:09 0148 OUT", "22:59 5961 IN", "23:00 5961 OUT" })));
        }
        public class Solution
        {
            public static int[] solution(int[] fees, string[] records)
            {

                Dictionary<string, string> recordsDic = new Dictionary<string, string>();
                Dictionary<string, int> totalTimeDic = new Dictionary<string, int>();

                for (int i = 0; i < records.Length; i++)
                {
                    string[] tmp = records[i].Split(" ");
                    string time = tmp[0];
                    string carNum = tmp[1];

                    if (tmp[2] == "IN")
                    {
                        recordsDic.Add(carNum, time);
                    } else
                    {
                        int curTime = GetTime(recordsDic[carNum], time);
                        if (totalTimeDic.ContainsKey(carNum)) totalTimeDic[carNum] += curTime;
                        else totalTimeDic.Add(carNum, curTime);
                        recordsDic.Remove(carNum);
                    }
                }

                foreach (KeyValuePair<string, string> entry in recordsDic)
                {
                    int curTime = GetTime(recordsDic[entry.Key], "23:59");
                    if (totalTimeDic.ContainsKey(entry.Key)) totalTimeDic[entry.Key] += curTime;
                    else totalTimeDic.Add(entry.Key, curTime);
                }

                int[] answer = totalTimeDic.Values.ToArray();
                totalTimeDic = totalTimeDic.OrderBy(e => e.Key).ToDictionary(x => x.Key, x => x.Value);
                int idx = 0;
                foreach(KeyValuePair<string, int> entry in totalTimeDic)
                {
                    answer[idx] = GetParkingFee(fees, entry.Value);
                    idx++;
                }

                return answer;
            }

            static int GetTime(string inTime, string outTime)
            {
                string[] tmp1 = inTime.Split(":");
                int inHour = int.Parse(tmp1[0]);
                int inMinute = int.Parse(tmp1[1]);

                string[] tmp2 = outTime.Split(":");
                int outHour = int.Parse(tmp2[0]);
                int outMinute = int.Parse(tmp2[1]);

                if (outMinute < inMinute)
                {
                    outHour--;
                    outMinute += 60;
                }

                return (outHour - inHour) * 60 + (outMinute - inMinute);
            }

            static int GetParkingFee(int[] fees, int totalTime)
            {
                int baseTime = fees[0];
                int baseFee = fees[1];
                int unitTime = fees[2];
                int unitFee = fees[3];

                int totalFee = 0;
                if (totalTime <= baseTime)
                {
                    totalFee = baseFee;
                } else
                {
                    int additionalTime = totalTime - baseTime;
                    totalFee += baseFee;
                    totalFee += (int)(Math.Ceiling((double)additionalTime / unitTime)) * unitFee;
                }

                return totalFee;
            }
        }
    }
}
