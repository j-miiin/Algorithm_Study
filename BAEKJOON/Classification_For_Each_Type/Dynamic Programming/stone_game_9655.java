
// 백준 - 돌 게임 9655
// https://www.acmicpc.net/problem/9655

package baekjoon.dynamic_programming;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class stone_game_9655 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());
        if (N == 1) {
            System.out.println("SK");
            return;
        }
        int[] dp = new int[N];

        dp[0] = 1;
        for (int i = 1; i < N; i++) {
            if (dp[i-1] + 3 > N) dp[i] = dp[i-1] + 1;
            else dp[i] = dp[i-1] + 3;

            if (dp[i] == N) {
                System.out.println((i % 2 == 0) ? "SK" : "CY");
                break;
            }
        }
    }
}
