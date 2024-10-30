using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class MaxHeap
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            List<int> heap = new List<int>();
            for (int i = 0; i < N; i++)
            {
                int cur = int.Parse(Console.ReadLine());

                if (cur == 0)
                {
                    sb.Append(RemoveHeap(heap)).Append("\n");
                } else
                {
                    AddHeap(cur, heap);
                }
            }

            Console.WriteLine(sb.ToString());
        }

        static void AddHeap(int num, List<int> heap)
        {
            heap.Add(num);

            int idx = heap.Count - 1;

            while (idx > 0)
            {
                int child = idx;
                int parent = (child - 1) / 2;

                if (heap[child] > heap[parent])
                {
                    Swap(child, parent, heap);
                    idx = parent;
                } else
                {
                    break;
                }
            }
        }

        static int RemoveHeap(List<int> heap)
        {
            if (heap.Count == 0)
            {
                return 0;
            }

            int data = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            int maxIdx = heap.Count - 1;
            int parent = 0;
            while (parent <= maxIdx)
            {
                int child = parent * 2 + 1;

                if (child > maxIdx)
                {
                    break;
                }

                if (child + 1 <= maxIdx && heap[child] < heap[child + 1])
                {
                    child++;
                }

                if (heap[child] > heap[parent])
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

        static void Swap(int x, int y, List<int> heap)
        {
            int tmp = heap[x];
            heap[x] = heap[y];
            heap[y] = tmp;
        }
    }
}
