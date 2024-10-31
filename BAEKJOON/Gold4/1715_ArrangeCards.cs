using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class ArrangeCards
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<long> heap = new List<long>();

            for (int i = 0; i < N; i++)
            {
                long num = long.Parse(Console.ReadLine());
                AddHeap(num, heap);
            }

            long answer = 0;
            while (heap.Count > 1)
            {
                long min1 = RemoveHeap(heap);
                long min2 = RemoveHeap(heap);

                answer += min1 + min2;
                AddHeap(min1 + min2, heap);
            }

            Console.WriteLine(answer);
        }

        static void AddHeap(long num, List<long> heap)
        {
            heap.Add(num);

            int child = heap.Count - 1;
            while (child > 0)
            {
                int parent = (child - 1) / 2;

                if (heap[child] < heap[parent])
                {
                    Swap(child, parent, heap);
                    child = parent;
                } else
                {
                    break;
                }
            }
        }

        static long RemoveHeap(List<long> heap)
        {
            if (heap.Count == 0)
            {
                return 0;
            }

            long data = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            int maxIdx = heap.Count - 1;
            int parent = 0;

            while (parent <= maxIdx)
            {
                int child = 2 * parent + 1;

                if (child > maxIdx)
                {
                    break;
                }

                if (child + 1 <= maxIdx && heap[child] > heap[child + 1])
                {
                    child++;
                }

                if (heap[child] < heap[parent])
                {
                    Swap(child, parent, heap);
                    parent = child;
                } else
                {
                    break;
                }
            }

            return data;
        }

        static void Swap(int x, int y, List<long> heap)
        {
            long tmp = heap[x];
            heap[x] = heap[y];
            heap[y] = tmp;
        }
    }
}
