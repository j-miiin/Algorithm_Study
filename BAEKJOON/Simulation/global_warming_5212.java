package baekjoon.simulation;

// 백준 - 지구 온난화 5212
// https://www.acmicpc.net/problem/5212

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class global_warming_5212 {

    public static final int WATER = 0;
    public static final int GROUND = 1;

    public static int R, C;
    public static int[][] map;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        R = Integer.parseInt(st.nextToken());
        C = Integer.parseInt(st.nextToken());
        map = new int[R][C];
        for (int i = 0; i < R; i++) {
            String cur = br.readLine();
            for (int j = 0; j < C; j++) {
                if (cur.charAt(j) == '.') map[i][j] = WATER;
                else map[i][j] = GROUND;
            }
        }

        after50years();
        makeMap();
    }

    public static void after50years() {
        boolean[][] safe = new boolean[R][C];
        for (int i = 0; i < R; i++) {
            for (int j = 0; j < C; j++) {
                if (isSafe(i, j)) safe[i][j] = true;
            }
        }

        for (int i = 0; i < R; i++) {
            for (int j = 0; j < C; j++) {
                if (!safe[i][j]) map[i][j] = WATER;
            }
        }
    }

    public static boolean isSafe(int x, int y) {
        int count = 0;
        int[] dx = {-1, 1, 0, 0};
        int[] dy = {0, 0, -1, 1};
        int curX = x;
        int curY = y;

        for (int i = 0; i < 4; i++) {
            int nextX = curX + dx[i];
            int nextY = curY + dy[i];
            if (nextX < 0 || nextY < 0 || nextX >= R || nextY >= C) count++;
            else if (map[nextX][nextY] == WATER) count++;
        }
        return (count < 3) ? true : false;
    }

    public static void makeMap() {
        int startX = 0, startY = 0;
        int endX = R-1, endY = C-1;

        for (int i = 0; i < R; i++) {
            boolean tmp = true;
            for (int j = 0; j < C; j++) {
                if (map[i][j] == GROUND) {
                    tmp = false;
                    break;
                }
            }
            if (tmp) startX++;
            else break;
        }

        for (int i = 0; i < C; i++) {
            boolean tmp = true;
            for (int j = 0; j < R; j++) {
                if (map[j][i] == GROUND) {
                    tmp = false;
                    break;
                }
            }
            if (tmp) startY++;
            else break;
        }

        for (int i = R-1; i >= 0; i--) {
            boolean tmp = true;
            for (int j = C-1; j >= 0; j--) {
                if (map[i][j] == GROUND) {
                    tmp = false;
                    break;
                }
            }
            if (tmp) endX--;
            else break;
        }

        for (int i = C-1; i >= 0; i--) {
            boolean tmp = true;
            for (int j = R-1; j >= 0; j--) {
                if (map[j][i] == GROUND) {
                    tmp = false;
                    break;
                }
            }
            if (tmp) endY--;
            else break;
        }

        printMap(startX, startY, endX, endY);
    }

    public static void printMap(int startX, int startY, int endX, int endY) {
        StringBuilder sb = new StringBuilder();
        for (int i = startX; i <= endX; i++) {
            for (int j = startY; j <= endY; j++) {
                if (map[i][j] == WATER) sb.append('.');
                else sb.append('X');
            }
            sb.append("\n");
        }
        System.out.println(sb);
    }
}
