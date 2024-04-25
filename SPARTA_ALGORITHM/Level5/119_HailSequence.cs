using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class HailSequence
    {
        public class Solution
        {
            public double[] solution(int k, int[,] ranges)
            {
                List<int> sequence = new List<int>();
                List<double> sequenceArea = new List<double>();

                int num = k;
                while (true)
                {
                    sequence.Add(num);
                    if (sequence.Count == 1) sequenceArea.Add(0);
                    else
                    {
                        int idx = sequence.Count - 1;
                        sequenceArea.Add(sequenceArea[idx - 1]);
                        sequenceArea[idx] += GetArea(sequence[idx], sequence[idx - 1]);
                    }

                    if (num == 1) break;
                    
                    if (num % 2 == 0) num /= 2;
                    else num = num * 3 + 1;
                }

                int n = sequence.Count - 1;

                double[] answer = new double[ranges.GetLength(0)];
                for (int i = 0; i < ranges.GetLength(0); i++)
                {
                    int a = ranges[i, 0];
                    int b = ranges[i, 1];

                    if (n + b < a || n + b < 0)
                    {
                        answer[i] = -1;
                        continue;
                    }

                    answer[i] = sequenceArea[n + b] - sequenceArea[a];
                }

                return answer;
            }

            static double GetArea(int height1, int height2)
            {
                double result = (double)Math.Abs(height1 - height2) / 2;
                result += Math.Min(height1, height2);
                return result;
            }
        }
    }
}
