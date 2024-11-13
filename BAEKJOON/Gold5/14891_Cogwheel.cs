using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class Cogwheel
    {
        static void Main(string[] args)
        {
            int[,] wheels = new int[4, 8];

            for (int i = 0; i < 4; i++)
            {
                string str = Console.ReadLine();
                for (int j = 0; j < 8; j++)
                {
                    wheels[i, j] = (str[j] == '0') ? 0 : 1;
                }
            }

            int K = int.Parse(Console.ReadLine());

            for (int i = 0; i < K; i++)
            {
                string[] str = Console.ReadLine().Split(" ");

                int wheelNum = int.Parse(str[0]) - 1;
                int dir = int.Parse(str[1]);

                CheckState(wheelNum, dir, wheels);
            }

            int score = 0;
            score += (wheels[0, 0] == 1) ? 1 : 0;
            score += (wheels[1, 0] == 1) ? 2 : 0;
            score += (wheels[2, 0] == 1) ? 4 : 0;
            score += (wheels[3, 0] == 1) ? 8 : 0;

            Console.WriteLine(score);
        }

        static void CheckState(int num, int dir, int[,] wheels)
        {
            int[] spin = new int[4];
            spin[num] = dir;

            switch (num)
            {
                case 0:
                    if (wheels[0, 2] != wheels[1, 6])
                    {
                        spin[1] = spin[0] * -1;
                    } else
                    {
                        break;
                    }

                    if (wheels[1, 2] != wheels[2, 6])
                    {
                        spin[2] = spin[1] * -1;
                    } else
                    {
                        break;
                    }

                    if (wheels[2, 2] != wheels[3, 6])
                    {
                        spin[3] = spin[2] * -1;
                    }
                    break;
                case 1:
                    if (wheels[1, 6] != wheels[0, 2])
                    {
                        spin[0] = spin[1] * -1;
                    }

                    if (wheels[1, 2] != wheels[2, 6])
                    {
                        spin[2] = spin[1] * -1;
                    } else
                    {
                        break;
                    }

                    if (wheels[2, 2] != wheels[3, 6])
                    {
                        spin[3] = spin[2] * -1;
                    }
                    break;
                case 2:
                    if (wheels[2, 2] != wheels[3, 6])
                    {
                        spin[3] = spin[2] * -1;
                    }

                    if (wheels[2, 6] != wheels[1, 2])
                    {
                        spin[1] = spin[2] * -1;
                    } else
                    {
                        break;
                    }

                    if (wheels[1, 6] != wheels[0, 2])
                    {
                        spin[0] = spin[1] * -1;
                    }
                    break;
                case 3:
                    if (wheels[3, 6] != wheels[2, 2])
                    {
                        spin[2] = spin[3] * -1;
                    } else
                    {
                        break;
                    }

                    if (wheels[2, 6] != wheels[1, 2])
                    {
                        spin[1] = spin[2] * -1;
                    } else
                    {
                        break;
                    }

                    if (wheels[1, 6] != wheels[0, 2])
                    {
                        spin[0] = spin[1] * -1;
                    }
                    break;
            }

            for (int i = 0; i < spin.Length; i++)
            {
                if (spin[i] != 0)
                {
                    Spin(i, spin[i], wheels);
                }
            }
        }

        static void Spin(int num, int dir, int[,] wheels)
        {
            if (dir == -1)
            {
                int tmp = wheels[num, 0];

                for (int i = 0; i < 7; i++)
                {
                    wheels[num, i] = wheels[num, i + 1];
                }

                wheels[num, 7] = tmp;
            } else
            {
                int tmp = wheels[num, 7];

                for (int i = 7; i >= 1; i--)
                {
                    wheels[num, i] = wheels[num, i - 1];
                }

                wheels[num, 0] = tmp;
            }
        }
    }
}
