using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class LectureRoomAssignment
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<int[]> lectures = new List<int[]>();
            for (int i = 0; i < N; i++)
            {
                string[] str = Console.ReadLine().Split(" ");
                int start = int.Parse(str[0]);
                int end = int.Parse(str[1]);
                lectures.Add(new int[] { start, end });
            }

            lectures.Sort((l1, l2) =>
            {
                if (l1[0] == l2[0])
                {
                    return l1[1] - l2[1];

                }
                return l1[0] - l2[0];
            });

            PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
            queue.Enqueue(lectures[0][1], lectures[0][1]);

            for (int i = 1; i < lectures.Count; i++)
            {
                if (lectures[i][0] >= queue.Peek())
                {
                    queue.Dequeue();
                }

                queue.Enqueue(lectures[i][1], lectures[i][1]);
            }

            Console.WriteLine(queue.Count);
        }
    }
}
