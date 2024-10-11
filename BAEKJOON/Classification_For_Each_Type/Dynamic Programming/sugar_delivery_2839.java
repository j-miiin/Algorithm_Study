
// 백준 - 설탕 배달 2839
// https://www.acmicpc.net/problem/2839

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class sugar_delivery_2839 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());

        int result = Integer.MAX_VALUE;
        for (int i = 0; i <= N/3; i++) {
            for (int j = 0; j <= N/5; j++) {
                if (3*i + 5*j == N) result = Math.min(result, i+j);
            }
        }

        System.out.println((result != Integer.MAX_VALUE) ? result : -1);
    }
}
