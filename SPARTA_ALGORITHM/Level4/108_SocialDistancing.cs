using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class SocialDistancing
    {
        public class Solution
        {
            const int EMPTY = 0;
            const int PERSON = 1;
            const int PARTITION = 2;
            const int ROOM_SIZE = 5;

            static int[] dx = { -1, 1, 0, 0};
            static int[] dy = { 0, 0, -1, 1};
            static int[,] room;
            static bool[,] visited;
            static List<string> possibleList 
                = new List<string> { "100", "122", "102", "120", "121" };
            static List<int[]> personList;
            static bool isPossible = true;

            public int[] solution(string[,] places)
            {
                int[] answer = new int[ROOM_SIZE];

                for (int i = 0; i < ROOM_SIZE; i++)
                {
                    room = new int[ROOM_SIZE, ROOM_SIZE];
                    personList = new List<int[]>();
                    for (int j = 0; j < ROOM_SIZE; j++)
                    {
                        string str = places[i, j];
                        for (int k = 0; k < str.Length; k++)
                        {
                            if (str[k] == 'O') room[j, k] = EMPTY;
                            else if (str[k] == 'P')
                            {
                                room[j, k] = PERSON;
                                personList.Add(new int[] { j, k });
                            }
                            else room[j, k] = PARTITION;
                        }
                    }

                    for (int j = 0; j < personList.Count; j++)
                    {
                        int x = personList[j][0];
                        int y = personList[j][1];
                        string str = $"{room[x, y]}";
                        visited = new bool[ROOM_SIZE, ROOM_SIZE];
                        visited[x, y] = true;
                        dfs(x, y, str, 0);
                    }

                    answer[i] = (isPossible) ? 1 : 0;
                    isPossible = true;
                }

                return answer;
            }

            static void dfs(int x, int y, string s, int distance)
            {
                if (!isPossible) return;
                if (distance == 2)
                {
                    if (!possibleList.Contains(s)) isPossible = false;
                    return;
                }

                int curX = x;
                int curY = y;
                for (int i = 0; i < 4; i++)
                {
                    int nextX = curX + dx[i];
                    int nextY = curY + dy[i];
                    if (nextX < 0 || nextY < 0
                        || nextX >= ROOM_SIZE || nextY >= ROOM_SIZE
                        || visited[nextX, nextY]) continue;

                    dfs(nextX, nextY, $"{s}{room[nextX, nextY]}", distance + 1);
                }
            }
        }
    }
}
