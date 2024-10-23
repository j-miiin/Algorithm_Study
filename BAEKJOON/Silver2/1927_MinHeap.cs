using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class MinHeap
    {
        static List<int> heap = new List<int>();

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                int cur = int.Parse((Console.ReadLine()));

                if (cur == 0)
                {
                    sb.Append(RemoveHeap()).Append("\n");
                } else
                {
                    AddHeap(cur);
                }
            }

            Console.WriteLine(sb.ToString());
        }

        static void AddHeap(int num)
        {
            heap.Add(num);

            int idx = heap.Count - 1;

            while (idx > 0)
            {
                int child = idx;
                int parent = (child - 1) / 2;

                if (heap[child] < heap[parent])
                {
                    Swap(parent, child);
                    idx = parent;
                } else
                {
                    break;
                }
            }
        }

        static int RemoveHeap()
        {
            if (heap.Count == 0)
            {
                return 0;
            }

            int data = heap[0];
            heap[0] = heap[heap.Count - 1]; 
            heap.RemoveAt(heap.Count - 1);

            int parent = 0;
            int idx = heap.Count - 1;

            while (parent <= idx)
            {
                int child = (parent * 2) + 1;

                if (child > idx)
                {
                    break;
                }

                if (child + 1 <= idx && heap[child] > heap[child + 1])
                {
                    child++;
                }

                if (heap[parent] > heap[child])
                {
                    Swap(parent, child);
                    parent = child;
                } else
                {
                    break;
                }
            }

            return data;
        }

        static void Swap(int x, int y)
        {
            int temp = heap[x];
            heap[x] = heap[y];
            heap[y] = temp;
        }
    }
}
