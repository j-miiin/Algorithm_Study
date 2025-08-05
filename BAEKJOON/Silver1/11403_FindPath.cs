using System.Text;

namespace AlgorithmStudy.Baekjoon.Silver1
{
    class FindPath
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[,] graph = new int[N, N];

            int INF = 100_000_000;

            for (int i = 0; i < N; i++)
            {
                string[] s = Console.ReadLine().Split(" ");
                for (int j = 0; j < N; j++)
                {
                    int cost = int.Parse(s[j]);
                    graph[i, j] = (cost == 0) ? INF : cost;
                }
            }

            for (int k = 0; k < N; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        graph[i, j] = Math.Min(graph[i, j], graph[i, k] + graph[k, j]);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sb.Append((graph[i, j] >= INF) ? 0 : 1).Append(" ");
                }
                sb.Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
