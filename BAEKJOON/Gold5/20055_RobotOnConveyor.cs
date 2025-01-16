using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class RobotOnConveyor
    {
        static int N, K;
        static int[] conveyor;
        static bool[] isRobotPlaced;
        static List<int> robotPositions = new List<int>();

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = int.Parse(str[0]);
            K = int.Parse(str[1]);

            conveyor = new int[2 * N];
            isRobotPlaced = new bool[2 * N];

            str = Console.ReadLine().Split(" ");
            for (int i = 0; i < 2 * N; i++)
            {
                conveyor[i] = int.Parse(str[i]);
            }

            int stage = 1;
            while (true)
            {
                Rotate();

                if (IsFinished())
                {
                    break;
                }

                MoveRobots();

                if (IsFinished())
                {
                    break;
                }

                PlaceRobot();

                if (IsFinished())
                {
                    break;
                }

                stage++;
            }

            Console.WriteLine(stage);
        }

        static void Rotate()
        {
            int tmp = conveyor[2 * N - 1];
            for (int i = 2 * N - 1; i > 0; i--)
            {
                conveyor[i] = conveyor[i - 1];
            }

            conveyor[0] = tmp;

            int removeIdx = -1;
            for (int i = 0; i < robotPositions.Count; i++)
            {
                isRobotPlaced[robotPositions[i]] = false;
                robotPositions[i]++;

                if (robotPositions[i] == 2 * N)
                {
                    robotPositions[i] = 0;
                } else if (robotPositions[i] == N - 1)
                {
                    removeIdx = i;
                    continue;
                }

                isRobotPlaced[robotPositions[i]] = true;
            }

            if (removeIdx != -1)
            {
                robotPositions.RemoveAt(removeIdx);
            }
        }

        static void MoveRobots()
        {
            int removeIdx = -1;

            for (int i = 0; i < robotPositions.Count; i++)
            {
                int curPos = robotPositions[i];

                int nextPos = curPos + 1;
                if (nextPos == 2 * N)
                {
                    nextPos = 0;
                }

                if (isRobotPlaced[nextPos] || conveyor[nextPos] < 1)
                {
                    continue;
                } else 
                {
                    isRobotPlaced[curPos] = false;
                    isRobotPlaced[nextPos] = true;
                    conveyor[nextPos]--;
                    robotPositions[i] = nextPos;

                    if (nextPos == N - 1)
                    {
                        isRobotPlaced[nextPos] = false;
                        removeIdx = i;
                    }
                }
            }

            if (removeIdx != -1)
            {
                robotPositions.RemoveAt(removeIdx);
            }
        }

        static void PlaceRobot()
        {
            if (isRobotPlaced[0] || conveyor[0] == 0)
            {
                return;
            }

            isRobotPlaced[0] = true;
            conveyor[0]--;
            robotPositions.Add(0);
        }

        static bool IsFinished()
        {
            int count = 0;
            for (int i = 0; i < conveyor.Length; i++)
            {
                if (conveyor[i] == 0)
                {
                    count++;
                    if (count >= K)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
