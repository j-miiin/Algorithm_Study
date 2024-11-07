using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon
{
    internal class JavaVsCpp
    {
        public const string ERROR = "Error!";

        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            Regex regex = new Regex(@"_{2,}");
            if (s[0] == '_' || s[s.Length - 1] == '_'
                || regex.IsMatch(s))
            {
                Console.WriteLine(ERROR);
                return;
            }

            string[] str = s.Split("_");

            if (str.Length == 1)
            {
                if ((s[0] >= 'A' && s[0] <= 'Z'))
                {
                    Console.WriteLine(ERROR);
                    return;
                }

                Console.WriteLine(JavaToCpp(s));
            } else if (str.Length > 1)
            {
                Console.WriteLine(CppToJava(str));
            }
        }

        static string CppToJava(string[] cppStr)
        {
            Regex regex = new Regex(@"[A-Z]+");
            if (regex.IsMatch(cppStr[0]))
            {
                return ERROR;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(cppStr[0]);

            for (int i = 1; i < cppStr.Length; i++)
            {
                if (regex.IsMatch(cppStr[i]))
                {
                    return ERROR;
                }

                sb.Append(cppStr[i][0].ToString().ToUpper())
                    .Append(cppStr[i].AsSpan(1));
            }

            return sb.ToString();
        }

        static string JavaToCpp(string javaStr)
        {
            StringBuilder sb = new StringBuilder();

            Regex regex = new Regex(@"[A-Z][a-z]*|[a-z]+");
            foreach (var match in regex.Matches(javaStr))
            {
                sb.Append(match.ToString().ToLower()).Append("_");
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}
