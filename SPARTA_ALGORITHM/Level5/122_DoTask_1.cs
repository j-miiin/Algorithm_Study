using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class DoTask_1
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

                int completeIdx = 0;
                Task curTask, nextTask;
                for (int i = 0; i < taskList.Count - 1; i++)
                {
                    curTask = taskList[i];
                    nextTask = taskList[i + 1];

                    int time = curTask.StartTime + curTask.PlayTime - nextTask.StartTime;
                    if (time > 0)
                    {
                        curTask.PlayTime = time;
                        taskStack.Push(curTask);
                    } else if (time == 0)
                    {
                        answer[completeIdx++] = curTask.Name;
                    } else
                    {
                        answer[completeIdx++] = curTask.Name;
                        while (taskStack.Count > 0)
                        {
                            Task lastTask = taskStack.Pop();
                            if (time + lastTask.PlayTime == 0)
                            {
                                answer[completeIdx++] = lastTask.Name;
                                break;
                            } else if (time + lastTask.PlayTime > 0)
                            {
                                lastTask.PlayTime += time;
                                taskStack.Push(lastTask);
                                break;
                            } else
                            {
                                time += lastTask.PlayTime;
                                answer[completeIdx++] = lastTask.Name;
                            }
                        }
                    }
                }

                answer[completeIdx++] = taskList[taskList.Count - 1].Name;
                while (taskStack.Count > 0)
                {
                    answer[completeIdx++] = taskStack.Pop().Name;
                }

                return answer;
            }
        }
    }
}
