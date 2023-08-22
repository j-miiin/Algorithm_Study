

namespace Sparta_CS_Algorithm_Study_2023.Programmers
{
    internal class GetMode
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(new int[] {1, 2, 3, 3, 3, 4}));
        }

        public class Solution
        {
            public static int solution(int[] array)
            {
                int answer = 0;
                Dictionary<int, int> countNum = new Dictionary<int, int>();

                foreach (int i in array)
                {
                    int num = 0;
                    if (countNum.TryGetValue(i, out num))
                    {
                        countNum[i] += 1;
                    }
                    else countNum.Add(i, 1);
                }

                int count = 0;
                int max = -1;
                foreach(KeyValuePair<int, int> entry in countNum)
                {
                    if (entry.Value > max)
                    {
                        max = entry.Value;
                        answer = entry.Key;
                        count = 0;
                    }
                    else if (entry.Value == max) count++;  
                }

                return (count == 0) ? answer : -1;
            }
        }
    }
}
