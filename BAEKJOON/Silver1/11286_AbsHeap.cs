using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class AbsHeap
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<int> heap = new List<int>();
            StringBuilder sb = new StringBuilder();
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

            int child = heap.Count - 1;
            while (child > 0)
            {
                int parent = (child - 1) / 2;

                if (Math.Abs(heap[child]) > Math.Abs(heap[parent]))
                {
                    break;
                }

                if (Math.Abs(heap[child]) == Math.Abs(heap[parent])
                    && heap[child] >= heap[parent])
                {
                    break;
                }

                Swap(child, parent, heap);
                child = parent;
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

            int parent = 0;
            int maxIdx = heap.Count - 1;

            while (parent <= maxIdx)
            {
                int child = 2 * parent + 1;

                if (child > maxIdx)
                {
                    break;
                }

                if (child + 1 <= maxIdx && Math.Abs(heap[child]) > Math.Abs(heap[child + 1]))
                {
                    child++;
                } else if (child + 1 <= maxIdx && Math.Abs(heap[child]) == Math.Abs(heap[child + 1])
                    && heap[child] > heap[child + 1])
                {
                    child++;
                }

                if (Math.Abs(heap[child]) > Math.Abs(heap[parent]))
                {
                    break;
                }

                if (Math.Abs(heap[child]) == Math.Abs(heap[parent])
                    && heap[child] >= heap[parent])
                {
                    break;
                }

                Swap(child, parent, heap);
                parent = child;
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
