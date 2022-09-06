
// 2022 카카오 블라인드 채용

import java.util.ArrayList;

public class Lv3_sheep_and_wolf {

    private static final int SHEEP = 0;
    private static final int WOLF = 1;

    public static int maxSheep = 1;

    public static void main(String[] args) {

//        int[] info = {0,0,1,1,1,0,1,0,1,0,1,1};
//        int[][] edges = {{0, 1},{1, 2},{1, 4},{0, 8},{8, 7}, {9, 10}, {9, 11}, {4, 3}, {6, 5}, {4, 6}, {8, 9}};

        int[] info = {0,1,0,1,1,0,1,0,0,1,0};
        int[][] edges = {{0, 1}, {0, 2}, {1, 3}, {1, 4}, {2, 5}, {2, 6}, {3, 7}, {4, 8}, {6, 9}, {9, 10}};

        System.out.println(solution(info, edges));
    }

    public static int solution(int[] info, int[][] edges) {

        ArrayList<ArrayList<Integer>> graph = new ArrayList<>();
        for (int i = 0; i < info.length; i++) {
            graph.add(new ArrayList<>());
        }

        for (int i = 0; i < edges.length; i++) {
            int parentNode = edges[i][0];
            int childNode = edges[i][1];

            graph.get(parentNode).add(childNode);
        }

        ArrayList<Integer> nextNodes = new ArrayList<>();
        for (int i = 0; i < graph.get(0).size(); i++) {
            nextNodes.add(graph.get(0).get(i));
        }
        gatheringSheep(0, 0, 0, nextNodes, info, graph);

        int answer = maxSheep;
        return answer;
    }

    public static void gatheringSheep(int curNode, int sheep, int wolf, ArrayList<Integer> nextNodes, int[] info, ArrayList<ArrayList<Integer>> graph) {

        int curSheep = sheep;
        int curWolf = wolf;

        if (info[curNode] == SHEEP) {
            curSheep++;
            maxSheep = Math.max(maxSheep, curSheep);
        } else {
            curWolf++;
        }

        if (curSheep <= curWolf) return;

        for (int i = 0; i < nextNodes.size(); i++) {
            ArrayList<Integer> newNextNodes = new ArrayList<>();
            for (int node : nextNodes) {
                newNextNodes.add(node);
            }
            newNextNodes.remove(i);

            int next = nextNodes.get(i);
            for (int node: graph.get(next)) {
                newNextNodes.add(node);
            }

            gatheringSheep(next, curSheep, curWolf, newNextNodes, info, graph);
        }
    }
}
