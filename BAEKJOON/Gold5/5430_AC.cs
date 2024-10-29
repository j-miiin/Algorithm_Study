using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class AC
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < T; i++)
            {
                string p = Console.ReadLine();
                int n = int.Parse(Console.ReadLine());
                string arrayStr = Console.ReadLine();

                List<int> nums = new List<int>();
                
                if (arrayStr.Length > 2)
                {
                    string[] arraySplit = arrayStr.Substring(1, arrayStr.Length - 2).Split(",");
                    for (int j = 0; j < arraySplit.Length; j++)
                    {
                        nums.Add(int.Parse(arraySplit[j]));
                    }
                }

                bool isFront = true;
                bool isError = false;
                for (int j = 0; j < p.Length; j++)
                {
                    if (p[j] == 'R')
                    {
                        isFront = !isFront; 
                    } else
                    {
                        if (nums.Count == 0)
                        {
                            isError = true;
                            break;
                        }

                        if (isFront)
                        {
                            nums.RemoveAt(0);
                        } else
                        {
                            nums.RemoveAt(nums.Count - 1);
                        }
                    }
                }

                if (isError)
                {
                    sb.Append("error").Append("\n");
                }
                else
                {
                    sb.Append("[");
                    if (isFront)
                    {
                        for (int j = 0; j < nums.Count; j++)
                        {
                            sb.Append(nums[j]);
                            if (j !=  nums.Count - 1)
                            {
                                sb.Append(",");
                            } 
                        }
                    } else
                    {
                        for (int j = nums.Count - 1; j >= 0; j--)
                        {
                            sb.Append(nums[j]);
                            if (j != 0)
                            {
                                sb.Append(",");
                            }
                        }
                    }
                    sb.Append("]").Append("\n");
                }
            }

            Console.Write(sb.ToString());
        }
    }
}
