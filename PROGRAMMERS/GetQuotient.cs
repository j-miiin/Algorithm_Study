namespace Algorithm_Study.Programmers
{
    internal class GetQuotient
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(7, 2));
        }

        static class Solution
        {
            public static int solution(int num1, int num2)
            {
                return (int)(num1 / num2);
            }
        }
    }
}