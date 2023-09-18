using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class RotateParenthesis
    {
        public class Solution
        {
            public int solution(string s)
            {
                int answer = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    string newStr = s.Substring(i, s.Length - i) + s.Substring(0, i);
                    if (IsCorrectParenthesis(newStr)) answer++;
                }
                
                return answer;
            }

            static bool IsCorrectParenthesis(string s)
            {
                Stack<char> stack = new Stack<char>();
                
                for (int i = 0; i < s.Length; i++)
                {
                    char cur = s[i];
                    if (cur == '[' || cur == '(' || cur == '{') stack.Push(cur);
                    else
                    {
                        if (cur == ']')
                        {
                            char popChar = ']';
                            while (stack.Count > 0)
                            {
                                popChar = stack.Pop();
                                if (popChar == '[') break;
                            }
                            if (popChar != '[') {
                                return false;
                            }
                        }
                        else if (cur == ')')
                        {
                            char popChar = ')';
                            while (stack.Count > 0)
                            {
                                popChar = stack.Pop();
                                if (popChar == '(') break;
                            }
                            if (popChar != '(')
                            {
                                return false;
                            }
                        }
                        else
                        {
                            char popChar = '}';
                            while (stack.Count > 0)
                            {
                                popChar = stack.Pop();
                                if (popChar == '{') break;
                            }
                            if (popChar != '{')
                            {
                                return false;
                            }
                        }
                    }
                }

                return (stack.Count == 0) ? true : false;
            }
        }
    }
}
