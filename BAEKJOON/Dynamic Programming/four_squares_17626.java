package baekjoon.dynamic_programming;

// 백준 - Four Squares 17626
// https://www.acmicpc.net/problem/17626

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class four_squares_17626 {

    public static int n;
    public static int[] dp;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        n = Integer.parseInt(br.readLine());
        dp = new int[n+1];
        dp[0] = 0;
        dp[1] = 1;
        System.out.println(count_squares());
    }

    public static int count_squares() {

        for (int i = 2; i <= n; i++) {
            int min = Integer.MAX_VALUE;

            for (int j = 1; j*j <= i; j++) {
                min = Math.min(min, dp[i-j*j]);
            }

            dp[i] = min + 1;
        }

        return dp[n];
    }
}
