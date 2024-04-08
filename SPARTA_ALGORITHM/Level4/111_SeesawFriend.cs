using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class SeesawFriend
    {
        public class Solution
        {
            public long solution(int[] weights)
            {
                long answer = 0;
                Dictionary<double, long> persons = new Dictionary<double, long>();

                for (int i = 0; i < weights.Length; i++)
                {
                    double w = weights[i];
                    if (!persons.ContainsKey(w)) persons.Add(w, 0);
                    if (!persons.ContainsKey(2 * w)) persons.Add(2 * w, 0);
                    if (!persons.ContainsKey(w / 2)) persons.Add(w / 2, 0);
                    if (!persons.ContainsKey((2 * w) / 3)) persons.Add((2 * w) / 3, 0);
                    if (!persons.ContainsKey((3 * w) / 2)) persons.Add((3 * w) / 2, 0);
                    if (!persons.ContainsKey((3 * w) / 4)) persons.Add((3 * w) / 4, 0);
                    if (!persons.ContainsKey((4 * w) / 3)) persons.Add((4 * w) / 3, 0);

                    answer += persons[w] + persons[2 * w] + persons[w / 2]
                        + persons[(2 * w) / 3] + persons[(3 * w) / 2]
                        + persons[(3 * w) / 4] + persons[(4 * w) / 3];
                    persons[w] += 1;
                }

                return answer;
            }
        }
    }
}
