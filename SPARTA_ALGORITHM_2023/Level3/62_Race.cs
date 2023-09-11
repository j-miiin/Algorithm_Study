using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class Race
    {
        public class Solution
        {
            public string[] solution(string[] players, string[] callings)
            {
                Dictionary<string, int> playerDic = new Dictionary<string, int>();
                for (int i = 0; i < players.Length; i++)
                {
                    playerDic.Add(players[i], i);
                }

                foreach (string name in callings)
                {
                    int idx = playerDic[name];

                    string prev = players[idx - 1];
                    players[idx - 1] = name;
                    players[idx] = prev;

                    playerDic[name] = idx - 1;
                    playerDic[prev] = idx;
                }
                string[] answer = players;
                return answer;
            }
        }
    }
}
