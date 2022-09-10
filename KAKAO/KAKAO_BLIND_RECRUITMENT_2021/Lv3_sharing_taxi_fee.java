package kakao_blind_recruitment_2021;

// 2021 카카오 블라인드 채용

import java.util.ArrayList;

public class Lv3_sharing_taxi_fee {

    public static int[][] dist;
    public static final int INF = 100_000_000;

    public static void main(String[] args) {

//        int n = 6;
//        int s = 4;
//        int a = 6;
//        int b = 2;
//        int[][] fares = {{4, 1, 10}, {3, 5, 24}, {5, 6, 2}, {3, 1, 41}, {5, 1, 24}, {4, 6, 50}, {2, 4, 66}, {2, 3, 22}, {1, 6, 25}};

//        int n = 7;
//        int s = 3;
//        int a = 4;
//        int b = 1;
//        int[][] fares = {{5, 7, 9}, {4, 6, 4}, {3, 6, 1}, {3, 2, 3}, {2, 1, 6}};

        int n = 6;
        int s = 4;
        int a = 5;
        int b = 6;
        int[][] fares = {{2, 6, 6}, {6, 3, 7}, {4, 6, 7}, {6, 5, 11}, {2, 5, 12}, {5, 3, 20}, {2, 4, 8}, {4, 3, 9}};

        System.out.println(solution(n, s, a, b, fares));
    }

    public static int solution(int n, int s, int a, int b, int[][] fares) {

        dist = new int[n+1][n+1];

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                if (i == j) {
                    dist[i][j] = 0;
                    continue;
                }

                dist[i][j] = INF;
            }
        }

        for (int i = 0; i < fares.length; i++) {
            int start = fares[i][0];
            int end = fares[i][1];
            int cost = fares[i][2];

            dist[start][end] = cost;
            dist[end][start] = cost;
        }

        calculateMinCost_Floyd_Warshall(n);

        int sharingFee = getSharingFee(n, s, a, b);
        int noSharingFee = dist[s][a] + dist[s][b];

        int answer = (sharingFee < noSharingFee) ? sharingFee : noSharingFee;
        return answer;
    }

    public static void calculateMinCost_Floyd_Warshall(int n) {
        for (int k = 1; k <= n; k++) {
            for (int i = 1; i <= n; i++) {
                for (int j = 1; j <= n; j++) {
                    dist[i][j] = Math.min(dist[i][j], dist[i][k] + dist[k][j]);
                }
            }
        }
    }

    public static int getSharingFee(int n, int s, int a, int b) {
        int fee = INF;

        for (int i = 1; i <= n; i++) {
            fee = Math.min(fee, dist[s][i] + dist[i][a] + dist[i][b]);
        }

        return fee;
    }

}
