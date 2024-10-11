using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon
{
    internal class MeetingRoom
    {
        struct Meeting
        {
            public int startTime;
            public int endTime;
            public Meeting(int startTime, int endTime)
            {
                this.startTime = startTime;
                this.endTime = endTime;
            }
        }

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Meeting[] meetings = new Meeting[N];

            for (int i = 0; i < N; i++)
            {
                string[] str = Console.ReadLine().Split(" ");
                int startTime = int.Parse(str[0]);
                int endTime = int.Parse(str[1]);
                meetings[i] = new Meeting(startTime, endTime);
            }

            Array.Sort(meetings, (Meeting m1, Meeting m2) =>
            {
                if (m1.endTime == m2.endTime)
                {
                    if (m1.startTime < m2.startTime) return -1;
                    else if (m1.startTime == m2.startTime) return 0;
                    else return 1;
                }
                else if (m1.endTime > m2.endTime) return 1;
                else return -1;
            });

            int answer = 0;
            int curEndTime = 0;
            for (int i = 0; i < meetings.Length; i++)
            {
                if (i != 0 && curEndTime > meetings[i].startTime) continue;
                curEndTime = meetings[i].endTime;
                answer++;
            }

            Console.WriteLine(answer);
        }
    }
}
