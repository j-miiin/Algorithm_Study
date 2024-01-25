using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class VowelDictionary
    {
        public class Solution
        {
            public int solution(string word)
            {
                char[] words = new char[] { 'A', 'E', 'I', 'O', 'U' };
                List<string> wordList = new List<string>();
                for (int i = 1; i < words.Length + 1; i++)
                {
                    MakeWord(words, 0, i,"", wordList);
                }

                wordList.Sort();
                int answer = wordList.FindIndex(w => w == word) + 1;
                return answer;
            }

            static void MakeWord(char[] words, int length, int depth, string curStr, List<string> wordList)
            {
                if (length == depth)
                {
                    wordList.Add(curStr);
                    return;
                }

                for (int i = 0; i < words.Length; i++)
                {
                    MakeWord(words, length + 1, depth, curStr + words[i], wordList);
                }
            }
        }
    }
}
