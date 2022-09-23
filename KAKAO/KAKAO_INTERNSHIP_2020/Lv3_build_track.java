package kakao_internship_2020;

// 2020 카카오 인턴십 - 경주로 건설
// https://school.programmers.co.kr/learn/courses/30/lessons/67259

import java.util.Arrays;
import java.util.LinkedList;
import java.util.Queue;

public class Lv3_build_track {

    public static int[] dx = {-1, 1, 0, 0};
    public static int[] dy = {0, 0, -1, 1};
    public static int[][] boardInfo;
    public static int[][][] minCost;

    public static final int EMPTY = 0;
    public static final int WALL = 1;
    public static int N;
    public static int cost = Integer.MAX_VALUE;

    public static void main(String[] args) {

//        int[][] board = {{0, 0, 0}, {0, 0, 0}, {0, 0, 0}};

//        int[][] board = {{0,0,0,0,0,0,0,1}, {0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 1, 0, 0}
//        , {0, 0, 0, 0, 1, 0, 0, 0}, {0, 0, 0, 1, 0, 0, 0, 1}, {0, 0, 1, 0, 0, 0, 1, 0}
//        , {0, 1, 0, 0, 0, 1, 0, 0},{1,0,0,0,0,0,0,0}};

//        int[][] board = {{0, 0, 1, 0}, {0, 0, 0, 0}, {0, 1, 0, 1}, {1, 0, 0, 0}};

//        int[][] board = {{0,0,0,0,0,0}, {0, 1, 1, 1, 1, 0}, {0, 0, 1, 0, 0, 0}
//                , {1, 0, 0, 1, 0, 1}, {0, 1, 0, 0, 0, 1},{0,0,0,0,0,0}};

        int[][] board = {{0,0,0,0,0,0,0,0}, {1,0,1,1,1,1,1,0}, {1,0,0,1,0,0,0,0}
                , {1,1,0,0,0,1,1,1}, {1,1,1,1,0,0,0,0},{1,1,1,1,1,1,1,0},{1,1,1,1,1,1,1,0},{1,1,1,1,1,1,1,0}};

        System.out.println(solution(board));
    }

    public static int solution(int[][] board) {

        N = board.length;
        boardInfo = board;
        minCost = new int[N][N][4];
        for (int[][] i : minCost) {
            for (int[] j : i) Arrays.fill(j, Integer.MAX_VALUE);
        }

        buildTrack();
//        trackLength[0][0] = 1;
//        if (boardInfo[0][1] != WALL) buildTrack(0, 0, 1, 0);
//        if (boardInfo[1][0] != WALL) buildTrack(0, 0, 3, 0);

        for (int i = 0; i < 4; i++) {
            cost = Math.min(cost, minCost[N-1][N-1][i]);
        }

        int answer = cost;
        return answer;
    }

    // bfs -> 최단 경로가 "최소 비용"을 보장하지는 않음! -> 메모이제이션 필요
    public static void buildTrack() {

        Queue<int[]> queue = new LinkedList<>();
        queue.offer(new int[]{0, 0, -1, 0});

        while (!queue.isEmpty()) {

            int[] cur = queue.poll();
            int curX = cur[0];
            int curY = cur[1];
            int curDir = cur[2];
            int curCost = cur[3];

            for (int i = 0; i < 4; i++) {

                int nextX = curX + dx[i];
                int nextY = curY + dy[i];
                int nextDir = i;

                if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= N || boardInfo[nextX][nextY] == WALL) continue;

                int nextCost = curCost + 100;
                if (curDir != nextDir && curDir != -1) nextCost += 500;

                if (nextCost <= minCost[nextX][nextY][nextDir]) {
                    minCost[nextX][nextY][nextDir] = nextCost;
                    if (nextX == N-1 && nextY == N-1) continue;
                    queue.offer(new int[]{nextX, nextY, nextDir, nextCost});
                }
            }
        }
    }

    // dfs -> 어느 방향 먼저 방문하냐에 따라 답이 달라진다고 함
    // 귀찮으니까 bfs로 풀자
//    public static void buildTrack(int x, int y, int dir, int cNum) {
//
//        if (trackLength[x][y]*100 + cNum*500 > cost) return;
//
//        if (x == N-1 && y == N-1) {
//            int s = trackLength[N-1][N-1]-1;
//            int c = cNum;
//            if (cost > s*100 + c*500) {
//                straight = s;
//                corner = c;
//                cost = s*100 + c*500;
//            }
//            return;
//        }
//
//        int curX = x;
//        int curY = y;
//        int curDir = dir;
//        int curCNum = cNum;
//
//        for (int i = 0; i < 4; i++) {
//
//            int nextX = curX + dx[i];
//            int nextY = curY + dy[i];
//            int nextDir = i;
//
//            if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= N) continue;
//
//            if (boardInfo[nextX][nextY] == EMPTY && trackLength[nextX][nextY] == 0) {
//                trackLength[nextX][nextY] = trackLength[curX][curY] + 1;
//                if (curDir != nextDir) buildTrack(nextX, nextY, nextDir, curCNum + 1);
//                else buildTrack(nextX, nextY, nextDir, curCNum);
//                trackLength[nextX][nextY] = 0;
//            }
//        }
//    }
}
