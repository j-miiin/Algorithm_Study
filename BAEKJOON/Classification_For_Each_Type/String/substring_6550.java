
// 백준 - 부분 문자열 6550
// https://www.acmicpc.net/problem/6550

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class substring_6550 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringBuilder sb = new StringBuilder();
        String cur = "";
        while ((cur = br.readLine()) != null && !cur.isEmpty()) {
            StringTokenizer st = new StringTokenizer(cur);
            String s = st.nextToken();
            String t = st.nextToken();

            int sIdx = 0;
            int tIdx = 0;
            while (sIdx < s.length() && tIdx < t.length()) {

                if (s.charAt(sIdx) == t.charAt(tIdx)) {
                    sIdx++;
                    tIdx++;
                } else {
                    tIdx++;
                }
            }

            sb.append((sIdx == s.length()) ? "Yes" : "No").append("\n");
        }
        System.out.println(sb);
    }
}
