using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class AssignMeetingRoom
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<int[]> meetingList = new List<int[]>(N);
            string[] str;
            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                meetingList.Add(new int[] { int.Parse(str[0]), int.Parse(str[1]) });
            }

            meetingList.Sort((m1, m2) =>
            {
                if (m1[1] == m2[1])
                {
                    return m1[0] - m2[0];
                } else
                {
                    return m1[1] - m2[1];
                }
            });

            int meetingCount = 0;
            int curMeetingEndTime = 0;
            for (int i = 0; i < meetingList.Count; i++)
            {
                if (meetingList[i][0] >= curMeetingEndTime)
                {
                    curMeetingEndTime = meetingList[i][1];
                    meetingCount++;
                }
            }

            Console.WriteLine(meetingCount);
        }
    }
}
