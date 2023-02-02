package baekjoon.tree;

// 백준 - 단절점과 단절선 14675
// https://www.acmicpc.net/problem/14675

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.StringTokenizer;

public class cut_vertex_and_bridge_14675 {

    public static int N;
    public static ArrayList<Integer>[] graph;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        N = Integer.parseInt(br.readLine());
        graph = new ArrayList[N+1];
        for (int i = 1; i <= N; i++) graph[i] = new ArrayList<>();

        String[] bridges = new String[N+1];
        for (int i = 1; i < N; i++) {
            bridges[i] = br.readLine();
            StringTokenizer st = new StringTokenizer(bridges[i]);

            int node1 = Integer.parseInt(st.nextToken());
            int node2 = Integer.parseInt(st.nextToken());

            graph[node1].add(node2);
            graph[node2].add(node1);
        }

        int q = Integer.parseInt(br.readLine());
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < q; i++) {
            StringTokenizer st = new StringTokenizer(br.readLine());
            int t = Integer.parseInt(st.nextToken());
            int query = Integer.parseInt(st.nextToken());

            if (t == 1) {
                sb.append((isCutVertex(query)) ? "yes" : "no").append("\n");
            } else {
                sb.append("yes").append("\n");
            }
        }
        System.out.println(sb);
    }

    public static boolean isCutVertex(int query) {
        return (graph[query].size() > 1) ? true : false;
    }
}
