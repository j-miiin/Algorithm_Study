
// 백준 - 그룹 단어 체커 1316
// https://www.acmicpc.net/problem/1316

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;

public class group_word_checker_1316 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());

        int result = 0;
        for (int i = 0; i < N; i++) {
            String s = br.readLine();
            String str = s.charAt(0)+"";
            for (int j = 1; j < s.length(); j++) {
                if (s.charAt(j-1) == s.charAt(j)) continue;
                else str += s.charAt(j);
            }
            int count = 1;
            HashMap<String, Boolean> wordList = new HashMap<>();
            for (int j = 0; j < str.length(); j++) {
                String cur = str.charAt(j)+"";
                if (wordList.getOrDefault(cur, false)) {
                    count = 0;
                    break;
                } else wordList.put(cur, true);
            }
            result += count;
        }
        System.out.println(result);
    }
}
