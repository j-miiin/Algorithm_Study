using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class RollCake
    {
        public class Solution
        {
            public int solution(int[] topping)
            {
                int answer = 0;

                HashSet<int> firstTopping = new HashSet<int>();
                Dictionary<int, int> secondTopping = new Dictionary<int, int>();

                firstTopping.Add(topping[0]);
                for (int i = 1; i < topping.Length; i++)
                {
                    if (secondTopping.ContainsKey(topping[i])) secondTopping[topping[i]]++;
                    else secondTopping.Add(topping[i], 1);
                }

                if (firstTopping.Count == secondTopping.Count) answer++;

                for (int i = 1; i < topping.Length - 1; i++)
                {
                    int curTopping = topping[i];
                    firstTopping.Add(curTopping);
                    if ((secondTopping[curTopping] - 1) == 0) secondTopping.Remove(curTopping);
                    else secondTopping[curTopping]--;

                    if (firstTopping.Count == secondTopping.Count) answer++;
                }

                return answer;
            }
        }
    }
}
