package baekjoon.graph_traversal;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Queue;
import java.util.StringTokenizer;

public class laboratory_14502 {

    public static final int EMPTY = 0;
    public static final int WALL = 1;
    public static final int VIRUS = 2;

    public static int[] dx = {-1 ,1, 0, 0};
    public static int[] dy = {0, 0, -1, 1};

    public static int N, M;
    public static int[][] map;

    public static ArrayList<int[]> emptyList = new ArrayList<>();
    public static Queue<int[]> virusQueue = new LinkedList<>();
    public static boolean[][] isInfected;
    public static boolean[][] visited;

    public static boolean[] checkWall;
    public static int[] wallCombination = new int[3];

    public static int result = 0;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        N = Integer.parseInt(st.nextToken());
        M = Integer.parseInt(st.nextToken());
        map = new int[N][M];

        isInfected = new boolean[N][M];
        visited = new boolean[N][M];

        for (int i = 0; i < N; i++) {
            st = new StringTokenizer(br.readLine());
            for (int j = 0; j < M; j++) {
                int cur = Integer.parseInt(st.nextToken());
                if (cur == EMPTY) emptyList.add(new int[]{i, j});
                else if (cur == VIRUS) {
                    isInfected[i][j] = true;
                    virusQueue.offer(new int[]{i, j});
                }
                map[i][j] = cur;
            }
        }
        checkWall = new boolean[emptyList.size()];

        makeWallCombination(0);

        System.out.println(result);
    }

    public static void makeWallCombination(int count) {

        if (count == 3) {
            buildWall();
            spreadVirus();
            for (int i = 0; i < N; i++) {
                for (int j = 0; j < M; j++) {
                    if (!visited[i][j] && map[i][j] == EMPTY) result = Math.max(result, checkSafeArea(i, j));
                }
            }
            removeWall();
            return;
        }

        for (int i = 0; i < emptyList.size(); i++) {
            if (!checkWall[i]) {
                checkWall[i] = true;
                wallCombination[count] = i;
                makeWallCombination(count+1);
                checkWall[i] = false;
            }
        }
    }

    public static void buildWall() {

        for (int i = 0; i < wallCombination.length; i++) {
            int x = emptyList.get(wallCombination[i])[0];
            int y = emptyList.get(wallCombination[i])[1];
            map[x][y] = WALL;
        }
    }

    public static void removeWall() {
        for (int i = 0; i < wallCombination.length; i++) {
            int x = emptyList.get(wallCombination[i])[0];
            int y = emptyList.get(wallCombination[i])[1];
            map[x][y] = EMPTY;
        }
    }

    public static void spreadVirus() {

        while(!virusQueue.isEmpty()) {
            int[] cur = virusQueue.poll();
            int curX = cur[0];
            int curY = cur[1];

            for (int i = 0; i < 4; i++) {
                int nextX = curX + dx[i];
                int nextY = curY + dy[i];

                if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M) continue;

                if (!isInfected[nextX][nextY] && map[nextX][nextY] == EMPTY) {
                    isInfected[nextX][nextY] = true;
                    map[nextX][nextY] = VIRUS;
                    virusQueue.offer(new int[]{nextX, nextY});
                }
            }
        }
    }

    public static int checkSafeArea(int x, int y) {

        int count = 0;

        visited[x][y] = true;
        Queue<int[]> queue = new LinkedList<>();
        queue.offer(new int[]{x, y});

        while(!queue.isEmpty()) {
            int[] cur = queue.poll();
            int curX = cur[0];
            int curY = cur[1];

            for (int i = 0; i < 4; i++) {
                int nextX = curX + dx[i];
                int nextY = curY + dy[i];

                if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M) continue;

                if (!visited[nextX][nextY] && map[nextX][nextY] == EMPTY) {
                    visited[nextX][nextY] = true;
                    count++;
                }
            }
        }

        return count;
    }
}
