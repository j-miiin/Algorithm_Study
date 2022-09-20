package programmers;

// 프로그래머스 - 전력망을 둘로 나누기
// https://school.programmers.co.kr/learn/courses/30/lessons/86971

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Queue;

public class Lv2_divide_powergrid {

    public static ArrayList<ArrayList<Integer>> graph;
    public static boolean[][] isConnected;
    public static boolean[] visited;

    public static void main(String[] args) {

//        int n = 9;
//        int[][] wires = {{1, 3}, {2, 3}, {3, 4}, {4, 5}, {4, 6}, {4, 7}, {7, 8}, {7, 9}};

//        int n = 4;
//        int[][] wires = {{1, 2}, {2, 3}, {3, 4}};

        int n = 7;
        int[][] wires = {{1,2}, {2, 7}, {3, 7}, {3, 4}, {4, 5},{6,7}};

        System.out.println(solution(n, wires));
    }

    public static int solution(int n, int[][] wires) {

        graph = new ArrayList<>();
        for (int i = 0; i < n + 1; i++) {
            graph.add(new ArrayList<>());
        }

        isConnected = new boolean[n+1][n+1];
        for (int i = 0; i < wires.length; i++) {
            int node1 = wires[i][0];
            int node2 = wires[i][1];
            isConnected[node1][node2] = true;
            isConnected[node2][node1] = true;

            graph.get(node1).add(node2);
            graph.get(node2).add(node1);
        }

        int answer = Integer.MAX_VALUE;
        int disconnect = 0;
        for (int i = 0; i < wires.length; i++) {
            int node1 = wires[disconnect][0];
            int node2 = wires[disconnect][1];
            isConnected[node1][node2] = false;
            isConnected[node2][node1] = false;

            visited = new boolean[n+1];
            int[] result = countConnectedTransmissionTower(n, node1);
            int grid1 = result[0];
            int grid2 = result[1];
            answer = Math.min(answer, Math.abs(grid1 - grid2));
            disconnect++;
            isConnected[node1][node2] = true;
            isConnected[node2][node1] = true;
        }
        return answer;
    }

    public static int[] countConnectedTransmissionTower(int n, int node) {

        int count = 0;

        Queue<Integer> queue = new LinkedList<>();
        queue.offer(node);
        visited[node] = true;

        while(!queue.isEmpty()) {

            int curNode = queue.poll();
            count++;

            for (int i = 0; i < graph.get(curNode).size(); i++) {
                int nextNode = graph.get(curNode).get(i);

                if (isConnected[curNode][nextNode] && !visited[nextNode]) {
                    queue.offer(nextNode);
                    visited[nextNode] = true;
                }
            }
        }


        return new int[]{count, n - count};
    }
}
