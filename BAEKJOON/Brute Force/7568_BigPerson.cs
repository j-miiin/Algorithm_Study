using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon
{
    internal class BigPerson
    {
        class Person
        {
            public int weight;
            public int height;
            public int grade = 1;

            public Person(int w, int h)
            {
                weight = w;
                height = h;
            }
        }

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<Person> personList = new List<Person>(N);
            for (int i = 0; i < N; i++)
            {
                string[] info = Console.ReadLine().Split(" ");
                Person p = new Person(int.Parse(info[0]), int.Parse(info[1]));
                personList.Add(p);
            }

            for (int i = 0; i < N; i++)
            {
                Person p1 = personList[i];

                int grade = 0;
                for (int j = 0; j < N; j++)
                {
                    Person p2 = personList[j];

                    if (p1 == p2)
                    {
                        continue;
                    }

                    if (p1.weight < p2.weight && p1.height < p2.height)
                    {
                        grade++;
                    }
                }

                p1.grade = grade + 1;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < personList.Count; i++)
            {
                sb.Append(personList[i].grade).Append(" ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
