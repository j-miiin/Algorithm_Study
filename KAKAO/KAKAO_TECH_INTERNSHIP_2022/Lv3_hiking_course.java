package kakao_tech_internship_2022;

// 2022 카카오 테크 인턴십

import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedList;
import java.util.Queue;

class Node {
    int idx;
    int cost;

    Node(int idx, int cost) {
        this.idx = idx;
        this.cost = cost;
    }
}

public class Lv3_hiking_course {

    public static ArrayList<ArrayList<Node>> graph = new ArrayList<>();
    public static boolean[] isGate;
    public static boolean[] isSummit;

    public static int peakNum;
    public static int cost = Integer.MAX_VALUE;

    public static void main(String[] args) {
//        int n = 6;
//        int[][] paths = {{1, 2, 3}, {2, 3, 5}, {2, 4, 2}, {2, 5, 4}, {3, 4, 4}, {4, 5, 3}, {4, 6, 1}, {5, 6, 1}};
//        int[] gates = {1, 3};
//        int[] summits = {5};

//        int n = 7;
//        int[][] paths = {{1, 4, 4}, {1, 6, 1}, {1, 7, 3}, {2, 5, 2}, {3, 7, 4}, {5, 6, 6}};
//        int[] gates = {1};
//        int[] summits = {2, 3, 4};

//        int n = 7;
//        int[][] paths = {{1, 2, 5}, {1, 4, 1}, {2, 3, 1}, {2, 6, 7}, {4, 5, 1}, {5, 6, 1}, {6, 7, 1}};
//        int[] gates = {3, 7};
//        int[] summits = {1, 5};

        int n = 5;
        int[][] paths = {{1, 3, 10}, {1, 4, 20}, {2, 3, 4}, {2, 4, 6}, {3, 5, 20}, {4, 5, 6}};
        int[] gates = {1, 2};
        int[] summits = {5};

        int[] ans = solution(n, paths, gates, summits);
        for (int i : ans) System.out.println(i);
    }

    public static int[] solution(int n, int[][] paths, int[] gates, int[] summits) {

        isGate = new boolean[n+1];
        for (int i : gates) {
            isGate[i] = true;
        }

        isSummit = new boolean[n+1];
        for (int i : summits) {
            isSummit[i] = true;
        }

        for (int i = 0; i < n + 1; i++) {
            graph.add(new ArrayList<>());
        }

        for (int i = 0; i < paths.length; i++) {
            int node1 = paths[i][0];
            int node2 = paths[i][1];
            int cost = paths[i][2];

            if (isGate[node1] || isSummit[node2]) {
                graph.get(node1).add(new Node(node2, cost));
            } else if (isGate[node2] || isSummit[node1]) {
                graph.get(node2).add(new Node(node1, cost));
            } else {
                graph.get(node1).add(new Node(node2, cost));
                graph.get(node2).add(new Node(node1, cost));
            }
        }

        int[] intensity = dijkstra(n, gates);
        Arrays.sort(summits);
        for (int summit : summits) {
            if (intensity[summit] < cost) {
                cost = intensity[summit];
                peakNum = summit;
            }
        }

        int[] answer = {peakNum, cost};
        return answer;
    }

    public static int[] dijkstra(int n, int[] gates) {
        int[] intensity = new int[n + 1];
        Arrays.fill(intensity, Integer.MAX_VALUE);

        Queue<Node> queue = new LinkedList<>();
        for (int gate : gates) {
            queue.add(new Node(gate, 0));
            intensity[gate] = 0;
        }

        while (!queue.isEmpty()) {
            Node cur = queue.poll();
            int curNode = cur.idx;
            int curCost = cur.cost;

            if (curCost < intensity[curNode]) continue;

            for (int i = 0; i < graph.get(curNode).size(); i++) {
                Node next = graph.get(curNode).get(i);
                int nextNode = next.idx;
                int nextCost = next.cost;

                int dist = Math.max(intensity[curNode], nextCost);
                if (intensity[nextNode] > dist) {
                    intensity[nextNode] = dist;
                    queue.add(new Node(nextNode, dist));
                }
            }
        }

        return intensity;
    }

//    public static void goPeak(int curNode, int cost) {
//
//        if (isSummit[curNode]) {
//            if (intensity > cost) {
//                intensity = cost;
//                peakNum = curNode;
//            } else if (intensity == cost) {
//                peakNum = Math.min(peakNum, curNode);
//            }
//            return;
//        }
//
//        for (int i = 0; i < graph.get(curNode).size(); i++) {
//            int adjNode = graph.get(curNode).get(i).idx;
//            int adjNodeCost = graph.get(curNode).get(i).cost;
//
//            if (!visited[adjNode]) {
//                visited[adjNode] = true;
//                if (cost < adjNodeCost) goPeak(adjNode, adjNodeCost);
//                else goPeak(adjNode, cost);
//                visited[adjNode] = false;
//            }
//        }
//    }
}
