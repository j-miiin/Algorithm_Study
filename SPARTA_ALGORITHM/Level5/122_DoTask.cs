using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class DoTask
    {
        public class Solution
        {
            class Task
            {
                public string Name;
                public int StartTime;
                public int PlayTime;

                public Task(string name, int startTime, int playTime)
                {
                    Name = name;
                    StartTime = startTime;
                    PlayTime = playTime;
                }
            }

            public string[] solution(string[,] plans)
            {
                string[] answer = new string[plans.GetLength(0)];
                List<Task> taskList = new List<Task>();
                Stack<Task> taskStack = new Stack<Task>();
                int[] totalPlayTime = new int[1440];

                for (int i = 0; i < plans.GetLength(0); i++)
                {
                    string[] time = plans[i, 1].Split(":");
                    int hour = int.Parse(time[0]);
                    int minute = int.Parse(time[1]);

                    taskList.Add(new Task(plans[i, 0], hour * 60 + minute, int.Parse(plans[i, 2])));
                }

                taskList.Sort((Task t1, Task t2) =>
                {
                    if (t1.StartTime < t2.StartTime) return -1;
                    else if (t1.StartTime > t2.StartTime) return 1;
                    else return 0;
                });

                Array.Fill(totalPlayTime, -1);
                for (int i = 0; i < taskList.Count; i++)
                {
                    totalPlayTime[taskList[i].StartTime] = i;
                }

                int completeIdx = 0;
                int taskIdx = 0;
                for (int i = taskList[0].StartTime; i < totalPlayTime.Length; i++)
                {
                    if (totalPlayTime[i] == -1 && i < taskList[taskIdx].StartTime)
                    {
                        Task t = taskStack.Pop();
                        t.PlayTime--;
                        if (t.PlayTime > 0) taskStack.Push(t);
                        else answer[completeIdx++] = t.Name;
                    } else
                    {
                        if (totalPlayTime[i] != -1)
                        {
                            taskStack.Push(taskList[taskIdx]);
                            taskIdx++;
                        }
                        taskList[taskIdx].PlayTime--;
                        if (taskList[taskIdx].PlayTime == 0)
                        {
                            answer[completeIdx++] = taskList[taskIdx].Name;
                            taskIdx++;
                        }
                    }
                }

                while (taskStack.Count > 0)
                {
                    answer[completeIdx++] = taskStack.Pop().Name;
                }

                return answer;
            }
        }
    }
}
