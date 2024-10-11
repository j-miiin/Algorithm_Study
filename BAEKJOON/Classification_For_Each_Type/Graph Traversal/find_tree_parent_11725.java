
// 백준 - 트리의 부모 찾기 11725
// https://www.acmicpc.net/problem/11725

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.StringTokenizer;

public class find_tree_parent_11725 {

    public static int[] parent;
    public static ArrayList<ArrayList<Integer>> graph = new ArrayList<>();
    public static boolean[] visited;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());
        parent = new int[N+1];
        visited = new boolean[N+1];
        for (int i = 0; i <= N; i++) {
            parent[i] = i;
            graph.add(new ArrayList<>());
        }

        for (int i = 0; i < N-1; i++) {
            StringTokenizer st = new StringTokenizer(br.readLine());
            int node1 = Integer.parseInt(st.nextToken());
            int node2 = Integer.parseInt(st.nextToken());

            graph.get(node1).add(node2);
            graph.get(node2).add(node1);
        }

        visited[1] = true;
        dfs(1);

        StringBuilder sb = new StringBuilder();
        for (int i = 2; i < parent.length; i++) sb.append(parent[i]).append("\n");
        System.out.println(sb);
    }

    public static void dfs(int curNode) {

        if (graph.get(curNode).size() == 0) return;

        for (int i = 0; i < graph.get(curNode).size(); i++) {
            int nextNode = graph.get(curNode).get(i);
            if (!visited[nextNode]) {
                visited[nextNode] = true;
                parent[nextNode] = curNode;
                dfs(nextNode);
            }
        }
    }
}
