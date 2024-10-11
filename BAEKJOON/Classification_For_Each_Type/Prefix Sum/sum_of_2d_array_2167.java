
// 백준 - 2차원 배열의 합 2167
// https://www.acmicpc.net/problem/2167

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class sum_of_2d_array_2167 {

    public static int N, M;
    public static int[][] arr;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());

        N = Integer.parseInt(st.nextToken());
        M = Integer.parseInt(st.nextToken());
        arr = new int[N+1][M+1];
        for (int i = 1; i <= N; i++) {
            st = new StringTokenizer(br.readLine());
            for (int j = 1; j <= M; j++) {
                arr[i][j] = Integer.parseInt(st.nextToken());
            }
        }

        getPrefixSum();

        int K = Integer.parseInt(br.readLine());
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < K; i++) {
            st = new StringTokenizer(br.readLine());
            int x1 = Integer.parseInt(st.nextToken());
            int y1 = Integer.parseInt(st.nextToken());
            int x2 = Integer.parseInt(st.nextToken());
            int y2 = Integer.parseInt(st.nextToken());

            sb.append(arr[x2][y2] - arr[x1-1][y2] - arr[x2][y1-1] + arr[x1-1][y1-1]).append("\n");
        }
        System.out.println(sb);
    }

    public static void getPrefixSum() {
        for (int i = 1; i <= N; i++) {
            for (int j = 0; j <= M; j++) {
                arr[i][j] += arr[i-1][j];
            }
        }

        for (int i = 0; i <= N; i++) {
            for (int j = 1; j <= M; j++) {
                arr[i][j] += arr[i][j-1];
            }
        }
    }
}
