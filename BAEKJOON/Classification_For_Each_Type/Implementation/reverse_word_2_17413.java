package baekjoon.implementation;

// 백준 - 단어 뒤집기 2 17413
// https://www.acmicpc.net/problem/17413

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class reverse_word_2_17413 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        String S = br.readLine();

        StringBuilder result = new StringBuilder();
        StringBuilder reverse = new StringBuilder();
        boolean isReversed = true;

        for (int i = 0; i < S.length(); i++) {
            String cur = S.charAt(i) + "";
            if (cur.equals("<")) {  // 현재 문자가 < 일 때
                if (reverse.length() >= 1) {    // < 이전에 단어가 있었다면
                    result.append(reverse.reverse());
                    reverse.setLength(0);
                }
                isReversed = false;
                result.append(cur);
            } else if (cur.equals(">")) {   // 현재 문자가 > 일 때
                isReversed = true;
                result.append(cur);
            } else if (isReversed) {    // 현재 문자가 단어일 때
                if (cur.equals(" ")) {  // 현재 문자가 공백이라면
                    result.append(reverse.reverse()).append(cur);
                    reverse.setLength(0);
                } else if (i == S.length() - 1) {   // 현재 문자가 마지막 문자라면
                    reverse.append(cur);
                    result.append(reverse.reverse());
                }
                else reverse.append(cur);   
            } else {    // 현재 문자가 < 와 > 사이에 있을 때
                result.append(cur);
            }
        }

        System.out.println(result);
    }
}
