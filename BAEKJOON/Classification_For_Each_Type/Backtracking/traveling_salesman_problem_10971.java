package baekjoon.backtracking;

// 백준 - 외판원 순회2 10971
// https://www.acmicpc.net/problem/10971

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class traveling_salesman_problem_10971 {

    public static int N;
    public static int[][] graph;
    public static boolean[] visited;
    public static int result = Integer.MAX_VALUE;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        N = Integer.parseInt(br.readLine());
        graph = new int[N][N];
        visited = new boolean[N];
        for (int i = 0; i < N; i++) {
            StringTokenizer st = new StringTokenizer(br.readLine());
            for (int j = 0; j < N; j++) {
                graph[i][j] = Integer.parseInt(st.nextToken());
            }
        }

        visited[0] = true;
        traveling(0, 1, 0);
        System.out.println(result);
    }

    public static void traveling(int curNode, int depth, int cost) {

        if (depth == N) {
            if (graph[curNode][0] != 0) {
                int curCost = cost + graph[curNode][0];
                result = Math.min(curCost, result);
            }
            return;
        }

        for (int i = 0; i < N; i++) {
            if (graph[curNode][i] == 0 || visited[i]) continue;
            visited[i] = true;
            traveling(i, depth+1, cost+graph[curNode][i]);
            visited[i] = false;
        }
    }
}
