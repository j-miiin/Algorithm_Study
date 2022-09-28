
// 백준 - 거스름돈 14916
// https://www.acmicpc.net/problem/14916

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class min_change_14916 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int n = Integer.parseInt(br.readLine());

        int count = Integer.MAX_VALUE;
        for (int i = 0; i <= n/2; i++) {
            for (int j = 0; j <= n/5; j++) {
                int sum = i*2 + j*5;
                if (sum == n) {
                    count = Math.min(count, i+j);
                }
            }
        }

        System.out.println((count == Integer.MAX_VALUE) ? -1 : count);
    }
}
