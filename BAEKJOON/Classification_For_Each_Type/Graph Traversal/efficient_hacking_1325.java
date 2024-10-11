
// 백준 - 효율적인 해킹 1325
// https://www.acmicpc.net/problem/1325

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.StringTokenizer;

public class efficient_hacking_1325 {

    public static int N, M;
    public static ArrayList<Integer>[] graph;
    public static boolean[] visited;
    public static int[] count;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        N = Integer.parseInt(st.nextToken());
        M = Integer.parseInt(st.nextToken());

        graph = new ArrayList[N+1];
        for (int i = 1; i <= N; i++) graph[i] = new ArrayList<>();

        for (int i = 0; i < M; i++) {
            st = new StringTokenizer(br.readLine());
            int node1 = Integer.parseInt(st.nextToken());
            int node2 = Integer.parseInt(st.nextToken());

            graph[node1].add(node2);
        }

        count = new int[N+1];
        for (int i = 1; i <= N; i++) {
            visited = new boolean[N+1];
            visited[i] = true;
            dfs(i);
        }

        int max = 0;
        for (int i = 1; i <= N; i++) max = Math.max(max, count[i]);
        StringBuilder sb = new StringBuilder();
        for(int i = 1; i <= N; i++) {
            if (count[i] == max) sb.append(i+" ");
        }
        System.out.println(sb);
    }

    public static void dfs (int curNode) {

        for (int i = 0; i < graph[curNode].size(); i++) {
            int nextNode = graph[curNode].get(i);
            if (!visited[nextNode]) {
                visited[nextNode] = true;
                dfs(nextNode);
                count[nextNode]++;
            }
        }
    }
}
