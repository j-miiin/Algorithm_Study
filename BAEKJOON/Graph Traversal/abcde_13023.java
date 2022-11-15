
// 백준 - ABCDE 13023
// https://www.acmicpc.net/problem/13023

package baekjoon.graph_traversal;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.StringTokenizer;

public class abcde_13023 {

    public static ArrayList<Integer>[] graph;
    public static int N, M;
    public static boolean[] visited;
    public static boolean result = false;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        N = Integer.parseInt(st.nextToken());
        M = Integer.parseInt(st.nextToken());

        graph = new ArrayList[N];
        for (int i = 0; i < N; i++) graph[i] = new ArrayList<>();

        for (int i = 0; i < M; i++) {
            st = new StringTokenizer(br.readLine());
            int a = Integer.parseInt(st.nextToken());
            int b = Integer.parseInt(st.nextToken());
            graph[a].add(b);
            graph[b].add(a);
        }

        for (int i = 0; i < N; i++) {
            visited = new boolean[N];
            visited[i] = true;
            dfs(i, 1);
            if (result) break;
        }
        System.out.println((result == true) ? "1" : "0");
    }

    public static void dfs(int curNode, int depth) {

        if (depth == 5) {
            result = true;
            return;
        }

        for (int i = 0; i < graph[curNode].size(); i++) {
            int nextNode = graph[curNode].get(i);
            if (!visited[nextNode]) {
                visited[nextNode] = true;
                dfs(nextNode, depth+1);
                visited[nextNode] = false;
            }
        }
    }
}
