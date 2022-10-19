
// 백준 - 분해합 2231
// https://www.acmicpc.net/problem/2231

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class disassemble_sum_2231 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        long N = Long.parseLong(br.readLine());

        long result = 0;
        for (long i = 1; i <= N; i++) {
            long sum = i;
            String s = i + "";
            for (int j = 0; j < s.length(); j++) {
                char c = s.charAt(j);
                sum += Long.parseLong(c+"");
            }
            if (sum == N) {
                result = i;
                break;
            }
        }
        System.out.println(result);
    }
}
