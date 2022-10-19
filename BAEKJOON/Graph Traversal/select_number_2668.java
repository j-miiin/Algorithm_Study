
// 백준 - 숫자 고르기 2668
// https://www.acmicpc.net/problem/2668

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class select_number_2668 {

    public static int N;
    public static int[] table;
    public static int[] visited;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        N = Integer.parseInt(br.readLine());
        table = new int[N+1];
        visited = new int[N+1];
        for (int i = 1; i <= N; i++) table[i] = Integer.parseInt(br.readLine());

        for (int i = 1; i <= N; i++) {
            init();
            dfs(i);
        }

        StringBuilder sb = new StringBuilder();
        sb.append("\n");
        int count = 0;
        for (int i = 1; i <= N; i++) {
            if (visited[i] == 2) {
                count++;
                sb.append(i).append("\n");
            }
        }
        sb.insert(0, count);
        System.out.println(sb);
    }

    public static void dfs(int node) {
        if (visited[node] == 2) return;
        visited[node] += 1;
        dfs(table[node]);
    }

    public static void init() {
        for (int i = 1; i <= N; i++) {
            if (visited[i] < 2) visited[i] = 0;
        }
    }
}
