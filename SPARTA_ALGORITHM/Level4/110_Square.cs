namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class Square
    {
        public class Solution
        {
            public long solution(int w, int h)
            {
                long answer = 0;
                for (long i = 1; i < w; i++)
                {
                    answer += (long)(-((double)h / w * i) + h);
                }
                return answer * 2;
            }
        }
    }
}
