
// 백준 - 다리 놓기 1010
// https://www.acmicpc.net/problem/1010

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class build_bridge_1010 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int T = Integer.parseInt(br.readLine());

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < T; i++) {
            StringTokenizer st = new StringTokenizer(br.readLine());
            int N = Integer.parseInt(st.nextToken());
            int M = Integer.parseInt(st.nextToken());

            int[][] comb = new int[M+1][M+1];

            for (int j = 0; j < comb.length; j++) {
                for (int k = 0; k <= j; k++) {
                    if (j == k || k == 0) comb[j][k] = 1;
                    else comb[j][k] = comb[j-1][k-1] + comb[j-1][k];
                }
            }

            sb.append(comb[M][N]).append("\n");
        }
        System.out.println(sb);
    }
}
