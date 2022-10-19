
// 백준 - 공주님을 구해라! 17836
// https://www.acmicpc.net/problem/17836

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedList;
import java.util.Queue;
import java.util.StringTokenizer;

public class save_princess_17836 {

    public static final int EMPTY = 0;
    public static final int WALL = 1;
    public static final int SWORD = 2;

    public static int[] dx = {-1, 1, 0, 0};
    public static int[] dy = {0, 0, -1, 1};

    public static int N, M, T;
    public static int[][] castle;
    public static boolean[][][] visited;

    public static int swordX, swordY;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        N = Integer.parseInt(st.nextToken());
        M = Integer.parseInt(st.nextToken());
        T = Integer.parseInt(st.nextToken());

        castle = new int[N][M];
        visited = new boolean[N][M][2];
        for (int i = 0; i < N; i++) {
            st = new StringTokenizer(br.readLine());
            for (int j = 0; j < M; j++) {
                int cur = Integer.parseInt(st.nextToken());
                castle[i][j] = cur;
                if (cur == SWORD) {
                    swordX = i;
                    swordY = j;
                }
            }
        }

        int result = bfs(0, 0);
        System.out.println((result != -1) ? result : "Fail");
    }

    public static int bfs(int x, int y) {

        Queue<int[]> queue = new LinkedList<>();
        queue.offer(new int[]{x, y, 0, 0});
        visited[x][y][0] = true;

        while (!queue.isEmpty()) {

            int[] cur = queue.poll();
            int curX = cur[0];
            int curY = cur[1];
            int curTime = cur[2];
            int getSword = cur[3];

            if (curTime > T) break;
            if (curX == N-1 && curY == M-1) return curTime;

            for (int i = 0; i < 4; i++) {
                int nextX = curX + dx[i];
                int nextY = curY + dy[i];

                if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M) continue;

                if (getSword == 0) {
                    if (!visited[nextX][nextY][0] && castle[nextX][nextY] == EMPTY) {
                        visited[nextX][nextY][0] = true;
                        queue.offer(new int[]{nextX, nextY, curTime+1, getSword});
                    } else if (!visited[nextX][nextY][0] && castle[nextX][nextY] == SWORD) {
                        visited[nextX][nextY][0] = true;
                        queue.offer(new int[]{nextX, nextY, curTime+1, 1});
                    }
                } else {
                    if (!visited[nextX][nextY][1]) {
                        visited[nextX][nextY][1] = true;
                        queue.offer(new int[]{nextX, nextY, curTime+1, getSword});
                    }
                }
            }
        }
        return -1;
    }
}
