package kakao_blind_recruitment_2022_retry;

// 2022 카카오 블라인드 채용 - Lv3 양과 늑대 2번째 풀이
// https://school.programmers.co.kr/learn/courses/30/lessons/92343

import java.util.ArrayList;

public class Lv3_sheep_and_wolf {

    public static final int SHEEP = 0, WOLF = 1;
    public static int N;
    public static int result = 1;

    public static int[] nodeInfo;
    public static ArrayList<ArrayList<Integer>> graph;

    public static void main(String[] args) {
//        int[] info = {0,0,1,1,1,0,1,0,1,0,1,1};
//        int[][] edges = {{0, 1},{1, 2},{1, 4},{0, 8},{8, 7}, {9, 10}, {9, 11}, {4, 3}, {6, 5}, {4, 6}, {8, 9}};

        int[] info = {0,1,0,1,1,0,1,0,0,1,0};
        int[][] edges = {{0, 1}, {0, 2}, {1, 3}, {1, 4}, {2, 5}, {2, 6}, {3, 7}, {4, 8}, {6, 9}, {9, 10}};

        System.out.println(solution(info, edges));
    }

    public static int solution(int[] info, int[][] edges) {

        N = info.length;
        nodeInfo = info;
        graph = new ArrayList<>();
        for (int i = 0; i < N; i++) {
            graph.add(new ArrayList<>());
        }

        for (int i = 0; i < edges.length; i++) {
            int node1 = edges[i][0];
            int node2 = edges[i][1];

            graph.get(node1).add(node2);
        }

        ArrayList<Integer> nextArr = new ArrayList<>();
        for (int i : graph.get(0)) nextArr.add(i);
        gatheringSheep(0, 0, 0, nextArr);

        int answer = result;
        return answer;
    }

    public static void gatheringSheep(int curNode, int sheep, int wolf, ArrayList<Integer> curArr) {

        int s = sheep;
        int w = wolf;
        if (nodeInfo[curNode] == SHEEP) {
            s++;
            result = Math.max(result, s);
        }
        else w++;

        if (s <= w) return;

        for (int i = 0; i < curArr.size(); i++) {
            ArrayList<Integer> nextArr = new ArrayList<>();
            for (int node : curArr) nextArr.add(node);
            nextArr.remove(i);

            int next = curArr.get(i);
            for (int node : graph.get(next)) nextArr.add(node);

            gatheringSheep(next, s, w, nextArr);
        }

    }
}
